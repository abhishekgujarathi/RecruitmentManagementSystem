import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { Button } from "@/components/ui/button";
import { Separator } from "@/components/ui/separator";
import { toast } from "sonner";
import SkillReviewSection from "./SkillReviewSection";
import ReviewSection from "./ReviewSection";

const ReviewerReviewSection = ({ applicationId }) => {
  const [myReviewStatus, setMyReviewStatus] = useState({
    isAssigned: false,
    isReviewCompleted: false,
  });

  const getMyReviewStatus = async () => {
    try {
      const res = await api.get(`Applications/${applicationId}/reviews/status`);
      setMyReviewStatus(res.data);
      console.log(res.data);
    } catch (err) {
      console.error("Failed to fetch review status:", err);
    }
  };

  const submitReview = async () => {
    try {
      await api.post(`Applications/${applicationId}/reviews/submit`);
      toast.success("Review submitted successfully");
      setMyReviewStatus({
        isAssigned: myReviewStatus.isAssigned,
        isReviewCompleted: true,
      });
    } catch (err) {
      toast.error("Please complete skill & comment review before submitting");
    }
  };

  useEffect(() => {
    getMyReviewStatus();
  }, [applicationId]);

  useEffect(() => {
    if (myReviewStatus.isReviewCompleted) {
      getMyReviewStatus();
    }
  }, [myReviewStatus.isReviewCompleted]);

  if (!myReviewStatus.isAssigned) return null;

  return (
    <div className="container border p-4">
      <h1 className="text-lg font-bold px-4">My Reviews</h1>
      <SkillReviewSection
        disabled={myReviewStatus}
        applicationId={applicationId}
      />
      <Separator />
      <ReviewSection disabled={myReviewStatus} applicationId={applicationId} />
      <Separator />
      <div className="flex justify-center px-4 pt-8">
        <Button
          disabled={myReviewStatus.isReviewCompleted}
          onClick={submitReview}
        >
          {!myReviewStatus.isReviewCompleted ? "Complete Review" : "Completed"}
        </Button>
      </div>
    </div>
  );
};

export default ReviewerReviewSection;
