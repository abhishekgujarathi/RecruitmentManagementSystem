import { Link, useLocation } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";

const EmployeeSideNav = () => {
  const location = useLocation();
  const { authState } = useAuth();
  const { employeeRoles } = authState;

  const menu = [];
  if (employeeRoles.includes("Recruiter")) {
    menu.push(
      // Recruiter specific
      { title: "Jobs", path: "/employee/jobs" },
      { title: "New Job", path: "/employee/create-job" }
    );
  }

  menu.push(
    // common for all employees
    { title: "Assigned Applications", path: "/employee/applications" },
    { title: "My Reviews", path: "/employee/reviews" },
    { title: "Notifications", path: "/employee/notifications" },
    { title: "Profile", path: "/employee/profile" }
  );

  return (
    <nav className="bg-gray-50 p-4 rounded shadow-md h-full max-h-fit sticky top-20">
      <ul className="flex flex-col gap-2">
        {menu.map((item) => (
          <li key={item.title}>
            <Link
              to={item.path}
              className={`block p-2 rounded hover:bg-gray-200 ${
                location.pathname === item.path
                  ? "bg-gray-200 font-semibold"
                  : ""
              }`}
            >
              {item.title}
            </Link>
          </li>
        ))}
      </ul>
    </nav>
  );
};

export default EmployeeSideNav;
