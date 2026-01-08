import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import api from "../../services/api";

// shown only to recruiter
export default function ApplicationReviewsSection({ applicationId }) {
  const [reviews, setReviews] = useState([]);

  const fetchReviews = async () => {
    const res = await api.get(`Applications/${applicationId}/reviews/all`);
    setReviews(res.data);
    console.log("reviewslist recruiter -", res.data);
  };

  useEffect(() => {
    fetchReviews();
  }, [applicationId]);

  if (reviews.length == 0) {
    return (
      <Card>
        <CardContent className="text-sm text-muted-foreground">
          No reviews available
        </CardContent>
      </Card>
    );
  }

  return (
    <Card className="m-0">
      <CardHeader className="">
        <CardTitle className="text-base">Reviews</CardTitle>
      </CardHeader>

      <CardContent className="text-sm">
        {reviews.map((review) => (
          <Card className="border shadow-none" key={review.userId}>
            <CardHeader className="pb-2">
              <CardTitle className="text-base">{review.userName}</CardTitle>
            </CardHeader>

            <CardContent className="text-sm">
              {!review.skills.length > 0 ? (
                <div className="p-2">No Skill Reviews Yet</div>
              ) : (
                <div>
                  <div className="font-medium mb-2">Skills</div>

                  {/*  to display skill review given by reviewer */}
                  <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-3">
                    {review.skills.map((s) => (
                      <div key={s.skillId} className="border p-2 text-sm">
                        <div className="font-medium truncate">
                          {s.skillName}
                        </div>

                        <div className="flex items-center justify-between text-muted-foreground">
                          <span>{s.yearsOfExperience ?? 0} yrs</span>
                          <input
                            type="checkbox"
                            checked={s.hasSkill}
                            readOnly
                            className="h-4 w-4 cursor-default"
                          />
                        </div>
                      </div>
                    ))}
                  </div>
                </div>
              )}

              {/* review comment */}
              {!review.comments.length > 0 ? (
                <div className="p-2">No Review Comments Yet</div>
              ) : (
                <div>
                  <div className="font-black mb-2">Comments</div>

                  <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-3">
                    {review.comments.map((c) => (
                      <div
                        key={c.reviewCommentId}
                        className="border rounded-md p-3 text-sm"
                      >
                        <p className="">{c.commentText}</p>

                        <div className="mt-2 text-xs text-muted-foreground">
                          {new Date(c.commentDate).toLocaleDateString()}
                        </div>
                      </div>
                    ))}
                  </div>
                  <Separator />
                </div>
              )}
            </CardContent>
          </Card>
        ))}
      </CardContent>
    </Card>
  );
}
