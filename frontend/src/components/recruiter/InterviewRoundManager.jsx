import React, { useEffect, useState } from "react";
import { Card, CardHeader } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
} from "@/components/ui/select";
import api from "../../services/api";
import { toast } from "sonner";
import { useParams } from "react-router-dom";
import { Trash2 } from "lucide-react";
import InterviewFeedbackSection from "./InterviewFeedBackSection";
import InterviewFeedbackForm from "../interviewer/InterviewFeedbackForm";

const InterviewRoundManager = ({ round, onRefresh }) => {
  const { applicationId } = useParams();
  console.log(round);
  const [scheduledAt, setScheduledAt] = useState(
    round.scheduledAt?.slice(0, 16) || ""
  );
  const [meetLink, setMeetLink] = useState(round.meetLink || "");
  const [employees, setEmployees] = useState([]);
  const [panelMembers, setPanelMembers] = useState(round.panelMembers);
  const [interviewerId, setInterviewerId] = useState("");
  const [loading, setLoading] = useState(false);
  const [roundDisabled, setroundDisabled] = useState(
    round.status == "Pending" ||
      round.status == "Completed" ||
      round.status == "Rejected"
  );

  const [disabled, _] = useState(
    round.status === "Completed" || round.status === "Rejected"
  );

  const getEmployees = async () => {
    try {
      const res = await api.get(`/Recruiters/employees/${applicationId}`);
      console.log("emploo", res.data);
      setEmployees(res.data);
    } catch (er) {
      toast.error("Failed to load employees");
    }
  };

  useEffect(() => {
    if (disabled) return;

    getEmployees();
  }, [applicationId, disabled]);

  const addPanelMember = () => {
    if (!interviewerId) return;

    const employee = employees.find((e) => e.key === interviewerId);
    if (!employee) return;

    setPanelMembers((p) => [
      ...p,
      {
        interviewerId: interviewerId,
        interviewerName: employee.value,
      },
    ]);

    setInterviewerId("");
  };

  const removePanelMember = (userId) => {
    setPanelMembers((p) => p.filter((m) => m.userId !== userId));
  };

  const saveRound = async () => {
    try {
      setLoading(true);
      const paylod = {
        roundId: round.applicationInterviewRoundId,
        scheduledAt: scheduledAt,
        meetLink: meetLink,
        panelMembers: panelMembers.map((p) => p.interviewerId),
      };
      console.log(paylod);
      await api.put(`/Interview/applications/rounds/`, paylod);

      toast.success("Round saved");
      onRefresh();
    } catch {
      toast.error("Failed to save round");
    } finally {
      setLoading(false);
    }
  };

  const notifyAll = async () => {
    try {
      await api.post(
        `/Interview/applications/rounds/${round.applicationInterviewRoundId}/notify`
      );
      toast.success("Notifications sent");
    } catch {
      toast.error("Failed to notify");
    }
  };

  const rejectRound = async () => {
    try {
      await api.post(
        `/Interview/applications/rounds/${round.applicationInterviewRoundId}/reject`
      );
      toast.success("Round rejected");
      onRefresh();
    } catch (err) {
      toast.error("Failed to reject round");
      console.error(err);
    }
  };

  const completeRound = async () => {
    try {
      await api.post(
        `/Interview/applications/rounds/${round.applicationInterviewRoundId}/complete`
      );
      toast.success("Round completed");
      onRefresh();
    } catch (err) {
      toast.error("Failed to complete round");
      console.error(err);
    }
  };

  return (
    <Card className="p-4">
      <CardHeader className="flex justify-between p-0 mb-3 font-medium">
        <span>Round {round.roundNumber}</span>
        <span>{round.roundType}</span>
        <span className="text-xs text-muted-foreground">{round.status}</span>
      </CardHeader>

      <div className="flex flex-col md:flex-row gap-4">
        <div className="flex-1 flex flex-col gap-3">
          <div className="flex items-center gap-2">
            <label className="text-sm">Schedule</label>
            <Input
              type="datetime-local"
              value={scheduledAt}
              onChange={(e) => setScheduledAt(e.target.value)}
              disabled={disabled}
            />
          </div>

          <div className="flex items-center gap-2">
            <label className="text-sm">Meet link</label>
            <Input
              placeholder="https://meet..."
              value={meetLink}
              onChange={(e) => setMeetLink(e.target.value)}
              disabled={disabled}
            />
          </div>
        </div>

        <div className="md:w-64 flex flex-col gap-2">
          {!disabled && (
            <>
              <Select value={interviewerId} onValueChange={setInterviewerId}>
                <SelectTrigger>
                  <SelectValue placeholder="Select Employee" />
                </SelectTrigger>
                <SelectContent>
                  {employees.map((e) => (
                    <SelectItem key={e.key} value={e.key}>
                      {e.value}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>

              <Button size="sm" onClick={addPanelMember}>
                Add
              </Button>
            </>
          )}

          <div className="flex flex-wrap gap-2 text-sm font-medium">
            {panelMembers.map((pm) => (
              <div
                key={pm.userId}
                className="flex items-center gap-2 border p-2"
              >
                {pm.interviewerName}
                {!disabled && (
                  <Button
                    size="icon"
                    variant="destructive"
                    onClick={() => removePanelMember(pm.userId)}
                  >
                    <Trash2 size={14} />
                  </Button>
                )}
              </div>
            ))}
          </div>
        </div>
      </div>

      <div className="flex justify-end gap-2 mt-4">
        <Button onClick={saveRound} disabled={loading || disabled}>
          Save Round
        </Button>
        <Button onClick={notifyAll} disabled={loading || disabled}>
          Notify All
        </Button>
      </div>
      <InterviewFeedbackSection
        applicationId={applicationId}
        roundId={round.applicationInterviewRoundId}
      />

      <div className="w-full flex justify-end gap-8">
        <Button onClick={rejectRound} disabled={roundDisabled}>
          Reject
        </Button>
        <Button onClick={completeRound} disabled={roundDisabled}>
          Complete
        </Button>
      </div>
    </Card>
  );
};

export default InterviewRoundManager;
