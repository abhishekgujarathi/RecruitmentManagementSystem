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

import RecruiterSideNav from "./components/recruiter/side-nav";
import CreateJob from "./pages/recruiter/CreateJob";
import { Toaster } from "sonner";
import UpdateJob from "./pages/recruiter/UpdateJob";
import RecruiterDashboard from "./pages/recruiter/RecruiterDashboard";
import CandidateProfileUpdate from "./pages/candidate/CandidateProfileUpdate";

// import NotFoundPage from "./pages/NotFoundPage";

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
              <ProtectedRoute>
                <Jobs pageHeading={"Our Jobs"} />
              </ProtectedRoute>
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
            {/* <Route path="applied-jobs" element={<AppliedJobs />} /> */}
          </Route>

          {/* recruiter routee */}
          <Route
            path="/recruiter"
            element={
              <ProtectedRoute requiredRole="recruiter">
                <DashboardLayout leftContent={<RecruiterSideNav />} />
              </ProtectedRoute>
            }
          >
            <Route path="dashboard" element={<RecruiterDashboard />} />
            <Route path="jobs" element={<Jobs pageHeading={"Jobs"} />} />
            <Route path="create-job" element={<CreateJob />} />
            <Route path="update-job/:jobId" element={<UpdateJob />} />
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
