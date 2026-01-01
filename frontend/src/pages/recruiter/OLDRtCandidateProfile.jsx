import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { useParams } from "react-router-dom";
import { Button } from "@/components/ui/button";

import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";

const RtCandidateProfile = () => {
  const { candidateId } = useParams();

  const [candidateProfile, setCandidateProfile] = useState(null);
  const [loading, setLoading] = useState(true);

  const getCandidateProfile = async () => {
    try {
      const res = await api.get(`Recruiters/candidate/${candidateId}`);
      console.log(res.data);
      setCandidateProfile(res.data);
    } catch (err) {
      console.error("Failed to fetch profile:", err);
    } finally {
      setLoading(false);
    }
  };

  const formatDate = (date) =>
    date ? new Date(date).toLocaleDateString("en-GB") : "N/A";

  useEffect(() => {
    getCandidateProfile();
    console.log(candidateProfile);
  }, []);

  if (loading)
    return <div className="text-center py-10">Loading profile...</div>;
  if (!candidateProfile)
    return <div className="text-center py-10">Profile not found</div>;

  return (
    <main className="grid grid-cols-5 space-x-2">
      {/* left side candidate profile  */}
      <div className="col-span-3 px-4">
        <div className="space-y-2">
          {/* personal */}
          ??? add cv viewer of candidate
          <Card>
            <CardHeader>
              <CardTitle>Personal Details</CardTitle>
            </CardHeader>
            <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-2">
              <p>
                <strong>Name:</strong> {candidateProfile?.fullName || "N/A"}
              </p>
              <p>
                <strong>Location:</strong>{" "}
                {`${candidateProfile?.city}, ${candidateProfile?.country}` ||
                  "N/A"}
              </p>
              <p>
                <strong>Mobile No.:</strong>
                {candidateProfile?.mobileNumber || "N/A"}
              </p>
              <p>
                <strong>Email:</strong> {candidateProfile?.email}
              </p>
              <div className="pt-4 col-span-2 flex justify-center">
                ??? add social links here
              </div>
            </CardContent>
          </Card>
          {/* edu */}
          <Card>
            <CardHeader>
              <CardTitle>Education</CardTitle>
            </CardHeader>
            <CardContent className="space-y-4">
              {candidateProfile.educations?.length > 0 ? (
                candidateProfile.educations.map((edu) => (
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
                    {edu !==
                      candidateProfile.educations[
                        candidateProfile.educations.length - 1
                      ] && <hr className="border-t border-gray-200 my-4" />}
                  </div>
                ))
              ) : (
                <p className="text-gray-500">No education data available.</p>
              )}
            </CardContent>
          </Card>
          {/* exp */}
          <Card>
            <CardHeader>
              <CardTitle>Experience</CardTitle>
            </CardHeader>
            <CardContent className="space-y-4">
              {candidateProfile.experiences?.length > 0 ? (
                candidateProfile.experiences.map((exp, index) => (
                  <div key={exp.experienceId}>
                    <div className="m-0">
                      <div className="col-span-1 md:col-span-1">
                        <strong>Company:</strong> {exp.companyName || "N/A"}
                      </div>
                      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                        <div className="col-span-1 md:col-span-1">
                          <strong>Position:</strong> {exp.position || "N/A"}
                        </div>

                        <div className="col-span-2 md:col-span-1">
                          <strong>Years:</strong> {exp.durationYears ?? "N/A"}
                        </div>
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
                      <strong>Description:</strong>{" "}
                      {exp.jobDescription || "N/A"}
                    </div>

                    {index !== candidateProfile.experiences.length - 1 && (
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
          <Card>
            <CardHeader>
              <CardTitle>Skills</CardTitle>
            </CardHeader>
            <CardContent>
              {candidateProfile.candidateSkills?.length > 0 ? (
                <div className="flex flex-wrap gap-3">
                  {candidateProfile.candidateSkills.map((skill) => (
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
        </div>
      </div>
      {/* right sife recruiter actions */}
      <div className="col-span-2 px-4">
        {/* -change status -assign reviewer -shortlist/reject quick action */}
        <Card>
          <CardHeader>
            <CardTitle>Status</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="grid grid-cols-2 space-y-2">
              <strong className="col-span-1">Application Status:</strong>{" "}
              <span className="text-red-800 col-span-1">{"check status"}</span>
              <Button className="col-span-2">Change Status</Button>
            </div>
          </CardContent>
        </Card>
        <Card>
          <CardHeader>
            <CardTitle>Reviews</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="grid grid-cols-1 space-y-4">
              <div className="grid grid-cols-1 space-y-0 col-span-1">
                <strong className="col-span-1 border-b border-black">
                  reviwer name
                </strong>{" "}
                <span className="col-span-1">
                  review 1 Lorem ipsum dolor sit amet consectetur adipisicing
                  elit. Id, praesentium? Vitae.
                </span>
                <span className="col-span-1">
                  Lorem ipsum dolor sit amet consectetur adipisicing elit.
                  Assumenda, natus.
                </span>
                <span className="col-span-1">review 1</span>
              </div>
              <div className="grid grid-cols-1 space-y-0 col-span-1">
                <strong className="col-span-1 border-b border-black">
                  reviwer name
                </strong>{" "}
                <span className="col-span-1">review 1</span>
                <span className="col-span-1">review 1</span>
                <span className="col-span-1">review 1</span>
              </div>
            </div>
          </CardContent>
        </Card>
      </div>
    </main>
  );
};

export default RtCandidateProfile;
