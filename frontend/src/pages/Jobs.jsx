import React from "react";
import { JobList } from "../components/shared/jobs-list";

const Jobs = ({ pageHeading }) => {
  console.log("ass");

  return (
    <>
      <div className="flex flex-col min-h-svh w-full items-center justify-center p-6 md:p-10">
        <header className="container px-0 md:px-8 mb-10 md:mb-14 ">
          <h1 className="px-4 text-3xl font-semibold md:text-4xl">
            {pageHeading}
          </h1>
        </header>
        <JobList />
      </div>
    </>
  );
};

export default Jobs;
