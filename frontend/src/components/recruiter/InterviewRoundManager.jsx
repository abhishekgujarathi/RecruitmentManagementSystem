import React, { useEffect, useState } from "react";
import { Card, CardHeader, CardContent } from "@/components/ui/card";
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

const InterviewRoundManager = ({
  round,
  onSaveSchedule,
  onSaveMeetLink,
  onRefresh,
}) => {
  const [scheduledAt, setScheduledAt] = useState(
    round.scheduledAt?.slice(0, 16) || ""
  );
  const [meetLink, setMeetLink] = useState(round.meetLink || "");
  const [employees, setEmployees] = useState([]);
  const [interviewerId, setInterviewerId] = useState("");
  const [loading, setLoading] = useState(false);

  // show interviewer assign only if round status is not complete
  const disabled = round.status === "Completed";

  const { applicationId } = useParams();

  useEffect(() => {
    const fetchEmployees = async () => {
      if (!disabled) {
        try {
          const res = await api.get(`/Recruiters/employees/${applicationId}`);
          setEmployees(res.data);
        } catch {
          toast.error("Failed to load employees");
        }
      }
    };

    fetchEmployees();
  }, [applicationId]);

  const assignInterviewer = async () => {
    if (!interviewerId) return;
    try {
      setLoading(true);
      await api.post(
        `Interview/applications/rounds/${round.applicationInterviewRoundId}/panelMembers`,
        { userId: interviewerId }
      );
      toast.success("Panel member assigned");
      setInterviewerId("");
      onRefresh();
    } catch {
      toast.error("Failed to assign member");
    } finally {
      setLoading(false);
    }
  };

  const removeMember = async (id) => {
    try {
      await api.delete(`Interview/applications/rounds/panelMembers/${id}`);
      toast.success("Removed");
      onRefresh();
    } catch {
      toast.error("Failed to remove member");
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
          <div className="flex flex-col md:flex-row gap-2 w-full items-center">
            <label className="text-sm">Schedule</label>
            <Input
              type="datetime-local"
              className="w-full md:w-48"
              value={scheduledAt}
              onChange={(e) => setScheduledAt(e.target.value)}
              disabled={disabled}
            />
            <Button
              size="sm"
              className="w-full md:w-auto"
              disabled={disabled || !scheduledAt}
              onClick={() =>
                onSaveSchedule(round.applicationInterviewRoundId, scheduledAt)
              }
            >
              Save
            </Button>
          </div>

          <div className="flex flex-col md:flex-row gap-2 w-full items-center">
            <label className="text-sm">Meet link</label>
            <Input
              className="w-full md:w-64"
              placeholder="https://meet..."
              value={meetLink}
              onChange={(e) => setMeetLink(e.target.value)}
              disabled={disabled}
            />
            <Button
              size="sm"
              className="w-full md:w-auto"
              disabled={disabled || !meetLink}
              onClick={() =>
                onSaveMeetLink(round.applicationInterviewRoundId, meetLink)
              }
            >
              Save
            </Button>
          </div>
        </div>

        <div className="md:w-64 w-full flex flex-col gap-2">
          {!disabled && (
            <>
              <Select value={interviewerId} onValueChange={setInterviewerId}>
                <SelectTrigger className="w-full">
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
              <Button
                size="sm"
                onClick={assignInterviewer}
                disabled={loading || !interviewerId}
              >
                Assign
              </Button>
            </>
          )}

          <div className="flex flex-wrap gap-2 text-sm font-extrabold">
            {(round.panelMembers || []).map((pm) => (
              <div
                key={pm.interviewPanelMemberId}
                className="flex items-center gap-3 border p-2"
              >
                {pm.interviewerName}
                <Button
                  size="sm"
                  variant="destructive"
                  className="text-white text-2xl"
                  disabled={disabled}
                  onClick={() => removeMember(pm.interviewPanelMemberId)}
                >
                  <Trash2 />
                </Button>
              </div>
            ))}
            {round.panelMembers.length === 0 && (
              <p className="text-xs text-muted-foreground">No panel members</p>
            )}
          </div>
        </div>
      </div>
    </Card>
  );
};

export default InterviewRoundManager;
