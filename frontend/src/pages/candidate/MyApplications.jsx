import React, { useEffect, useState } from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Separator } from "@/components/ui/separator";
import api from "../../services/api";

const MyApplications = () => {
  const [applications, setApplications] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchMyApplications = async () => {
      try {
        const res = await api.get("/Candidate/applications");
        setApplications(res.data);
      } catch (err) {
        console.error("Failed to fetch applications", err);
      } finally {
        setLoading(false);
      }
    };

    fetchMyApplications();
  }, []);

  if (loading) {
    return <div className="py-10 text-center">Loading applications…</div>;
  }

  return (
    <Card>
      <CardHeader>
        <CardTitle className="text-xl">My Applications</CardTitle>
      </CardHeader>

      <Separator />

      <CardContent>
        {applications.length === 0 ? (
          <div className="text-sm text-muted-foreground">
            No applications found
          </div>
        ) : (
          <Table>
            <TableHeader>
              <TableRow>
                <TableHead>Job</TableHead>
                <TableHead>Applied On</TableHead>
                <TableHead>Status</TableHead>
                <TableHead className="text-right">Action</TableHead>
              </TableRow>
            </TableHeader>

            <TableBody>
              {applications.map((app) => (
                <TableRow key={app.applicationId}>
                  <TableCell className="font-medium">{app.jobTitle}</TableCell>

                  <TableCell>
                    {new Date(app.applicationDate).toLocaleDateString()}
                  </TableCell>

                  <TableCell>{app.currentStatus}</TableCell>

                  <TableCell className="text-right">
                    <Button asChild size="sm">
                      <a href={`/jobs/${app.jobId}`}>View</a>
                    </Button>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        )}
      </CardContent>
    </Card>
  );
};

export default MyApplications;
