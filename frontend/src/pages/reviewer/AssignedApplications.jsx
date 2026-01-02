import React, { useEffect } from "react";
import api from "../../services/api";

const AssignedApplications = () => {
  useEffect(() => {
    const fetchJobs = async () => {
      try {
        const response = await api.get("/Reviewers/applications");

        // setJobs(response.data);
        console.log(response.data);
      } catch (error) {
        console.error("Failed to fetch jobs:", error);
      } finally {
        setLoading(false);
      }
    };
    fetchJobs();
  }, []);

  return <div>AssignedApplications</div>;
};

export default AssignedApplications;
