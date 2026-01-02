import { BrowserRouter, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./context/AuthContext";
import { Navbar } from "./components/shared/NavBar";

import { ProtectedRoute } from "./guards/PrivateRoute";
import { PublicRoute } from "./guards/PublicRoute";

// Pages
import LoginPage from "./pages/LoginPage";
import SignupPage from "./pages/SignupPage";

import UnauthorizedPage from "./pages/UnauthorizedPage";

import { DashboardLayout } from "./components/shared/layout";

import Jobs from "./pages/Jobs";
import JobDetail from "./pages/JobDetails";

import CandidateSideNav from "./components/candidate/side-nav";
import CandidateDashboard from "./pages/candidate/CandidateDashboard";
import CandidateProfile from "./pages/candidate/CandidateProfile";

// import RecruiterSideNav from "./components/recruiter/side-nav";
import CreateJob from "./pages/recruiter/CreateJob";
import { Toaster } from "sonner";
import UpdateJob from "./pages/recruiter/UpdateJob";
import CandidateProfileUpdate from "./pages/candidate/CandidateProfileUpdate";
import RecruiterCandidateView from "./pages/recruiter/RecruiterCandidateView";

// import NotFoundPage from "./pages/NotFoundPage";
import { pdfjs } from "react-pdf";
import ReviewerSideNav from "./components/reviewer/side-nav";
import AssignedApplications from "./pages/reviewer/AssignedApplications";
import EmployeeDashboard from "./pages/employee/EmployeeDashboard";

import EmployeeSideNav from "./components/employee/side-nav";

pdfjs.GlobalWorkerOptions.workerSrc = new URL(
  "pdfjs-dist/build/pdf.worker.min.mjs",
  import.meta.url
).toString();

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Navbar />
        <Routes>
          {/* public Routes */}
          <Route
            path="/login"
            element={
              <PublicRoute>
                <LoginPage />
              </PublicRoute>
            }
          />
          <Route
            path="/register"
            element={
              <PublicRoute>
                <SignupPage />
              </PublicRoute>
            }
          />

          {/* jobs page */}
          <Route
            path="/jobs"
            element={
              <PublicRoute>
                <Jobs pageHeading={"Our Jobs"} />
              </PublicRoute>
            }
          />

          <Route
            path="/jobs/:jobId"
            element={
              <ProtectedRoute>
                <JobDetail />
              </ProtectedRoute>
            }
          />

          {/* candidate routee */}
          <Route
            path="/candidate"
            element={
              <ProtectedRoute requiredRole="candidate">
                <DashboardLayout leftContent={<CandidateSideNav />} />
              </ProtectedRoute>
            }
          >
            <Route index element={<CandidateDashboard />} /> {/* /candidate */}
            <Route path="dashboard" element={<CandidateDashboard />} />
            <Route path="profile" element={<CandidateProfile />} />
            <Route path="profile/update" element={<CandidateProfileUpdate />} />
            {/* jobsssssss */}
            <Route path="jobs" element={<Jobs pageHeading={"Jobs"} />} />
            <Route path="jobs/:jobId" element={<JobDetail />} />
            {/* <Route path="applied-jobs" element={<AppliedJobs />} /> */}
          </Route>

          {/* recruiter routee */}
          <Route
            path="/employee"
            element={
              <ProtectedRoute>
                <DashboardLayout leftContent={<EmployeeSideNav />} />
              </ProtectedRoute>
            }
          >
            <Route path="dashboard" element={<EmployeeDashboard />} />
            <Route path="jobs" element={<Jobs pageHeading={"Jobs"} />} />
            <Route path="jobs/:jobId" element={<JobDetail />} />
            <Route path="create-job" element={<CreateJob />} />
            <Route path="update-job/:jobId" element={<UpdateJob />} />

            {/* for application */}
            <Route
              path="applications/:applicationId"
              // element={<RtCandidateProfile />}
              element={<RecruiterCandidateView />}
            />
          </Route>

          {/* reviewer routee */}
          <Route
            path="/reviewer"
            element={
              <ProtectedRoute requiredRole="reviewer">
                <DashboardLayout leftContent={<ReviewerSideNav />} />
              </ProtectedRoute>
            }
          >
            <Route path="dashboard" element={<>hlo</>} />
            <Route path="applications" element={<AssignedApplications />} />
          </Route>

          {/* errors */}
          <Route path="/unauthorized" element={<UnauthorizedPage />} />
          <Route
            path="*"
            element={
              <h1 className="flex min-h-svh w-full text-5xl border items-center justify-center p-6 md:p-10">
                NOT FOUND
              </h1>
            }
          />
        </Routes>
        <Toaster />
      </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
