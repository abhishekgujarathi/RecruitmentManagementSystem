import React, { useState } from "react";
import {
  Card,
  CardHeader,
  CardTitle,
  CardContent,
  CardFooter,
} from "@/components/ui/card";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Button } from "@/components/ui/button";
// import { toast } from "@/components/ui/sonner";
import api from "../../services/api";
import { toast } from "sonner";
import { useAuth } from "../../hooks/useAuth";
import SkillComboBox from "../shared/skillComboBox";
import DefaultReviewer from "./DefaultReviewer";

const CreateJobForm = () => {
  const { authState } = useAuth();

  const [formData, setFormData] = useState({
    title: "",
    details: "",
    typeName: "",
    responsibilities: "",
    location: "",
    minimumExperienceReq: "",
    openingsCount: 1,
    deadlineDate: "",
    skills: [],
  });

  const [loading, setLoading] = useState(false);

  // const [reviewers, setReviewers] = useState([]);
  // const [selectedReviewerId, setSelectedReviewerId] = useState("");

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);

    try {
      await api.post("/Recruiters/job", {
        ...formData,
        minimumExperienceReq: parseInt(formData.minimumExperienceReq || 0),
        openingsCount: parseInt(formData.openingsCount || 1),
        responsibilities: formData.responsibilities?.trim() || null,
        skillIds: formData.skills.map((s) => s.skillId),
      });

      toast("Job created successfully!");
      setFormData({
        title: "",
        details: "",
        typeName: "",
        responsibilities: "",
        location: "",
        minimumExperienceReq: "",
        openingsCount: 1,
        deadlineDate: "",
        skills: [],
      });
    } catch (error) {
      console.error(error);
      toast({
        title: "Failed to create job",
        description: error.response?.data || "Something went wrong.",
        variant: "destructive",
      });
    } finally {
      setLoading(false);
    }
  };

  const handleSkillSelect = (skillId, name) => {
    setFormData((prev) => {
      if (prev.skills.some((s) => s.skillId === skillId)) return prev;
      return {
        ...prev,
        skills: [...prev.skills, { skillId, name }],
      };
    });
  };

  const removeSkill = (skillId) => {
    setFormData((prev) => ({
      ...prev,
      skills: prev.skills.filter((s) => s.skillId !== skillId),
    }));
  };

  const getReviewerList = async () => {
    // fetching list of reviweres
    try {
      if (!authState.employeeRoles.includes("Recruiter")) return;
      const res = await api.get(`/Recruiters/employees/${applicationId}`);
      // console.log("change this");
      setReviewers(res.data);
    } catch (err) {
      console.error("Failed to fetch profile:", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex flex-col justify-center py-10">
      <Card className="w-full max-w-2xl shadow-sm border">
        <CardHeader>
          <CardTitle>Create a New Job</CardTitle>
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

            <div>
              <Label>Required Skills</Label>
              <SkillComboBox
                value={null}
                intialLabel="Add skill"
                onChange={handleSkillSelect}
              />

              {formData.skills.length > 0 && (
                <div className="flex flex-wrap gap-2 mt-3">
                  {formData.skills.map((skill) => (
                    <span
                      key={skill.skillId}
                      className="flex items-center gap-2 px-3 py-1 rounded-full bg-muted text-sm"
                    >
                      {skill.name}
                      <button
                        type="button"
                        className="text-red-500"
                        onClick={() => removeSkill(skill.skillId)}
                      >
                        ×
                      </button>
                    </span>
                  ))}
                </div>
              )}
            </div>

            <CardFooter className="p-0 pt-4">
              <Button type="submit" disabled={loading} className="w-full">
                {loading ? "Creating..." : "Create Job"}
              </Button>
            </CardFooter>
          </form>
        </CardContent>
      </Card>
    </div>
  );
};

export default CreateJobForm;
