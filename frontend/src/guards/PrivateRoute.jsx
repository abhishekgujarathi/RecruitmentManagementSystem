import { Navigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

export const ProtectedRoute = ({
  children,
  requiredUserType,
  requiredEmployeeRole,
}) => {
  const { authState } = useAuth();
  const { token, userType, employeeRoles, isLoading } = authState;

  if (isLoading) return <div>Loading...</div>;

  if (!token) return <Navigate to="/login" replace />;

  // cecking if canidate/emplyee
  if (
    requiredUserType &&
    userType?.toLowerCase() !== requiredUserType.toLowerCase()
  ) {
    return <Navigate to="/unauthorized" replace />;
  }
  // cecking if emplye roles - recruit/inter/review
  if (
    requiredEmployeeRole &&
    !employeeRoles?.some(
      (r) => r.toLowerCase() === requiredEmployeeRole.toLowerCase()
    )
  ) {
    return <Navigate to="/unauthorized" replace />;
  }

  return children;
};
