import React from "react";
import { Outlet } from "react-router-dom";

const DashboardLayout = ({ leftContent, rightContent }) => {
  return (
    <section className="py-16 md:py-32 min-h-svh w-full">
      <div className="container mx-auto flex flex-col md:flex-row gap-8">
        <aside className="w-full md:w-2/9 lg:w-2/9">{leftContent}</aside>
        <main className="w-full md:w-7/9 lg:w-7/9">
          <React.Suspense fallback={<div>Loading...</div>}>
            <Outlet />
          </React.Suspense>
        </main>
      </div>
    </section>
  );
};
export { DashboardLayout };
