import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { useParams } from "react-router-dom";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import { Button } from "@/components/ui/button";
import { useAuth } from "../../hooks/useAuth";
import PdfViewer from "../../components/PdfViewer";
import ApplicationReviewSection from "../../components/recruiter/ApplicationReviewsSection";
import { toast } from "sonner";
import ChangeStatusButton from "../../components/recruiter/ChangeStatusButton";
import ApplicationInterviewSection from "../../components/recruiter/ApplicationInterviewSection";
import ApplicationReviewerManager from "./ApplicationReviewerManager";
import ReviewerReviewSection from "../../components/reviewer/ReviewerReviewSection";

const Application = () => {
  const { applicationId } = useParams();

  const { authState } = useAuth();

  const [applicationSummary, setapplicationSummary] = useState(null);
  const [pdfFile, setPdfFile] = useState(null);
  const [loading, setLoading] = useState(true);
  const [myReviewStatus, setMyReviewStatus] = useState(false);

  const getApplicationSummary = async () => {
    try {
      const res = await api.get(`Applications/${applicationId}`);
      setapplicationSummary(res.data);
    } catch (err) {
      console.error("Failed to fetch profile:", err);
    } finally {
      setLoading(false);
    }
  };

  const getCV = async () => {
    const res = await api.get(`Applications/${applicationId}/cv`, {
      responseType: "blob",
    });
    console.log("download cv -", res);
    if (res.status == 200) {
      const fileURL = URL.createObjectURL(res.data);
      setPdfFile(fileURL);
    }
  };

  // submit complete review
  const getMyReviewStatus = async () => {
    // GET /applications/{ applicationId }/myreviewstatus;
    try {
      const res = await api.get(`Applications/${applicationId}/reviews/status`);
      setMyReviewStatus(res.data);
      console.log(res.data);
    } catch (err) {}
  };

  const submitReview = async () => {
    try {
      await api.post(`Applications/${applicationId}/reviews/submit`);
      toast.success("Review submitted successfully");
      setMyReviewStatus({
        isAssgined: myReviewStatus.isAssgined,
        isReviewCompleted: true,
      });
    } catch (err) {
      toast.error("Please complete skill & comment review before submitting");
    }
  };
  // submit complete review

  // useeffeect
  useEffect(() => {
    getApplicationSummary();
    getCV();
    getMyReviewStatus();
  }, []);

  useEffect(() => {
    getMyReviewStatus();
  }, [myReviewStatus.isReviewCompleted]);

  if (loading)
    return <div className="text-center py-10">Loading profile...</div>;
  if (!applicationSummary)
    return <div className="text-center py-10">Profile not found</div>;

  return (
    <div className="w-full mx-auto">
      <Card className="shadow-sm">
        <CardHeader className="flex items-center justify-between">
          <div className="flex flex-col items-center justify-between">
            <CardTitle className="text-xl">
              {applicationSummary.fullName}
            </CardTitle>
            <p className="text-sm text-muted-foreground">
              Applied on{": "}
              {new Date(
                applicationSummary.applicationDate
              ).toLocaleDateString()}
            </p>
          </div>
          <div className="flex flex-col items-center justify-between">
            {authState.employeeRoles.includes("Recruiter") ? (
              <ChangeStatusButton
                applicationId={applicationId}
                currentStatus={applicationSummary.currentStatus}
              />
            ) : (
              <div>Status: {applicationSummary.currentStatus}</div>
            )}
          </div>
        </CardHeader>

        <Separator />

        <CardContent className="space-y-4 pt-4">
          <div>
            <p className="text-sm text-muted-foreground">Job Title</p>
            <p className="font-medium">{applicationSummary.jobTitle}</p>
          </div>
          <div>
            <p className="text-sm text-muted-foreground">Email</p>
            <p className="font-medium">{applicationSummary.email}</p>
          </div>
        </CardContent>
      </Card>
      {/* reviewers card here */}
      <Card className="w-full">
        <CardHeader>
          <CardTitle>Resume & Reviewers</CardTitle>
        </CardHeader>

        <CardContent className="flex flex-row">
          <div className="border p-4 w-full">
            <PdfViewer pdfFile={pdfFile} />

            <Button className="mt-3" variant="outline">
              Download CV
            </Button>
          </div>
        </CardContent>
      </Card>

      {/* interview round and management */}
      {authState.employeeRoles.includes("Recruiter") && (
        <Card>
          <CardContent>
            <ApplicationReviewerManager applicationId={applicationId} />
          </CardContent>
        </Card>
      )}
      {/* reviews by reviewer */}
      {authState.employeeRoles.includes("Reviewer") &&
        myReviewStatus.isAssigned && (
          <ReviewerReviewSection applicationId={applicationId} />
        )}

      {console.log(
        applicationSummary.currentStatus != "InterviewInProgress",
        applicationSummary.currentStatus,
        "InterviewInProgress"
      )}
      {authState.employeeRoles.includes("Recruiter") &&
        applicationSummary.currentStatus == "InterviewInProgress" && (
          <Card>
            <CardContent>
              <ApplicationInterviewSection
                applicationId={applicationId}
                applicationStatus={applicationSummary.currentStatus}
              />
            </CardContent>
          </Card>
        )}
    </div>
  );
};

export default Application;
