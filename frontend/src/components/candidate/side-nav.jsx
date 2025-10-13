import React from "react";
import { Link, useLocation } from "react-router-dom";

const CandidateSideNav = () => {
  const location = useLocation();

  const menu = [
    { title: "Profile", path: "/candidate/profile" },
    { title: "Update Profile", path: "/candidate/profile/update" },
    // ??? { title: "Applied Jobs", path: "/candidate/applied-jobs" },
    { title: "Jobs", path: "/jobs" },
  ];

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

export default CandidateSideNav;
