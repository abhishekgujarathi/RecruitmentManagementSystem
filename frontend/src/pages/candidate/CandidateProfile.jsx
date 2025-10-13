import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import { Button } from "@/components/ui/button";

import { Book, Download } from "lucide-react";

const CandidateProfile = () => {
  const [profile, setProfile] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const res = await api.get("/Candidate/profile");
        setProfile(res.data);
      } catch (err) {
        console.error("Failed to fetch profile:", err);
      } finally {
        setLoading(false);
      }
    };
    fetchProfile();
  }, []);

  if (loading)
    return <div className="text-center py-10">Loading profile...</div>;
  if (!profile)
    return <div className="text-center py-10">Profile not found</div>;

  return (
    <div className="space-y-8">
      {/* personal */}
      <Card className="p-4">
        <CardHeader>
          <CardTitle>Personal Information</CardTitle>
        </CardHeader>
        <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-2">
          <p>
            <strong>Address:</strong> {profile.address || "N/A"}
          </p>
          <p>
            <strong>City:</strong> {profile.city || "N/A"}
          </p>
          <p>
            <strong>State:</strong> {profile.state || "N/A"}
          </p>
          <p>
            <strong>Country:</strong> {profile.country || "N/A"}
          </p>
          <p>
            <strong>Postal Code:</strong> {profile.postalCode || "N/A"}
          </p>
        </CardContent>
      </Card>

      {/* edu */}
      <Card className="p-4">
        <CardHeader>
          <CardTitle>Education</CardTitle>
        </CardHeader>
        <CardContent className="space-y-2">
          {profile.educations?.length > 0 ? (
            profile.educations.map((edu) => (
              <div
                key={edu.educationId}
                className="flex flex-col md:flex-row justify-between border-b py-2 last:border-b-0"
              >
                <span>
                  <strong>Institute:</strong> {edu.instituteName || "N/A"}
                </span>
                <span>
                  <strong>Degree:</strong> {edu.degreeType || "N/A"}
                </span>
                <span>
                  <strong>Field:</strong> {edu.fieldOfStudy || "N/A"}
                </span>
                <span>
                  <strong>Score:</strong> {edu.percentageScore ?? "N/A"}
                </span>
                <span>
                  <strong>Duration:</strong>{" "}
                  {new Date(edu.startDate).toLocaleDateString()} -{" "}
                  {edu.isCurrent
                    ? "Present"
                    : new Date(edu.endDate).toLocaleDateString()}
                </span>
              </div>
            ))
          ) : (
            <p>No education data available.</p>
          )}
        </CardContent>
      </Card>

      {/* exp */}
      <Card className="p-4">
        <CardHeader>
          <CardTitle>Experience</CardTitle>
        </CardHeader>
        <CardContent className="space-y-2">
          {profile.experiences?.length > 0 ? (
            profile.experiences.map((exp) => (
              <div
                key={exp.experienceId}
                className="flex flex-col md:flex-row justify-between border-b py-2 last:border-b-0"
              >
                <span>
                  <strong>Company:</strong> {exp.companyName || "N/A"}
                </span>
                <span>
                  <strong>Position:</strong> {exp.position || "N/A"}
                </span>
                <span>
                  <strong>Years:</strong> {exp.durationYears ?? "N/A"}
                </span>
                <span>
                  <strong>Duration:</strong>{" "}
                  {new Date(exp.startDate).toLocaleDateString()} -{" "}
                  {exp.isCurrent
                    ? "Present"
                    : new Date(exp.endDate).toLocaleDateString()}
                </span>
                <span>
                  <strong>Description:</strong> {exp.jobDescription || "N/A"}
                </span>
              </div>
            ))
          ) : (
            <p>No experience data available.</p>
          )}
        </CardContent>
      </Card>

      {/* skill */}
      <Card className="p-4">
        <CardHeader>
          <CardTitle>Skills</CardTitle>
        </CardHeader>
        <CardContent className="flex flex-wrap gap-2">
          {profile.candidateSkills?.length > 0 ? (
            profile.candidateSkills.map((skill) => (
              <span
                key={skill.candidateSkillId}
                className="bg-gray-100 text-sm rounded px-3 py-1"
              >
                Skill ID: {skill.skillId} | Exp: {skill.experienceYears ?? 0}{" "}
                yrs | Level: {skill.proficiencyLevel || "N/A"}
              </span>
            ))
          ) : (
            <p>No skills listed.</p>
          )}
        </CardContent>
      </Card>

      {/* social */}
      <Card className="p-4">
        <CardHeader>
          <CardTitle>Social Links</CardTitle>
        </CardHeader>
        <CardContent className="flex flex-col gap-1">
          {profile.candidateSocials?.length > 0 ? (
            profile.candidateSocials.map((social) => (
              <a
                key={social.candidateSocialsId}
                href={social.link || "#"}
                className="text-blue-500 underline text-sm"
              >
                Social ID: {social.socialPlatformId}
              </a>
            ))
          ) : (
            <p>No social links added.</p>
          )}
        </CardContent>
      </Card>

      {/* CV */}
      <Card className="p-4">
        <CardHeader>
          <CardTitle>CVs / Documents</CardTitle>
        </CardHeader>
        <CardContent className="flex flex-col gap-2">
          {profile.cvStorages?.length > 0 ? (
            profile.cvStorages.map((cv) => (
              <div key={cv.cvStorageId} className="flex items-center gap-2">
                <span>
                  {cv.fileName || "Unnamed"} ({cv.fileSize} KB)
                </span>
                {cv.url && (
                  <Button variant="outline" asChild size="sm">
                    <a href={cv.url} target="_blank" rel="noopener noreferrer">
                      Download
                    </a>
                  </Button>
                )}
              </div>
            ))
          ) : (
            <p>No CV uploaded.</p>
          )}
        </CardContent>
      </Card>
    </div>
  );
};

export default CandidateProfile;
