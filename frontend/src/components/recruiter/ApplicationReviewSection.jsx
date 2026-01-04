import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import api from "../../services/api";

export default function ApplicationReviewSection({ applicationId }) {
  const [reviews, setReviews] = useState([]);

  const fetchReviews = async () => {
    const res = await api.get(`Applications/${applicationId}/reviews/all`);
    setReviews(res.data);
    console.log(res.data);
  };

  useEffect(() => {
    fetchReviews();
  }, [applicationId]);

  if (!reviews.length) {
    return (
      <Card>
        <CardContent className="text-sm text-muted-foreground">
          No reviews available
        </CardContent>
      </Card>
    );
  }

  return (
    <Card>
      <CardHeader className="pb-2">
        <CardTitle className="text-base">Reviews</CardTitle>
      </CardHeader>

      <CardContent className="space-y-4 text-sm">
        {reviews.map((review) => (
          <Card key={review.userId}>
            <CardHeader className="pb-2">
              <CardTitle className="text-base">{review.userName}</CardTitle>
            </CardHeader>

            <CardContent className="space-y-4 text-sm">
              {review.skills.length > 0 && (
                <div>
                  <div className="font-medium mb-1">Skills</div>
                  <ul className="space-y-1">
                    {review.skills.map((s) => (
                      <li key={s.skillId} className="flex justify-between">
                        <span>{s.skillName}</span>
                        <span className="text-muted-foreground">
                          {s.yearsOfExperience ?? 0} yrs
                        </span>
                      </li>
                    ))}
                  </ul>
                </div>
              )}

              {review.comments.length > 0 && (
                <div>
                  <div className="font-medium mb-1">Comments</div>
                  <ul className="space-y-1">
                    {review.comments.map((c) => (
                      <li
                        key={c.reviewCommentId}
                        className="border-l-2 pl-3 text-muted-foreground"
                      >
                        {c.commentText}
                      </li>
                    ))}
                  </ul>
                </div>
              )}
            </CardContent>
          </Card>
        ))}
      </CardContent>
    </Card>
  );
}
