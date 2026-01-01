import React, { useEffect, useState } from "react";
import {
  Card,
  CardHeader,
  CardTitle,
  CardContent,
  CardFooter,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Button } from "@/components/ui/button";
import { toast } from "sonner";
import api from "../../services/api";
import { useNavigate, useParams } from "react-router-dom";

const UpdateJobForm = () => {
  const { jobId } = useParams();
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    title: "",
    details: "",
    typeName: "",
    responsibilities: "",
    location: "",
    minimumExperienceReq: "",
    openingsCount: 1,
    deadlineDate: "",
  });
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchJob = async () => {
      try {
        const res = await api.get(`/Jobs/${jobId}`);
        const job = res.data.jobDescription || res.data;
        setFormData({
          title: job.title || "",
          details: job.details || "",
          typeName: job.jobType || job.typeName || "",
          responsibilities: job.responsibilities || "",
          location: job.location || "",
          minimumExperienceReq: job.minimumExperienceReq || "",
          openingsCount: res.data.openingsCount || 1,
          deadlineDate: res.data.deadlineDate
            ? new Date(res.data.deadlineDate).toISOString().split("T")[0]
            : "",
        });
      } catch (error) {
        console.error("Failed to fetch job:", error);
        toast.error("Failed to load job details");
      }
    };
    fetchJob();
  }, [jobId]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      await api.patch(`/Recruiters/jobs/${jobId}`, {
        ...formData,
        minimumExperienceReq: parseInt(formData.minimumExperienceReq || 0),
        openingsCount: parseInt(formData.openingsCount || 1),
        responsibilities: formData.responsibilities?.trim() || null,
      });
      toast.success("Job updated successfully!");
      navigate(`/recruiter/jobs/${jobId}`);
    } catch (error) {
      console.error("Failed to update job:", error);
      toast.error(error.response?.data?.message || "Failed to update job");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex justify-center py-10">
      <Card className="w-full max-w-2xl shadow-sm border">
        <CardHeader>
          <CardTitle>Update Job</CardTitle>
        </CardHeader>
        <CardContent>
          <form onSubmit={handleSubmit} className="space-y-4">
            <div>
              <Label htmlFor="title">Job Title</Label>
              <Input
                id="title"
                name="title"
                value={formData.title}
                onChange={handleChange}
                required
              />
            </div>

            <div>
              <Label htmlFor="details">Job Details</Label>
              <Textarea
                id="details"
                name="details"
                value={formData.details}
                onChange={handleChange}
                rows={4}
              />
            </div>

            <div>
              <Label htmlFor="typeName">Job Type</Label>
              <Input
                id="typeName"
                name="typeName"
                value={formData.typeName}
                onChange={handleChange}
                placeholder="e.g. Full-time, Part-time"
              />
            </div>

            <div>
              <Label htmlFor="responsibilities">Responsibilities</Label>
              <Textarea
                id="responsibilities"
                name="responsibilities"
                value={formData.responsibilities}
                onChange={handleChange}
                rows={3}
              />
            </div>

            <div>
              <Label htmlFor="location">Location</Label>
              <Input
                id="location"
                name="location"
                value={formData.location}
                onChange={handleChange}
                placeholder="e.g. Remote, Mumbai"
              />
            </div>

            <div className="grid grid-cols-2 gap-4">
              <div>
                <Label htmlFor="minimumExperienceReq">
                  Min Experience (years)
                </Label>
                <Input
                  id="minimumExperienceReq"
                  name="minimumExperienceReq"
                  type="number"
                  min="0"
                  value={formData.minimumExperienceReq}
                  onChange={handleChange}
                />
              </div>

              <div>
                <Label htmlFor="openingsCount">Openings</Label>
                <Input
                  id="openingsCount"
                  name="openingsCount"
                  type="number"
                  min="1"
                  value={formData.openingsCount}
                  onChange={handleChange}
                />
              </div>
            </div>

            <div>
              <Label htmlFor="deadlineDate">Application Deadline</Label>
              <Input
                id="deadlineDate"
                name="deadlineDate"
                type="date"
                value={formData.deadlineDate}
                onChange={handleChange}
              />
            </div>

            <CardFooter className="p-0 pt-4 flex flex-col gap-3">
              <Button type="submit" disabled={loading} className="w-full">
                {loading ? "Updating..." : "Update Job"}
              </Button>
              <Button
                type="button"
                variant="outline"
                disabled={loading}
                className="w-full"
                onClick={() => navigate(`/recruiter/jobs/${jobId}`)}
              >
                Cancel
              </Button>
            </CardFooter>
          </form>
        </CardContent>
      </Card>
    </div>
  );
};

export default UpdateJobForm;
