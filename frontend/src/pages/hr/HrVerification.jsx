import React, { useEffect, useState } from "react";
import api from "@/services/api";
import { Button } from "@/components/ui/button";

const HrVerification = ({ verificationId }) => {
  const [verification, setVerification] = useState(null);
  const [remarks, setRemarks] = useState("");

  useEffect(() => {
    fetchVerification();
  }, []);

  const fetchVerification = async () => {
    const res = await api.get(`/verifications/${verificationId}`);
    setVerification(res.data);
  };

  const verifyDocument = async (documentId, status) => {
    await api.put(`/verifications/documents/${documentId}/verify`, {
      status,
      remarks,
    });

    setRemarks("");
    fetchVerification();
  };

  if (!verification) return <div>Loading...</div>;

  return (
    <div className="p-6 max-w-4xl mx-auto">
      <h2 className="text-xl font-semibold mb-4">Candidate Verification</h2>

      <p>
        Overall Status: <b>{verification.overallStatus}</b>
      </p>

      <table className="w-full mt-6 border">
        <thead>
          <tr>
            <th>Document</th>
            <th>Status</th>
            <th>File</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {verification.documents.map((doc) => (
            <tr key={doc.documentId}>
              <td>{doc.documentType}</td>
              <td>{doc.status}</td>
              <td>
                <a href={doc.fileUrl} target="_blank">
                  View
                </a>
              </td>
              <td>
                <input
                  placeholder="Remarks"
                  value={remarks}
                  onChange={(e) => setRemarks(e.target.value)}
                  className="border p-1 mr-2"
                />
                <Button
                  variant="success"
                  onClick={() => verifyDocument(doc.documentId, "Approved")}
                >
                  Approve
                </Button>
                <Button
                  variant="destructive"
                  className="ml-2"
                  onClick={() => verifyDocument(doc.documentId, "Rejected")}
                >
                  Reject
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default HrVerification;
