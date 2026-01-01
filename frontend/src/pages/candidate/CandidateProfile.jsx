import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import CVSection from "../../components/candidate/CVSection";

const formatDate = (date) =>
  date ? new Date(date).toLocaleDateString("en-GB") : "N/A";

const CandidateProfile = () => {
  const [profile, setProfile] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const res = await api.get("/Candidate/profile");
        console.log("Profile -", res.data);
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
          <CardTitle>Personal Details</CardTitle>
        </CardHeader>
        <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-2">
          <p>
            <strong>First Name:</strong> {profile.userDetails.fname || "N/A"}
          </p>
          <p>
            <strong>Last Name:</strong> {profile.userDetails.lname || "N/A"}
          </p>
          <p>
            <strong>D.O.B.:</strong> {formatDate(profile.userDetails?.dob)}
          </p>
          <p>
            <strong>Gender:</strong> {profile.userDetails.gender || "N/A"}
          </p>
          <p>
            <strong>Email:</strong> {profile.userDetails?.email}
          </p>
          <p>
            <strong>Mobile No.:</strong>
            {profile.userDetails.mobileNumber || "N/A"}
          </p>
        </CardContent>
      </Card>
      {/* location */}
      <Card className="p-4">
        <CardHeader>
          <CardTitle>Location Details</CardTitle>
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
        <CardContent className="space-y-4">
          {profile.educations?.length > 0 ? (
            profile.educations.map((edu) => (
              <div key={edu.educationId} className="m-0">
                <div className="grid grid-cols-1 gap-4 mb-2">
                  <div>
                    <span className="font-semibold">Institute:</span>{" "}
                    <span>{edu.instituteName || "N/A"}</span>
                  </div>
                </div>

                <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mb-2">
                  <div>
                    <span className="font-semibold">Degree:</span>{" "}
                    <span>{edu.degreeType || "N/A"}</span>
                  </div>
                  <div>
                    <span className="font-semibold">Field:</span>{" "}
                    <span>{edu.fieldOfStudy || "N/A"}</span>
                  </div>
                  <div>
                    <span className="font-semibold">Score:</span>{" "}
                    <span>{edu.percentageScore ?? "N/A"}</span>
                  </div>
                </div>

                <div>
                  <span className="font-semibold">Duration:</span>{" "}
                  <span>
                    {new Date(edu.startDate).toLocaleDateString()} -{" "}
                    {edu.isCurrent
                      ? "Present"
                      : new Date(edu.endDate).toLocaleDateString()}
                  </span>
                </div>
                {edu !== profile.educations[profile.educations.length - 1] && (
                  <hr className="border-t border-gray-200 my-4" />
                )}
              </div>
            ))
          ) : (
            <p className="text-gray-500">No education data available.</p>
          )}
        </CardContent>
      </Card>

      {/* exp */}
      <Card className="p-4">
        <CardHeader>
          <CardTitle>Experience</CardTitle>
        </CardHeader>
        <CardContent className="space-y-4">
          {profile.experiences?.length > 0 ? (
            profile.experiences.map((exp, index) => (
              <div key={exp.experienceId}>
                <div className="m-0">
                  <div className="grid grid-cols-1 gap-4 mb-2">
                    <div className="col-span-2 md:col-span-1">
                      <strong>Company:</strong> {exp.companyName || "N/A"}
                    </div>
                  </div>

                  <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mb-2">
                    <div className="col-span-2 md:col-span-1">
                      <strong>Position:</strong> {exp.position || "N/A"}
                    </div>
                  </div>
                  <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mb-2">
                    <div className="col-span-2 md:col-span-1">
                      <strong>Years:</strong> {exp.durationYears ?? "N/A"}
                    </div>
                    <div className="col-span-2 md:col-span-1">
                      <strong>Duration:</strong>{" "}
                      {new Date(exp.startDate).toLocaleDateString()} -{" "}
                      {exp.isCurrent
                        ? "Present"
                        : new Date(exp.endDate).toLocaleDateString()}
                    </div>
                  </div>

                  <div className="col-span-2 mb-2">
                    <strong>Description:</strong> {exp.jobDescription || "N/A"}
                  </div>
                </div>

                {index !== profile.experiences.length - 1 && (
                  <hr className="border-t border-gray-200 my-4" />
                )}
              </div>
            ))
          ) : (
            <p className="text-gray-500">No experience data available.</p>
          )}
        </CardContent>
      </Card>

      {/* skill */}
      <Card className="p-4">
        <CardHeader>
          <CardTitle>Skills</CardTitle>
        </CardHeader>

        <CardContent>
          {profile.candidateSkills?.length > 0 ? (
            <div className="flex flex-wrap gap-3">
              {profile.candidateSkills.map((skill) => (
                <div
                  key={skill.candidateSkillId}
                  className="flex items-center gap-2 bg-gray-100 border border-gray-200 px-4 py-2 rounded-xl shadow-sm hover:shadow-md transition"
                >
                  <span className="font-semibold text-gray-800">
                    {skill.name || "Unnamed Skill"}
                  </span>

                  <span className="text-gray-400">•</span>

                  <span className="text-gray-600 text-sm">
                    {skill.experienceYears ?? 0} yrs
                  </span>

                  <span className="text-gray-400">•</span>

                  <span className="text-gray-600">
                    {skill.proficiencyLevel || "Level N/A"}
                  </span>
                </div>
              ))}
            </div>
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
      <CVSection profile={profile} />
    </div>
  );
};

export default CandidateProfile;
