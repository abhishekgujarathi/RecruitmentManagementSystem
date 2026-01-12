import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { useAuth } from "../../hooks/useAuth";
import { Input } from "@/components/ui/input";
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
import { Separator } from "@/components/ui/separator";

const Applications = () => {
  const { authState } = useAuth();

  const [applications, setApplications] = useState([]);
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchMyApplicants = async () => {
      try {
        const res = await api.get("Applications/assigned");
        setApplications(res.data);
      } catch (err) {
        console.error("Failed to fetch applications", err);
      } finally {
        setLoading(false);
      }
    };

    fetchMyApplicants();
  }, []);

  if (authState?.role !== "Employee") return null;

  const filtered = applications.filter((a) =>
    a.candidateName.toLowerCase().includes(search.toLowerCase())
  );

  const pendingReviews = filtered.filter((a) => !a.reviewCompleted);
  const completedReviews = filtered.filter((a) => a.reviewCompleted);

  return (
    <Card>
      <CardHeader>
        <CardTitle className="text-xl">Applicants Assigned</CardTitle>
      </CardHeader>
      <Separator />

      <CardContent className="space-y-6">
        <Input
          placeholder="Search by candidate name..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          className="max-w-sm"
        />

        {loading ? (
          <div className="text-sm text-muted-foreground">
            Loading applicants...
          </div>
        ) : (
          <>
            {/* Pending Reviews */}
            <div>
              <h3 className="font-semibold mb-2">Pending Reviews</h3>
              {renderTable(pendingReviews)}
            </div>

            <Separator />

            {/* Completed Reviews */}
            <div>
              <h3 className="font-semibold mb-2">Completed Reviews</h3>
              {renderTable(completedReviews)}
            </div>
          </>
        )}
      </CardContent>
    </Card>
  );
};

const renderTable = (data) => {
  if (data.length === 0) {
    return (
      <div className="text-sm text-muted-foreground py-2">No applications</div>
    );
  }

  return (
    <Table>
      <TableHeader>
        <TableRow>
          <TableHead>Candidate</TableHead>
          <TableHead>Applied On</TableHead>
          <TableHead>Status</TableHead>
          <TableHead className="text-right">Action</TableHead>
        </TableRow>
      </TableHeader>

      <TableBody>
        {data.map((apl) => (
          <TableRow key={apl.applicationId}>
            <TableCell className="font-medium">{apl.candidateName}</TableCell>

            <TableCell>
              {new Date(apl.applicationDate).toLocaleDateString()}
            </TableCell>

            <TableCell>{apl.currentStatus}</TableCell>

            <TableCell className="text-right">
              <Button asChild size="sm">
                <a href={`applications/${apl.applicationId}`}>View</a>
              </Button>
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
};

export default Applications;
