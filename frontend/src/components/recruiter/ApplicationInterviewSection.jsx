import React, { useEffect, useState } from "react";
import api from "../../services/api";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { toast } from "sonner";
import InterviewRoundManager from "./InterviewRoundManager";
import { useAuth } from "../../hooks/useAuth";
import InterviewFeedbackForm from "../interviewer/InterviewFeedbackForm";

const ApplicationInterviewSection = ({ applicationId, applicationStatus }) => {
  const [loading, setLoading] = useState(true);
  const [interviewRounds, setInterviewRounds] = useState([]);

  const { authState } = useAuth();

  const fetchRounds = async () => {
    try {
      const res = await api.get(`Interview/applications/${applicationId}`);
      setInterviewRounds(
        res.data.sort((a, b) => a.roundNumber - b.roundNumber)
      );
      console.log("r", res.data);
    } catch {
      toast.error("Failed to load rounds");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchRounds();
  }, []);

  const handleChange = (index, field, value) => {
    const newRounds = [...interviewRounds];
    newRounds[index] = { ...newRounds[index], [field]: value };
    setInterviewRounds(newRounds);
  };

  const addRound = () => {
    setInterviewRounds((p) => [
      ...p,
      {
        applicationInterviewRoundId: null,
        roundNumber: p.length + 1,
        roundType: "",
      },
    ]);
  };

  const removeRound = (idx) => {
    setInterviewRounds((p) => p.filter((_, idx) => idx !== idx));
  };

  const saveRounds = async () => {
    try {
      const paylod = interviewRounds.map((intrR, idx) => ({
        applicationInterviewRoundId: intrR.applicationInterviewRoundId || null,
        roundNumber: idx + 1,
        roundType: intrR.roundType,
      }));
      console.log("paylodd=", paylod);
      await api.put(`Interview/applications/${applicationId}`, paylod);
      toast.success("Rounds saved");
      fetchRounds();
    } catch {
      toast.error("Save failed");
    }
  };

  const saveSchedule = async (roundId, value) => {
    try {
      await api.patch(`Interview/applications/rounds/${roundId}/schedule`, {
        scheduledAt: value,
      });
      toast.success("Scheduled");
      fetchRounds();
    } catch {
      toast.error("Failed to schedule");
    }
  };

  const saveMeetLink = async (roundId, value) => {
    try {
      await api.patch(`Interview/applications/rounds/${roundId}/meetLink`, {
        meetLink: value,
      });
      toast.success("Meet link saved");
      fetchRounds();
    } catch {
      toast.error("Failed to save meet link");
    }
  };

  if (loading) return <div className="p-4">Loading...</div>;

  return (
    <Card>
      <CardContent>
        <div className="p-4 space-y-4">
          {authState.employeeRoles.includes("Recruiter") && (
            <>
              <div className="flex justify-between items-center">
                <h2 className="font-semibold">Interview Rounds</h2>
                <Button onClick={addRound}>Add</Button>
              </div>
              <Table className="border">
                <TableHeader>
                  <TableRow>
                    <TableHead className="px-8">No</TableHead>
                    <TableHead className="px-8">Type</TableHead>
                    <TableHead className="px-8">Status</TableHead>
                    <TableHead className="px-8">Action</TableHead>
                  </TableRow>
                </TableHeader>

                <TableBody>
                  {interviewRounds.map((intrR, idx) => (
                    <TableRow key={idx} className="px-8">
                      <TableCell>{idx + 1}</TableCell>

                      <TableCell className="px-8">
                        <Select
                          value={intrR.roundType}
                          onValueChange={(value) =>
                            handleChange(idx, "roundType", value)
                          }
                        >
                          <SelectTrigger className="h-9">
                            <SelectValue placeholder="Select" />
                          </SelectTrigger>

                          <SelectContent>
                            <SelectItem value="Technical">Technical</SelectItem>
                            <SelectItem value="HR">HR</SelectItem>
                          </SelectContent>
                        </Select>
                      </TableCell>

                      <TableCell className="px-8">{intrR.status}</TableCell>
                      <TableCell className="px-8">
                        <Button
                          size="sm"
                          variant="destructive"
                          disabled={intrR.status != "Pending"}
                          onClick={() => removeRound(idx)}
                        >
                          Delete
                        </Button>
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
              <div className="flex justify-end">
                <Button onClick={saveRounds}>Save Changes</Button>
              </div>
            </>
          )}
          {authState.employeeRoles.includes("Recruiter") &&
            (applicationStatus == "InterviewInProgress" ||
              applicationStatus == "Rejected" ||
              applicationStatus == "OnHold" ||
              applicationStatus == "Hired") && (
              <div className="space-y-4 pt-6">
                <h3 className="font-semibold">Round Details</h3>
                <>
                  {interviewRounds
                    .filter((intrR) => intrR.applicationInterviewRoundId)
                    .map((intrR) => (
                      <InterviewRoundManager
                        key={intrR.applicationInterviewRoundId}
                        round={intrR}
                        onSaveSchedule={saveSchedule}
                        onSaveMeetLink={saveMeetLink}
                        onRefresh={fetchRounds}
                      />
                    ))}
                </>
              </div>
            )}
          {authState.employeeRoles.includes("Interviewer") && (
            <>
              {/* // applicationSummary.currentStatus == "InterviewInProgress" && ( */}
              <InterviewFeedbackForm
                applicationId={applicationId}
                roundId={interviewRounds}
                // skills={round.requiredSkills}
              />
            </>
          )}
        </div>
        {authState.employeeRoles.includes("Recruiter") && (
          <div className="items-center justify-center flex">
            <Button
              disabled={
                !interviewRounds[interviewRounds?.length - 1]?.status ==
                  "Completed" || applicationStatus == "Hired"
              }
            >
              Hire
            </Button>
          </div>
        )}
      </CardContent>
    </Card>
  );
};

export default ApplicationInterviewSection;
