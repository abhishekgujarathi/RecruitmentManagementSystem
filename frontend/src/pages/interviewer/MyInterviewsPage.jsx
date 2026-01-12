import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { useAuth } from "../../hooks/useAuth";
import { Separator } from "@/components/ui/separator";
import { Button } from "@/components/ui/button";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";

const MyInterviewsPage = () => {
  const { authState } = useAuth();

  const [rounds, setRounds] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchMyInterviews = async () => {
      try {
        const res = await api.get("Interview/assigned");
        setRounds(res.data);
      } catch (error) {
        console.error("Failed to fetch interviews:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchMyInterviews();
  }, []);

  if (authState?.role !== "Employee") return null;
  if (loading)
    return <div className="py-10 text-center">Loading interviews…</div>;

  const pendingRounds = rounds.filter((r) => r.status !== "Completed");
  const completedRounds = rounds.filter((r) => r.status === "Completed");

  return (
    <main className="p-4">
      <Card>
        <CardHeader>
          <CardTitle className="text-xl">My Interviews</CardTitle>
        </CardHeader>

        <Separator />

        <CardContent className="space-y-6">
          <div>
            <h3 className="font-semibold mb-2">Pending Interviews</h3>
            {renderTable(pendingRounds)}
          </div>

          <Separator />

          <div>
            <h3 className="font-semibold mb-2">Completed Interviews</h3>
            {renderTable(completedRounds)}
          </div>
        </CardContent>
      </Card>
    </main>
  );
};

const renderTable = (data) => {
  if (data.length === 0) {
    return (
      <div className="text-sm text-muted-foreground py-2">No interviews</div>
    );
  }

  return (
    <Table>
      <TableHeader>
        <TableRow>
          <TableHead>Round</TableHead>
          <TableHead>Status</TableHead>
          <TableHead>Scheduled At</TableHead>
          <TableHead className="text-right">Action</TableHead>
        </TableRow>
      </TableHeader>

      <TableBody>
        {data.map((round) => (
          <TableRow key={round.applicationInterviewRoundId}>
            <TableCell className="font-medium">{round.roundType}</TableCell>

            <TableCell>{round.status}</TableCell>

            <TableCell>
              {round.scheduledAt
                ? new Date(round.scheduledAt).toLocaleString()
                : "—"}
            </TableCell>

            <TableCell className="text-right">
              <Button asChild size="sm">
                <a href={`applications/${round.jobApplicationId}`}>View</a>
              </Button>
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
};

export default MyInterviewsPage;
