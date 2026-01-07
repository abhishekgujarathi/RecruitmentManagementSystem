import React, { useEffect } from "react";
import api from "../../services/api";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { useState } from "react";
import { toast } from "sonner";

const ApplicationInterviewSection = ({ applicationId }) => {
  const [loading, setLoading] = useState(true);
  const [interviewRounds, setInterviewRounds] = useState([]);

  const fetchApplicationInterviewRounds = async () => {
    try {
      const res = await api.get(`Interview/applications/${applicationId}`);
      console.log("appli rounds-", res.data);
      const sortedRounds = res.data.sort(
        (a, b) => a.roundNumber - b.roundNumber
      );
      setInterviewRounds(sortedRounds);
    } catch (err) {
      console.log("error in job rounds", err);
      toast.error("Loading Job Rounds Error");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchApplicationInterviewRounds();
  }, []);

  if (loading) return <div className="p-4">Loading Interview Rounds</div>;
  if (interviewRounds.length == 0)
    return <div className="p-4">No interview Rounds defined</div>;

  return (
    <div className="p-0">
      <h1 className="px-4 pb-4 font-bold border-b">Interview Rounds</h1>
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead className="font-bold px-8">Round Number</TableHead>
            <TableHead className="font-bold px-8">Round Type</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {interviewRounds.map((ir) => (
            <TableRow key={ir.jobInterviewRoundId}>
              <TableCell className="font-medium px-8">
                {ir.roundNumber}
              </TableCell>
              <TableCell className="font-bold px-8">{ir.roundType}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
};

export default ApplicationInterviewSection;
