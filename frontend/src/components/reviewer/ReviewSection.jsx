import React, { useEffect, useState } from "react";
import { Card } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import api from "../../services/api";
import { useAuth } from "../../hooks/useAuth";
import { toast } from "sonner";

const ReviewSection = ({ disabled, applicationId }) => {
  const [comments, setComments] = useState([]);
  const [loading, setLoading] = useState(false);
  const [newCommentText, setNewCommentText] = useState("");

  const { authState } = useAuth;

  // getting existing comments
  const fetchComments = async () => {
    const res = await api.get(`Applications/${applicationId}/reviews`);
    setComments(res.data);
  };

  useEffect(() => {
    fetchComments();
  }, [applicationId]);

  // tmp id making
  const generateTempId = () => `temp-${Date.now()}-${Math.random()}`;

  // Add temporary new comment
  const addComment = () => {
    if (!newCommentText.trim()) return;
    setComments((prev) => [
      ...prev,
      {
        reviewCommentId: null,
        tempId: generateTempId(),
        commentText: newCommentText,
      },
    ]);
    setNewCommentText("");
  };

  // Update comment text
  const updateCommentText = (identifier, text) => {
    setComments((prev) =>
      prev.map((c) => {
        const currentId = c.reviewCommentId || c.tempId;
        return currentId === identifier ? { ...c, commentText: text } : c;
      })
    );
  };

  // Remove comment
  const removeComment = (identifier) => {
    setComments((prev) =>
      prev.filter((c) => {
        const currentId = c.reviewCommentId || c.tempId;
        return currentId !== identifier;
      })
    );
  };

  // Save all comments to backend
  const saveComments = async () => {
    setLoading(true);
    try {
      await api.put(
        `Applications/${applicationId}/reviews`,
        comments.map((c) => ({
          reviewCommentId: c.reviewCommentId ?? null,
          commentText: c.commentText,
        }))
      );
      toast("Reviews Comments Updated!");
      await fetchComments();
    } catch (error) {
      console.error("Failed to save comments:", error);
    } finally {
      setLoading(false);
    }
  };

  if (!disabled.isAssigned) return <></>;

  return (
    <Card className="px-4 border-none">
      <h3 className="font-semibold text-lg">Review Comments</h3>
      {console.log(disabled)}
      <div className="space-y-2">
        {comments.map((c) => {
          const commentId = c.reviewCommentId || c.tempId;
          return (
            <div key={commentId} className="flex gap-2 h-fit items-start">
              <textarea
                disabled={disabled.isReviewCompleted}
                type="text"
                className="flex-1 border rounded px-2 py-1 text-sm min-h-10"
                value={c.commentText}
                placeholder="Write a comment..."
                onChange={(e) => updateCommentText(commentId, e.target.value)}
              />
              {!disabled.isReviewCompleted && (
                <Button
                  variant="destructive"
                  size="sm"
                  onClick={() => removeComment(commentId)}
                >
                  Delete
                </Button>
              )}
            </div>
          );
        })}
      </div>
      {!disabled.isReviewCompleted && (
        <div className="flex gap-2">
          <textarea
            className="flex-1 border rounded px-2 py-1 text-sm resize-y min-h-[60px]"
            placeholder="Add new comment..."
            value={newCommentText}
            onChange={(e) => setNewCommentText(e.target.value)}
            rows={3}
          />
          <Button onClick={addComment}>Add</Button>
        </div>
      )}
      {!disabled.isReviewCompleted && (
        <div className="flex justify-center">
          <Button className="w-2/6" onClick={saveComments} disabled={loading}>
            {loading ? "Saving..." : "Save Comments"}
          </Button>
        </div>
      )}
    </Card>
  );
};

export default ReviewSection;
