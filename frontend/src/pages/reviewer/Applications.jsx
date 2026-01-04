import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { useAuth } from "../../hooks/useAuth";
import { Separator } from "@/components/ui/separator";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
  CardDescription,
} from "@/components/ui/card";

const Applications = () => {
  const { authState } = useAuth();

  const [applicationList, setApplicationList] = useState([]);
  const [loading, setLoading] = useState([]);

  useEffect(() => {
    const fetchMyApplicants = async () => {
      try {
        const response = await api.get("Applications/assigned");

        setApplicationList(response.data);
        console.log("appli-", response.data);
      } catch (error) {
        console.error("Failed to fetch jobs:", error);
      } finally {
        setLoading(false);
      }
    };
    fetchMyApplicants();
  }, []);

  if (authState?.role !== "Employee") {
    return null;
  }

  if (loading) {
    return <div className="text-center py-10">Loading applicants...</div>;
  }

  return (
    <main>
      <Card>
        <CardHeader>
          <CardTitle className="text-xl">Applicants Assigned</CardTitle>
        </CardHeader>
        <Separator />
        <CardContent>
          {applicationList.length > 0 ? (
            applicationList.map((apl, idx) => (
              <div key={`${apl.applicationId}-${idx}`} className="py-2">
                <Card className="border rounded-md shadow-sm">
                  <CardContent className="grid grid-cols-2 gap-2 items-center">
                    <div>
                      <p className="font-medium">{apl.candidateName}</p>
                      <p className="text-sm text-gray-500">
                        Applied on:{" "}
                        {new Date(apl.applicationDate).toLocaleDateString()}
                      </p>
                      <p className="text-sm text-gray-500">
                        Status: {apl.currentStatus}
                      </p>
                    </div>
                    <Button asChild className="justify-self-end">
                      <a
                        href={`applications/${apl.applicationId}`}
                        className="px-4 py-1 bg-blue-500 text-white rounded hover:bg-blue-600 transition"
                      >
                        View
                      </a>
                    </Button>
                  </CardContent>
                </Card>
              </div>
            ))
          ) : (
            <div className="text-center py-4 text-gray-500">
              No Applications Assigned
            </div>
          )}
        </CardContent>
      </Card>
    </main>
  );
};

export default Applications;
