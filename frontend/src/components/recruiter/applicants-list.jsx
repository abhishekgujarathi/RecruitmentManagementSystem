import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Separator } from "@/components/ui/separator";
import { Button } from "@/components/ui/button";
import { ArrowLeft } from "lucide-react";
import api from "@/services/api";
import { useAuth } from "../../hooks/useAuth";

const JobApplicantsList = () => {
  const { jobId } = useParams();
  const [applicants, setApplicants] = useState([]);
  const [loading, setLoading] = useState(true);

  const { authState } = useAuth();

  useEffect(() => {
    if (!authState?.employeeRoles || !authState.employeeRoles) return;

    const fetchApplicants = async () => {
      try {
        console.log("fetching");
        const response = await api.get(`Applications/jobs/${jobId}`);
        setApplicants(response.data);
        console.log("applicants list -", response.data);
      } catch (error) {
        console.error("Failed to fetch applicants:", error);
      } finally {
        setLoading(false);
      }
    };

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

  return (
    <section>
      <div className="container px-0 md:px-4">
        <div className="flex flex-col">
          <div className="flex items-center gap-3 mb-6">
            <h1 className="text-2xl font-semibold">Applicants</h1>
          </div>

          {applicants.length === 0 ? (
            <p className="text-center text-muted-foreground py-10">
              No applicants yet for this job.
            </p>
          ) : (
            applicants.map((applicant) => (
              <React.Fragment key={applicant.jobApplicationId}>
                <div className="grid items-center gap-4 px-4 py-5 md:grid-cols-6">
                  <div className="col-span-2 flex flex-col gap-1">
                    <h2 className="font-semibold text-lg">
                      {applicant.candidateName}
                    </h2>
                    <p className="text-muted-foreground text-sm">
                      {applicant.email}
                    </p>
                  </div>

                  <p className="text-sm md:col-span-2">
                    Applied on:{" "}
                    {new Date(applicant.applicationDate).toLocaleDateString()}
                  </p>

                  <p className="text-sm font-medium capitalize">
                    Status: {applicant.currentStatus}
                  </p>
                  <Button asChild>
                    <a
                      href={`/employee/applications/${applicant.applicationId}`}
                    >
                      View Profile
                    </a>
                  </Button>
                </div>
                <Separator />
              </React.Fragment>
            ))
          )}
        </div>
      </div>
    </section>
  );
};

export default JobApplicantsList;
