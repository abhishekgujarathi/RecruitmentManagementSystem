import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { toast } from "sonner";
import ApplicationReviewsSection from "../../components/recruiter/ApplicationReviewsSection";
import { useAuth } from "../../hooks/useAuth";

const ApplicationReviewerManager = ({ applicationId }) => {
  const [loading, setLoading] = useState(true);
  const [reviewers, setReviewers] = useState([]);
  const [appliReviewers, setAppliReviewers] = useState([]);
  const [selectedReviewerId, setSelectedReviewerId] = useState("");

  const { authState } = useAuth();

  const formatDate = (date) =>
    date ? new Date(date).toLocaleDateString("en-GB") : "N/A";

  const getApplicationReviewers = async () => {
    try {
      const res = await api.get(`/Applications/${applicationId}/reviewers`);
      setAppliReviewers(res.data);
    } catch (err) {
      console.error("Failed to fetch reviewers:", err);
    } finally {
      setLoading(false);
    }
  };

  const getReviewerList = async () => {
    try {
      const res = await api.get(`/Recruiters/employees/${applicationId}`);
      setReviewers(res.data);
    } catch (err) {
      console.error("Failed to fetch reviewer list:", err);
    }
  };

  const assignReviewer = async () => {
    if (!selectedReviewerId) return;

    try {
      const res = await api.post(`Applications/${applicationId}/reviewers`, {
        reviewerId: selectedReviewerId,
      });

      if (res.status === 200) {
        getApplicationReviewers();
        getReviewerList();
        setSelectedReviewerId("");
        toast.success("Reviewer Added");
      }
    } catch (err) {
      toast.error("Failed to assign reviewer");
    }
  };

  useEffect(() => {
    getApplicationReviewers();
    getReviewerList();
  }, [applicationId]);

  return (
    <Card>
      <CardContent>
        <div className="p-2 space-y-4 flex flex-col">
          {console.log("rev magr", applicationId)}
          <h3 className="font-semibold mb-4">Assigned Reviewers</h3>

          {/* review assign */}
          {authState.employeeRoles.includes("Recruiter") && (
            <div className="flex gap-2 mb-4 w-full justify-end">
              <Select
                value={selectedReviewerId}
                onValueChange={setSelectedReviewerId}
              >
                <SelectTrigger>
                  <SelectValue placeholder="Select Reviewer" />
                </SelectTrigger>
                <SelectContent>
                  {reviewers.map((r) => (
                    <SelectItem key={r.key} value={r.key}>
                      {r.value}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <Button onClick={assignReviewer} disabled={!selectedReviewerId}>
                Assign
              </Button>
            </div>
          )}
          {loading ? (
            <p>Loading...</p>
          ) : appliReviewers?.length === 0 ? (
            <p className="text-sm text-muted-foreground">
              No reviewers assigned
            </p>
          ) : (
            <Table className="border w-full">
              <TableHeader>
                <TableRow>
                  <TableHead>Name</TableHead>
                  <TableHead>Status</TableHead>
                  <TableHead>Assigned On</TableHead>
                  <TableHead>Reviewed On</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {appliReviewers.map((r) => (
                  <TableRow key={r.id}>
                    <TableCell>{r.name}</TableCell>
                    <TableCell>{r.status}</TableCell>
                    <TableCell>{formatDate(r.assignedDate)}</TableCell>
                    <TableCell>
                      {formatDate(r.reviewedOn) || "Pending"}
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          )}

          <ApplicationReviewsSection applicationId={applicationId} />
        </div>
      </CardContent>
    </Card>
  );
};

export default ApplicationReviewerManager;
