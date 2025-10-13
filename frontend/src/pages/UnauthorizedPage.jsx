import { Link } from "react-router-dom";

export default function UnauthorizedPage() {
  return (
    <div className="flex flex-col items-center text-red-600 justify-center min-h-screen">
      <h1 className="text-4xl font-bold">403</h1>
      <p className="text-xl mt-2">Unauthorized Access</p>
    </div>
  );
}
