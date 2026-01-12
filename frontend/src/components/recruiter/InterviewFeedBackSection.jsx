import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import api from "../../services/api";

function InterviewFeedbackSection({ applicationId, roundId }) {
  const [round, setRound] = useState(null);

  const fetchFeedbacks = async () => {
    try {
      const res = await api.get(
        `/Interview/applications/${applicationId}/feedbacks/all`
      );
      const matchedRound = res.data.find(
        (r) => r.applicationInterviewRoundId === roundId
      );
      setRound(matchedRound || null);
      console.log("feedbacks list recruiter -", matchedRound);
    } catch (err) {
      console.error("Failed to fetch feedbacks", err);
      setRound(null);
    }
  };

  useEffect(() => {
    fetchFeedbacks();
  }, [applicationId, roundId]);

  if (!round) {
    return (
      <Card>
        <CardContent className="text-sm text-muted-foreground">
          No feedback available for this round
        </CardContent>
      </Card>
    );
  }

  return (
    <Card className="m-0">
      <CardHeader>
        <CardTitle className="text-base">Interview Feedback</CardTitle>
      </CardHeader>

      <CardContent className="text-sm">
        {round.feedbacks.length === 0 ? (
          <div className="p-2 text-muted-foreground">No feedback yet</div>
        ) : (
          round.feedbacks.map((rev) => (
            <Card
              key={rev.interviewFeedbackId}
              className="border rounded-md mb-3 p-3"
            >
              <div className="font-medium">{rev.interviewerName}</div>
              <div className="font-medium">
                <span>OverAll Ratings: {rev.overallRating}/5</span>
              </div>

              {rev.skillRatings.length === 0 ? (
                <div className="text-xs text-muted-foreground mt-1">
                  No skill ratings yet
                </div>
              ) : (
                <div className="mt-2 grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-3">
                  {rev.skillRatings.map((s) => (
                    <div
                      key={s.skillId}
                      className="border p-2 text-sm rounded-sm"
                    >
                      <div className="font-medium truncate">{s.skillName}</div>
                      <div className="text-xs text-muted-foreground">
                        Rating: {s.rating ?? "N/A"} / 5
                      </div>
                    </div>
                  ))}
                </div>
              )}

              {rev.comments ? (
                <div className="mt-2">
                  <div className="font-black mb-1">Comments</div>
                  <div className="text-sm">{rev.comments}</div>
                </div>
              ) : (
                <div className="text-xs text-muted-foreground mt-2">
                  No comments yet
                </div>
              )}

              <Separator className="mt-3" />
            </Card>
          ))
        )}
      </CardContent>
    </Card>
  );
}

export default InterviewFeedbackSection;
