import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { useParams } from "react-router-dom";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import { Document, Page, pdfjs } from "react-pdf";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { useAuth } from "../../hooks/useAuth";
import PdfViewer from "../../components/PdfViewer";
import ReviewSection from "../../components/reviewer/ReviewSection";
import SkillReviewSection from "../../components/reviewer/SkillReviewSection";
import ApplicationReviewSection from "../../components/recruiter/ApplicationReviewsSection";
import { toast } from "sonner";
import ChangeStatusButton from "../../components/recruiter/ChangeStatusButton";
import ApplicationInterviewSection from "../../components/recruiter/ApplicationInterviewSection";

const Application = () => {
  const { applicationId } = useParams();

  const { authState } = useAuth();

  const [applicationSummary, setapplicationSummary] = useState(null);
  const [pdfFile, setPdfFile] = useState(null);
  const [loading, setLoading] = useState(true);
  const [reviewers, setReviewers] = useState([]);
  const [appliReviewers, setAppliReviewers] = useState([]);

  const [myReviewStatus, setMyReviewStatus] = useState(false);

  const [selectedReviewerId, setSelectedReviewerId] = useState("");

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

  const getApplicationReviewers = async () => {
    try {
      if (!authState.employeeRoles.includes("Recruiter")) return;
      const res = await api.get(`/Applications/${applicationId}/reviewers`);
      console.log("revv-", res.data);
      setAppliReviewers(res.data);
    } catch (err) {
      console.error("Failed to fetch profile:", err);
    } finally {
      setLoading(false);
    }
  };

  const getReviewerList = async () => {
    // fetching list of reviweres
    try {
      if (!authState.employeeRoles.includes("Recruiter")) return;
      const res = await api.get(`/Recruiters/employees/${applicationId}`);
      // console.log("change this");
      setReviewers(res.data);
    } catch (err) {
      console.error("Failed to fetch profile:", err);
    } finally {
      setLoading(false);
    }
  };

  const formatDate = (date) =>
    date ? new Date(date).toLocaleDateString("en-GB") : "N/A";

  const assignReviewer = async () => {
    if (!selectedReviewerId) return;

    const res = await api.post(`Applications/${applicationId}/reviewers`, {
      reviewerId: selectedReviewerId,
    });

    if (res.status == 200) {
      getApplicationReviewers();
      setReviewers([]);
      getReviewerList();
      toast("Reviewer Added");
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
    getApplicationReviewers();
    getReviewerList();
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

          {console.log(authState.employeeRoles)}
          {authState.employeeRoles.includes("Recruiter") && (
            <>
              <div className="w-3/6 rounded-lg p-4">
                <h3 className="font-semibold mb-4">Assigned Reviewers</h3>
                {loading ? (
                  <p>Loading reviewers...</p>
                ) : appliReviewers?.length === 0 ? (
                  <p className="text-sm text-muted-foreground">
                    No reviewers assigned
                  </p>
                ) : (
                  <ul className="space-y-3">
                    {appliReviewers?.map((r) => (
                      <li
                        key={r.id}
                        className="flex justify-between items-center border-b pb-2"
                      >
                        <div>
                          <p className="font-medium">{r.name}</p>
                          <p className="text-xs text-muted-foreground">
                            Status: {r.status}
                          </p>
                        </div>
                        <div className="flex flex-col gap-1">
                          <span className="text-xs">
                            Assigned On: {formatDate(r.assignedDate) || "N/A"}
                          </span>
                          <span className="text-xs">
                            Reviewed On: {formatDate(r.reviewedOn) || "Pending"}
                          </span>
                        </div>
                      </li>
                    ))}
                  </ul>
                )}

                <div className="mt-5 space-y-2">
                  <Select onValueChange={setSelectedReviewerId}>
                    <SelectTrigger className="w-full">
                      <SelectValue placeholder="Select Reviewer" />
                    </SelectTrigger>

                    <SelectContent>
                      {reviewers.map((r) => (
                        <SelectItem key={r.key} value={r.key}>
                          {r.value}
                        </SelectItem>
                      ))}
                    </SelectContent>
                  </Select>

                  <Button
                    onClick={assignReviewer}
                    className="w-full"
                    disabled={!selectedReviewerId}
                  >
                    Assign Reviewer
                  </Button>
                </div>
              </div>
            </>
          )}

          {/* interview round and management */}
          {authState.employeeRoles.includes("Recruiter") && (
            <ApplicationInterviewSection applicationId={applicationId} />
          )}
        </CardContent>
      </Card>
      {/* reviews by reviewer */}
      {authState.employeeRoles.includes("Recruiter") && (
        <ApplicationReviewSection applicationId={applicationId} />
      )}
      {authState.employeeRoles.includes("Reviewer") &&
        myReviewStatus.isAssigned && (
          <div className="container border p-4">
            <h1 className="text-lg font-bold px-4">My Reviews</h1>
            <SkillReviewSection
              disabled={myReviewStatus}
              applicationId={applicationId}
            />
            <Separator />
            <ReviewSection
              disabled={myReviewStatus}
              applicationId={applicationId}
            />
            <Separator />
            <div className="flex justify-center px-4 pt-8">
              <Button
                disabled={myReviewStatus.isReviewCompleted}
                onClick={submitReview}
              >
                {!myReviewStatus.isReviewCompleted
                  ? "Complete Review"
                  : "Completed"}
              </Button>
            </div>
          </div>
        )}
    </div>
  );
};

export default Application;
