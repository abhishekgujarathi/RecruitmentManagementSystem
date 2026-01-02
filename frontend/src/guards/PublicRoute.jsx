import { Navigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

export const PublicRoute = ({ children }) => {
  const { authState } = useAuth();

  if (authState.token) {
    const role = authState.role?.toLowerCase();
    if (role === "candidate")
      return <Navigate to="/candidate/dashboard" replace />;
    // changed everywhere to use employeee
    if (role === "employee")
      return <Navigate to="/employee/dashboard" replace />;
    return <Navigate to="/" replace />;
  }

  return children;
};
