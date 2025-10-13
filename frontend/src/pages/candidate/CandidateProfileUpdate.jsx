import React, { useEffect, useState } from "react";
import api from "../../services/api";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
  CardFooter,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Button } from "@/components/ui/button";
import { toast } from "sonner";
import { useNavigate } from "react-router-dom";

const CandidateProfileUpdate = () => {
  const [formData, setFormData] = useState({
    address: "",
    city: "",
    state: "",
    country: "",
    postalCode: "",
    educations: [
      {
        educationId: "",
        instituteName: "",
        degreeType: "",
        fieldOfStudy: "",
        percentageScore: "",
        startDate: "",
        endDate: "",
        isCurrent: false,
      },
    ],
    experiences: [
      {
        experienceId: "",
        companyName: "",
        position: "",
        durationYears: "",
        startDate: "",
        endDate: "",
        isCurrent: false,
        jobDescription: "",
      },
    ],
    candidateSocials: [
      {
        candidateSocialsId: "",
        socialPlatformId: "",
        link: "",
      },
    ],
    candidateSkills: [
      {
        candidateSkillId: "",
        skillId: "",
        experienceYears: "",
        proficiencyLevel: "",
      },
    ],
  });

  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const res = await api.get("/Candidate/profile");
        setFormData(res.data);
      } catch (err) {
        console.error("Failed to fetch profile:", err);
      }
    };
    fetchProfile();
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleNestedChange = (section, index, e) => {
    const { name, value } = e.target;
    setFormData((prev) => {
      const updated = [...prev[section]];
      updated[index][name] = value;
      return { ...prev, [section]: updated };
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);

    try {
      await api.patch("/Candidate/profile", formData);
      toast.success("Profile updated successfully!");
      navigate("/candidate/profile");
    } catch (error) {
      console.error(error);
      toast.error("Failed to update profile");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex justify-center py-10">
      <Card className="w-full max-w-3xl shadow-sm border">
        <CardHeader>
          <CardTitle>Update Candidate Profile</CardTitle>
        </CardHeader>

        <CardContent>
          <form onSubmit={handleSubmit} className="space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div>
                <Label>Address</Label>
                <Textarea
                  name="address"
                  value={formData.address}
                  onChange={handleChange}
                  rows={2}
                />
              </div>
              <div>
                <Label>City</Label>
                <Input
                  name="city"
                  value={formData.city}
                  onChange={handleChange}
                />
              </div>
              <div>
                <Label>State</Label>
                <Input
                  name="state"
                  value={formData.state}
                  onChange={handleChange}
                />
              </div>
              <div>
                <Label>Country</Label>
                <Input
                  name="country"
                  value={formData.country}
                  onChange={handleChange}
                />
              </div>
              <div>
                <Label>Postal Code</Label>
                <Input
                  name="postalCode"
                  value={formData.postalCode}
                  onChange={handleChange}
                />
              </div>
            </div>

            <div>
              <Label>Education</Label>
              {formData.educations.map((edu, i) => (
                <div
                  key={i}
                  className="grid grid-cols-1 md:grid-cols-2 gap-4 border p-3 rounded-md mt-2"
                >
                  <Input
                    name="instituteName"
                    value={edu.instituteName}
                    onChange={(e) => handleNestedChange("educations", i, e)}
                    placeholder="Institute Name"
                  />
                  <Input
                    name="degreeType"
                    value={edu.degreeType}
                    onChange={(e) => handleNestedChange("educations", i, e)}
                    placeholder="Degree Type"
                  />
                  <Input
                    name="fieldOfStudy"
                    value={edu.fieldOfStudy}
                    onChange={(e) => handleNestedChange("educations", i, e)}
                    placeholder="Field of Study"
                  />
                  <Input
                    name="percentageScore"
                    value={edu.percentageScore}
                    onChange={(e) => handleNestedChange("educations", i, e)}
                    placeholder="Score"
                  />
                </div>
              ))}
            </div>

            <div>
              <Label>Experience</Label>
              {formData.experiences.map((exp, i) => (
                <div
                  key={i}
                  className="grid grid-cols-1 md:grid-cols-2 gap-4 border p-3 rounded-md mt-2"
                >
                  <Input
                    name="companyName"
                    value={exp.companyName}
                    onChange={(e) => handleNestedChange("experiences", i, e)}
                    placeholder="Company Name"
                  />
                  <Input
                    name="position"
                    value={exp.position}
                    onChange={(e) => handleNestedChange("experiences", i, e)}
                    placeholder="Position"
                  />
                  <Textarea
                    name="jobDescription"
                    value={exp.jobDescription}
                    onChange={(e) => handleNestedChange("experiences", i, e)}
                    placeholder="Job Description"
                  />
                </div>
              ))}
            </div>

            <div>
              <Label>Skills</Label>
              {formData.candidateSkills.map((skill, i) => (
                <div
                  key={i}
                  className="grid grid-cols-3 gap-4 border p-3 rounded-md mt-2"
                >
                  <Input
                    name="skillId"
                    value={skill.skillId}
                    onChange={(e) =>
                      handleNestedChange("candidateSkills", i, e)
                    }
                    placeholder="Skill ID"
                  />
                  <Input
                    name="experienceYears"
                    value={skill.experienceYears}
                    onChange={(e) =>
                      handleNestedChange("candidateSkills", i, e)
                    }
                    placeholder="Years"
                  />
                  <Input
                    name="proficiencyLevel"
                    value={skill.proficiencyLevel}
                    onChange={(e) =>
                      handleNestedChange("candidateSkills", i, e)
                    }
                    placeholder="Proficiency Level"
                  />
                </div>
              ))}
            </div>

            <div>
              <Label>Social Links</Label>
              {formData.candidateSocials.map((social, i) => (
                <div
                  key={i}
                  className="grid grid-cols-2 gap-4 border p-3 rounded-md mt-2"
                >
                  <Input
                    name="socialPlatformId"
                    value={social.socialPlatformId}
                    onChange={(e) =>
                      handleNestedChange("candidateSocials", i, e)
                    }
                    placeholder="Platform ID"
                  />
                  <Input
                    name="link"
                    value={social.link}
                    onChange={(e) =>
                      handleNestedChange("candidateSocials", i, e)
                    }
                    placeholder="Profile Link"
                  />
                </div>
              ))}
            </div>

            <CardFooter className="p-0 pt-4 flex gap-3">
              <Button type="submit" disabled={loading} className="w-full">
                {loading ? "Updating..." : "Update Profile"}
              </Button>
              <Button
                type="button"
                variant="outline"
                disabled={loading}
                className="w-full"
                onClick={() => navigate("/candidate/profile")}
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

export default CandidateProfileUpdate;
