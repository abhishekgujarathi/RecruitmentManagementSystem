import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
  CardDescription,
} from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { ArrowLeft, Delete, Plus } from "lucide-react";
import { toast } from "sonner";
import { useAuth } from "../hooks/useAuth";
import api from "../services/api";

const JobDetail = () => {
  const { jobId } = useParams();
  const navigate = useNavigate();
  const { authState } = useAuth();
  const [job, setJob] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchJob = async () => {
      try {
        const res = await api.get(`/Jobs/${jobId}`);
        setJob(res.data);
      } catch (err) {
        console.error("Failed to fetch job:", err);
      } finally {
        setLoading(false);
      }
    };
    fetchJob();
  }, [jobId]);

  const handleDelete = async () => {
    if (!window.confirm("Are you sure you want to delete this job?")) return;

    try {
      await api.delete(`/Recruiters/jobs/${jobId}`);
      toast.success("Job deleted successfully!");
      navigate("/recruiter/jobs");
    } catch (error) {
      console.error("Delete job failed:", error);
      toast.error(
        error.response?.data?.message ||
          "Failed to delete the job. Please try again."
      );
    }
  };

  const handleApply = async () => {
    try {
      await api.post(`/Candidate/apply/${jobId}`);
      toast.success("Applied successfully!");
    } catch (err) {
      console.error(err);
      toast.error("Failed to apply for job");
    }
  };

  if (loading) return <div className="text-center py-10">Loading job...</div>;
  if (!job) return <div className="text-center py-10">Job not found</div>;

  return (
    <div className="container mx-auto py-10 px-4">
      <Button variant="ghost" asChild>
        <a href="/jobs" className="mb-4 inline-flex items-center gap-2">
          <ArrowLeft /> Back to Jobs
        </a>
      </Button>

      <Card className="max-w-3xl mx-auto">
        <CardHeader>
          <CardTitle>{job.jobDescription.title}</CardTitle>
          <CardDescription>
            {job.jobDescription.location} | {job.jobDescription.jobType} |{" "}
            {job.openingsCount} Openings
          </CardDescription>
        </CardHeader>

        <CardContent className="space-y-4">
          <p>
            <strong>Details:</strong> {job.jobDescription.details}
          </p>
          <p>
            <strong>Responsibilities:</strong>{" "}
            {job.jobDescription.responsibilities || "Not specified"}
          </p>
          <p>
            <strong>Minimum Experience Required:</strong>{" "}
            {job.jobDescription.minimumExperienceReq} years
          </p>
          <p>
            <strong>Deadline:</strong>{" "}
            {new Date(job.deadlineDate).toLocaleDateString()}
          </p>
          <p>
            <strong>Created Date:</strong>{" "}
            {new Date(job.createdDate).toLocaleDateString()}
          </p>
        </CardContent>
      </Card>

      <div className="flex justify-end gap-4 mt-10 max-w-3xl mx-auto">
        {authState?.role.toLowerCase() === "recruiter" && (
          <>
            <Button variant="destructive" onClick={handleDelete}>
              <Delete /> Delete
            </Button>
            <Button onClick={() => navigate(`/recruiter/update-job/${jobId}`)}>
              <Plus /> Update
            </Button>
          </>
        )}

        {authState?.role.toLowerCase() === "candidate" && (
          <Button onClick={handleApply}>Apply</Button>
        )}
      </div>
    </div>
  );
};

export default JobDetail;
