import { ArrowRight } from "lucide-react";
import React, { useEffect, useState } from "react";
import { Button } from "@/components/ui/button";
import { Separator } from "@/components/ui/separator";
import axios from "axios";
import api from "../../services/api";

const JobList = ({ heading }) => {
  const [jobs, setJobs] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchJobs = async () => {
      try {
        const response = await api.get("/Jobs");
        setJobs(response.data);
      } catch (error) {
        console.error("Failed to fetch jobs:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchJobs();
  }, []);

  if (loading) {
    return <div className="text-center py-10">Loading jobs...</div>;
  }

  return (
    <section>
      <div className="container px-0 md:px-8">
        <div className="flex flex-col">
          <Separator />
          {jobs.map((job, index) => (
            <React.Fragment key={job.jobId}>
              <div className="grid items-center gap-4 px-4 py-5 md:grid-cols-4">
                <div className="order-2 flex items-center gap-2 md:order-none">
                  <div className="flex flex-col gap-1">
                    <h1 className="font-semibold text-xl">
                      {job.jobDescription.title}
                    </h1>
                    <p className="text-muted-foreground text-sm">
                      {job.jobDescription.location} |{" "}
                      {job.jobDescription.jobType}
                    </p>
                  </div>
                </div>
                <p className="order-1 text-sm font-semibold md:order-none md:col-span-2">
                  {job.jobDescription.details.length > 100
                    ? job.jobDescription.details.slice(0, 100) + "..."
                    : job.jobDescription.details}
                </p>

                <Button variant="outline" asChild>
                  <a
                    className="order-3 ml-auto w-fit gap-2 md:order-none"
                    href={`/jobs/${job.jobId}`}
                  >
                    <span>View Job</span>
                    <ArrowRight className="h-4 w-4" />
                  </a>
                </Button>
              </div>
              <Separator />
            </React.Fragment>
          ))}
        </div>
      </div>
    </section>
  );
};

export { JobList };
