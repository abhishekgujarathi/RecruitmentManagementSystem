import React, { useEffect, useState } from "react";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
  CardFooter,
} from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
} from "@/components/ui/select";
import api from "../../services/api";
import { toast } from "sonner";
import { useAuth } from "../../hooks/useAuth";

const DefaultReviewer = ({ jobId }) => {
  const { authState } = useAuth();

  const [reviewers, setReviewers] = useState([]); // all possible reviewers
  const [assignedReviewers, setAssignedReviewers] = useState([]); // current assigned
  const [selectedReviewerId, setSelectedReviewerId] = useState("");
  const [loading, setLoading] = useState(true);

  // Fetch all possible reviewers
  const getReviewerList = async () => {
    try {
      const res = await api.get(`/Recruiters/employees/reviewer`);
      setReviewers(res.data);
    } catch (err) {
      console.error("Failed to fetch reviewers:", err);
      toast.error("Failed to load reviewers");
    }
  };

  // Fetch currently assigned default reviewers for the job
  const getAssignedReviewers = async () => {
    setLoading(true);
    try {
      const res = await api.get(`Recruiters/jobs/${jobId}/defaultReviewer`);
      setAssignedReviewers(res.data);
      console.log(res.data);
    } catch (err) {
      console.error("2Failed to fetch assigned reviewers:", err);
      toast.error("2Failed to load assigned reviewers");
    } finally {
      setLoading(false);
    }
  };

  const assignDefaultReviewer = async () => {
    if (!selectedReviewerId) return;

    try {
      //   const res = await api.post(`/Recruiter/jobs/${jobId}/defaultReviewer`, {
      const res = await api.post(`/Recruiters/jobs/${jobId}/defaultReviewer`, {
        reviewerId: selectedReviewerId,
      });

      if (res.status === 200) {
        toast.success("Default reviewer assigned!");
        setSelectedReviewerId("");
        getAssignedReviewers();
      }
    } catch (err) {
      console.error(err);
      toast.error("Failed to assign default reviewer");
    }
  };

  const handleDelete = async (reviewerId) => {
    try {
      const payload = {
        data: { reviewerId },
      };
      await api.delete(`Recruiters/jobs/${jobId}/defaultReviewer`, payload);

      toast.success("Default reviewer removed successfully");

      // refresh list
      getAssignedReviewers();
    } catch (error) {
      console.error("Failed to remove reviewer", error);
      toast.error(error.response?.data || "Failed to remove default reviewer");
    }
  };

  useEffect(() => {
    if (authState.employeeRoles.includes("Recruiter")) {
      getReviewerList();
      getAssignedReviewers();
    }
  }, [jobId]);

  return (
    <Card className="w-full max-w-2xl">
      <CardHeader>
        <CardTitle>Default Reviewer</CardTitle>
      </CardHeader>
      <CardContent className="space-y-4">
        {authState.employeeRoles.includes("Recruiter") && (
          <div className="flex gap-2 items-center">
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
            <Button
              onClick={assignDefaultReviewer}
              disabled={!selectedReviewerId}
            >
              Assign
            </Button>
          </div>
        )}

        {loading && (
          <p className="text-sm text-muted-foreground">Loading reviewers...</p>
        )}

        {!loading && assignedReviewers.length === 0 && (
          <p className="text-sm text-muted-foreground">
            No default reviewers assigned
          </p>
        )}

        {!loading && assignedReviewers.length > 0 && (
          <div className="flex flex-wrap gap-2">
            {assignedReviewers.map((r) => (
              <div
                key={r.key}
                className="flex items-center gap-2 px-3 py-1 rounded-full bg-muted text-sm"
              >
                <span>{r.value}</span>

                <Button
                  variant="destructive"
                  size="sm"
                  className="h-6 px-2 text-xs"
                  onClick={() => handleDelete(r.key)}
                >
                  Del
                </Button>
              </div>
            ))}
          </div>
        )}
      </CardContent>
      <CardFooter>
        <p className="text-xs text-muted-foreground">
          Assign default reviewers who will be suggested for all applicants.
        </p>
      </CardFooter>
    </Card>
  );
};

export default DefaultReviewer;
