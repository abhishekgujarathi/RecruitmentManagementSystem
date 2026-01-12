import React, { useEffect, useState } from "react";
import api from "@/services/api";
import { Button } from "@/components/ui/button";
import { useNavigate, useParams } from "react-router-dom";

const CandidateVerification = () => {
  //   const [verification, setVerification] = useState(null);
  const [file, setFile] = useState(null);
  const [documentType, setDocumentType] = useState("");

  const { verificationId } = useParams();
  useEffect(() => {
    fetchVerification();
  }, []);

  const fetchVerification = async () => {
    const res = await api.get(`/verifications/${verificationId}`);
    setVerification(res.data);
  };

  const handleUpload = async () => {
    const formData = new FormData();
    formData.append("file", file);
    formData.append("documentType", documentType);

    await api.post(`/verifications/${verificationId}/documents`, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    });

    fetchVerification();
  };

  if (!verification) return <div>Loading...</div>;

  return (
    <div className="p-6 max-w-3xl mx-auto">
      <h2 className="text-xl font-semibold mb-4">Verification</h2>

      <p>
        Status: <b>{verification.overallStatus}</b>
      </p>

      <div className="mt-6">
        <h3 className="font-medium mb-2">Upload Document</h3>

        <select
          className="border p-2 mr-2"
          value={documentType}
          onChange={(e) => setDocumentType(e.target.value)}
        >
          <option value="">Select Type</option>
          <option value="Aadhar">Aadhar</option>
          <option value="PAN">PAN</option>
          <option value="Degree">Degree</option>
        </select>

        <input type="file" onChange={(e) => setFile(e.target.files[0])} />

        <Button className="ml-2" onClick={handleUpload}>
          Upload
        </Button>
      </div>

      <div className="mt-6">
        <h3 className="font-medium mb-2">Uploaded Documents</h3>

        <table className="w-full border">
          <thead>
            <tr>
              <th>Type</th>
              <th>Status</th>
              <th>Remarks</th>
            </tr>
          </thead>
          <tbody>
            {verification.documents.map((doc) => (
              <tr key={doc.documentId}>
                <td>{doc.documentType}</td>
                <td>{doc.status}</td>
                <td>{doc.remarks || "-"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default CandidateVerification;
