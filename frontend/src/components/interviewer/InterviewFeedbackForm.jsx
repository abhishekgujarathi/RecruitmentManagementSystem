import { useEffect, useState } from "react";
import api from "@/services/api";
import { toast } from "sonner";
import { Card, CardHeader, CardTitle, CardContent } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Textarea } from "@/components/ui/textarea";
import {
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
} from "@/components/ui/select";
import RoundFeedBackSection from "./RoundFeedBackSection";

function InterviewFeedbackForm({ applicationId }) {
  const [rounds, setRounds] = useState([]);

  const fetchRounds = async () => {
    try {
      const res = await api.get(
        `/Interview/applications/${applicationId}/feedbacks`
      );
      console.log("rounds=", res.data);
      setRounds(res.data);
    } catch {
      toast.error("Failed to load interviews");
    }
  };
  useEffect(() => {
    fetchRounds();
  }, [applicationId]);

  const updateRound = (updatedRound) => {
    setRounds((r) =>
      r.map((round) =>
        round.applicationInterviewRoundId ===
        updatedRound.applicationInterviewRoundId
          ? updatedRound
          : round
      )
    );
  };

  const submitRound = async (round) => {
    try {
      const payload = {
        // interviewerId: currentUser.interviewerId, // ⚠️
        applicationInterviewRoundId: round.applicationInterviewRoundId,
        comments: round.feedbacks[0].comments,
        skillRatings: round.feedbacks[0].skillRatings.map((s) => ({
          skillId: s.skillId,
          rating: s.rating,
        })),
      };

      console.log("s", payload);
      await api.put(
        `/Interview/${round.applicationInterviewRoundId}/feedback`,
        payload
      );
      toast.success("Feedback saved");
    } catch {
      toast.error("Failed to save feedback");
    }
  };

  return rounds.map((round) => (
    <RoundFeedBackSection
      key={round.applicationInterviewRoundId}
      round={round}
      onRoundChange={updateRound}
      onSubmit={submitRound}
    />
  ));
}
export default InterviewFeedbackForm;
