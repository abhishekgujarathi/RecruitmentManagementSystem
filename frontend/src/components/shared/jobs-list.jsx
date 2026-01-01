import { ArrowRight } from "lucide-react";
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom"; // Use Link for internal routing
import { Button } from "@/components/ui/button";
import { Separator } from "@/components/ui/separator";
import { useAuth } from "@/hooks/useAuth"; // Import your auth hook
import api from "../../services/api";

const JobList = ({ heading }) => {
  const [jobs, setJobs] = useState([]);
  const [loading, setLoading] = useState(true);
  const { authState } = useAuth(); // Get auth state

  useEffect(() => {
    const fetchJobs = async () => {
      try {
        const response = await api.get("/Jobs");
        setJobs(response.data);
        console.log(response.data);
      } catch (error) {
        console.error("Failed to fetch jobs:", error);
      } finally {
        setLoading(false);
      }
    };
    fetchJobs();
  }, []);

  // --- DYNAMIC PATH LOGIC ---
  const getJobDetailPath = (jobId) => {
    const role = authState?.role?.toLowerCase();

    if (role === "recruiter") {
      return `/recruiter/jobs/${jobId}`;
    }
    if (role === "candidate") {
      return `/candidate/jobs/${jobId}`;
    }
    // Default path for unlogged users/guests
    return `/jobs/${jobId}`;
  };

  if (loading) {
    return (
      <div className="text-center py-10 text-muted-foreground">
        Loading jobs...
      </div>
    );
  }

  return (
    <section>
      <div className="container px-0 md:px-8">
        <div className="flex flex-col">
          {heading && (
            <h2 className="text-2xl font-bold mb-4 px-4">{heading}</h2>
          )}
          <Separator />

          {jobs.length === 0 ? (
            <div className="p-10 text-center text-muted-foreground">
              No jobs available at the moment.
            </div>
          ) : (
            jobs.map((job) => (
              <React.Fragment key={job.jobId}>
                <div className="grid items-center gap-4 px-4 py-5 md:grid-cols-4 hover:bg-accent/50 transition-colors">
                  {/* Title & Location */}
                  <div className="order-2 flex items-center gap-2 md:order-none">
                    <div className="flex flex-col gap-1">
                      <h3 className="font-semibold text-xl">
                        {job.jobDescription.title}
                      </h3>
                      <p className="text-muted-foreground text-sm">
                        {job.jobDescription.location} •{" "}
                        {job.jobDescription.jobType}
                      </p>
                    </div>
                  </div>

                  {/* Snippet */}
                  <p className="order-1 text-sm text-muted-foreground md:order-none md:col-span-2 line-clamp-2">
                    {job.jobDescription.details}
                  </p>

                  {/* Dynamic Button */}
                  <Button variant="outline" asChild>
                    <Link
                      className="order-3 ml-auto w-fit gap-2 md:order-none"
                      to={getJobDetailPath(job.jobId)}
                    >
                      <span>View Job</span>
                      <ArrowRight className="h-4 w-4" />
                    </Link>
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

export { JobList };
