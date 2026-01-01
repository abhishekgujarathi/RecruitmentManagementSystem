import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";
import api from "../services/api";
import { toast } from "sonner";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
  CardDescription,
} from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { ArrowLeft, Trash2, Edit } from "lucide-react";
import JobApplicantsList from "../components/recruiter/applicants-list";

const JobDetail = () => {
  const { jobId } = useParams();
  const navigate = useNavigate();
  const { authState } = useAuth();

  const [job, setJob] = useState(null);
  const [loading, setLoading] = useState(true);

  const role = authState?.role?.toLowerCase();
  const isLoggedIn = !!authState?.token;

  // --- FETCH DATA ---
  useEffect(() => {
    const fetchJob = async () => {
      try {
        setLoading(true);
        const res = await api.get(`/Jobs/${jobId}`);
        setJob(res.data);
        console.log(res.data);
      } catch (err) {
        console.error("Failed to fetch job:", err);
        toast.error("Could not load job details.");
      } finally {
        setLoading(false);
      }
    };
    fetchJob();
  }, [jobId]);

  // --- HANDLERS ---
  const handleDelete = async () => {
    if (!window.confirm("Are you sure you want to delete this job?")) return;
    try {
      await api.delete(`/Recruiters/jobs/${jobId}`);
      toast.success("Job deleted successfully!");
      navigate("/recruiter/jobs");
    } catch (err) {
      toast.error("Delete failed.");
    }
  };

  const handleApply = async () => {
    try {
      await api.post(`/Candidate/apply/${jobId}`);
      toast.success("Applied successfully!");
    } catch (err) {
      toast.error(err.response?.data?.message || "Failed to apply.");
    }
  };

  if (loading) return <div className="p-10 text-center">Loading job...</div>;
  if (!job) return <div className="p-10 text-center">Job not found.</div>;

  return (
    <div className="container mx-auto px-4">
      {/* Back Button */}
      <Button variant="ghost" onClick={() => navigate(-1)} className="mb-6">
        <ArrowLeft className="mr-2 h-4 w-4" /> Back
      </Button>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
        {/* job info */}
        <div className="lg:col-span-2 space-y-6">
          <Card>
            <CardHeader>
              <CardTitle className="text-3xl font-bold">
                {job.jobDescription.title}
              </CardTitle>
              <CardDescription className="text-lg">
                {job.jobDescription.location} • {job.jobDescription.jobType}
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-6">
              <div>
                <h3 className="text-lg font-semibold mb-2">Description</h3>
                <p className="text-muted-foreground whitespace-pre-line">
                  {job.jobDescription.details}
                </p>
              </div>
              <div>
                <h3 className="text-lg font-semibold mb-2">Responsibilities</h3>
                <p className="text-muted-foreground whitespace-pre-line">
                  {job.jobDescription.responsibilities ||
                    "Standard duties apply."}
                </p>
              </div>
            </CardContent>
          </Card>
        </div>

        {/* sidebar[right] */}
        <div className="space-y-4">
          <Card>
            <CardHeader>
              <CardTitle className="text-sm font-semibold uppercase tracking-wider text-muted-foreground">
                Job Overview
              </CardTitle>
            </CardHeader>
            <CardContent className="space-y-4">
              <div className="flex justify-between text-sm">
                <span className="text-muted-foreground">Experience:</span>
                <span className="font-medium">
                  {job.jobDescription.minimumExperienceReq} years
                </span>
              </div>
              <div className="flex justify-between text-sm">
                <span className="text-muted-foreground">Deadline:</span>
                <span className="font-medium">
                  {new Date(job.deadlineDate).toLocaleDateString()}
                </span>
              </div>

              <div className="pt-4 border-t">
                {/* unloogged user */}
                {!isLoggedIn && (
                  <div className="space-y-3">
                    <p className="text-xs text-center text-muted-foreground italic">
                      Sign in to apply for this position.
                    </p>
                    <Button
                      className="w-full"
                      onClick={() => navigate("/login")}
                    >
                      Login to Apply
                    </Button>
                  </div>
                )}

                {/* 2. recruiter */}
                {isLoggedIn && role === "recruiter" && (
                  <div className="flex flex-col gap-3">
                    <Button
                      className="w-full"
                      onClick={() => navigate(`/recruiter/update-job/${jobId}`)}
                    >
                      <Edit className="mr-2 h-4 w-4" /> Edit Job
                    </Button>
                    <Button
                      variant="destructive"
                      className="w-full"
                      onClick={handleDelete}
                    >
                      <Trash2 className="mr-2 h-4 w-4" /> Close Posting
                    </Button>
                  </div>
                )}

                {/* candidate */}
                {isLoggedIn &&
                  role === "candidate" &&
                  (job.isApplied ? (
                    <Button variant="ghost" className="w-full" size="lg">
                      Already Applied
                    </Button>
                  ) : (
                    <Button className="w-full" size="lg" onClick={handleApply}>
                      Apply Now
                    </Button>
                  ))}
              </div>
            </CardContent>
          </Card>
        </div>
      </div>
      <div className="container py-4 mt-8 border">
        {isLoggedIn && role === "recruiter" && (
          <JobApplicantsList jobId={jobId} />
        )}
      </div>
    </div>
  );
};

export default JobDetail;
