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
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { toast } from "sonner";
import InterviewRoundManager from "./InterviewRoundManager";

const ApplicationInterviewSection = ({ applicationId }) => {
  const [loading, setLoading] = useState(true);
  const [interviewRounds, setInterviewRounds] = useState([]);

  const fetchRounds = async () => {
    try {
      const res = await api.get(`Interview/applications/${applicationId}`);
      setInterviewRounds(
        res.data.sort((a, b) => a.roundNumber - b.roundNumber)
      );
      console.log(res.data)
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

  const removeRound = (i) => {
    setInterviewRounds((p) => p.filter((_, idx) => idx !== i));
  };

  const saveRounds = async () => {
    try {
      await api.put(
        `Interview/applications/${applicationId}`,
        interviewRounds.map((r) => ({
          applicationInterviewRoundId: r.applicationInterviewRoundId || null,
          roundNumber: Number(r.roundNumber),
          roundType: r.roundType,
        }))
      );
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
    <div className="p-4 space-y-4">
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
          {interviewRounds.map((r, i) => (
            <TableRow key={i} className="px-8">
              <TableCell>
                <Input
                  type="number"
                  value={r.roundNumber}
                  onChange={(e) =>
                    handleChange(i, "roundNumber", e.target.value)
                  }
                />
              </TableCell>

              <TableCell className="px-8">
                <Select
                  value={r.roundType}
                  onValueChange={(value) => handleChange(i, "roundType", value)}
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

              <TableCell className="px-8">{r.status}</TableCell>
              <TableCell className="px-8">
                <Button
                  size="sm"
                  variant="destructive"
                  onClick={() => removeRound(i)}
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

      <div className="space-y-4 pt-6">
        <h3 className="font-semibold">Round Details</h3>

        {interviewRounds
          .filter((r) => r.applicationInterviewRoundId)
          .map((r) => (
            <InterviewRoundManager
              key={r.applicationInterviewRoundId}
              round={r}
              onSaveSchedule={saveSchedule}
              onSaveMeetLink={saveMeetLink}
              onRefresh={fetchRounds}
            />
          ))}

        {interviewRounds.every((r) => !r.applicationInterviewRoundId) && (
          <p className="text-sm text-muted-foreground">
            Save interview rounds to manage schedule and panel members.
          </p>
        )}
      </div>
    </div>
  );
};

export default ApplicationInterviewSection;
