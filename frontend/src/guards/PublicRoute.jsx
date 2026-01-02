import { Navigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

export const PublicRoute = ({ children }) => {
  const { authState } = useAuth();

  if (authState.token) {
    const role = authState.role?.toLowerCase();
    if (role === "candidate")
      return <Navigate to="/candidate/dashboard" replace />;
    if (role === "recruiter")
      return <Navigate to="/recruiter/dashboard" replace />;
    if (role === "reviewer")
      return <Navigate to="/reviewer/dashboard" replace />;
    if (role === "interviewer")
      return <Navigate to="/interviewer/dashboard" replace />;
    if (role === "admin") return <Navigate to="/admin/dashboard" replace />;
    return <Navigate to="/" replace />;
  }

  return children;
};
