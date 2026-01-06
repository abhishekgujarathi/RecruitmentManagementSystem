import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import ApplicantsTable from "./ApplicantsTable";
import api from "@/services/api";
import { useAuth } from "../../hooks/useAuth";

const STAGES = [
  "Applied",
  "UnderReview",
  "Shortlisted",
  "TestScheduled",
  "TestPassed",
  "InterviewScheduled",
  "InterviewCompleted",
  "Rejected",
  "Hired",
  "OnHold",
];

const TO_STAGE = [
  { value: "UnderReview", name: "Under Review" },
  { value: "Shortlisted", name: "Shortlisted" },
  { value: "TestScheduled", name: "Test Scheduled" },
  { value: "TestPassed", name: "Test Passed" },
  { value: "InterviewScheduled", name: "Interview Scheduled" },
  { value: "InterviewCompleted", name: "Interview Passed" },
  { value: "Hired", name: "Hired" },
  { value: "OnHold", name: "On Hold" },
];

const JobApplicantsList = () => {
  const { jobId } = useParams();
  const [applicants, setApplicants] = useState([]);
  const [loading, setLoading] = useState(true);

  const { authState } = useAuth();

  // get list of alll applicants
  const fetchApplicants = async () => {
    try {
      const response = await api.get(`Applications/jobs/${jobId}`);
      setApplicants(response.data);
    } catch (error) {
      console.error("Failed to fetch applicants:", error);
    } finally {
      setLoading(false);
    }
  };

  // handle bulk or single status change per table
  const handleStatusChange = async (appIds, newStatus) => {
    try {
      await api.patch(`Applications/bulk/status`, {
        applicationIds: appIds,
        newStatus: newStatus,
        note: newStatus === "OnHold" ? "no notes " : null,
      });

      await fetchApplicants();
    } catch (error) {
      console.error("Failed to update statuses:", error);
    }
  };

  useEffect(() => {
    if (!authState?.employeeRoles?.includes("Recruiter")) return;

    fetchApplicants();
  }, [jobId, authState]);

  if (
    authState?.role !== "Employee" ||
    !authState.employeeRoles?.includes("Recruiter")
  ) {
    return null;
  }

  if (loading) {
    return <div className="text-center py-10">Loading applicants...</div>;
  }

  if (applicants.length === 0) {
    return (
      <p className="text-center text-muted-foreground py-10">
        No applicants yet for this job.
      </p>
    );
  }

  return (
    <div className="px-4 space-y-8">
      {STAGES.map((stage) => {
        const stageApplicants = applicants.filter(
          (a) => a.currentStatus === stage
        );

        // return nothin if there are no candidate on that stage
        if (stageApplicants.length === 0) return <></>;

        const nextStage = TO_STAGE[STAGES.indexOf(stage)];
        return (
          <div key={stage}>
            <h2 className="text-xl font-semibold mb-2">{stage}</h2>
            <ApplicantsTable
              applicants={stageApplicants}
              nextStage={nextStage}
              onBulkStatusChange={handleStatusChange}
            />
          </div>
        );
      })}
    </div>
  );
};

export default JobApplicantsList;
