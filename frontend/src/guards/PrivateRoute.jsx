import { Navigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

export const ProtectedRoute = ({ children, requiredRole }) => {
  const { authState } = useAuth();
  if (authState.isLoading) {
    return <div>Loading...</div>;
  }

  if (!authState?.token) return <Navigate to="/login" replace />;

  if (
    requiredRole &&
    authState.role?.toLowerCase() !== requiredRole.toLowerCase()
  ) {
    return <Navigate to="/unauthorized" replace />;
  }

  return children;
};
