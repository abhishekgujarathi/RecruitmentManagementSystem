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

const RecruiterCandidateView = () => {
  const { applicationId } = useParams();

  const [applicationSummary, setapplicationSummary] = useState(null);
  const [pdfFile, setPdfFile] = useState(null);
  const [numPages, setNumPages] = useState(1);
  const [pageNumber, setPageNumber] = useState(1);
  const [loading, setLoading] = useState(true);
  const [reviewers, setReviewers] = useState([]);
  const [appliReviewers, setAppliReviewers] = useState([]);

  const [selectedReviewerId, setSelectedReviewerId] = useState("");

  const onDocumentLoadSuccess = ({ numPages }) => {
    setNumPages(numPages);
  };

  const getApplicationSummary = async () => {
    try {
      const res = await api.get(`Recruiters/applications/${applicationId}`);
      console.log(res.data);
      setapplicationSummary(res.data);
    } catch (err) {
      console.error("Failed to fetch profile:", err);
    } finally {
      setLoading(false);
    }
  };

  const getCV = async () => {
    const res = await api.get(`Recruiters/applications/${applicationId}/cv`, {
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
      const res = await api.get(
        `Recruiters/applications/${applicationId}/reviewers`
      );
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
      const res = await api.get(`/Reviewers/`, { params: applicationId });
      setReviewers(res.data);
    } catch (err) {
      console.error("Failed to fetch profile:", err);
    } finally {
      setLoading(false);
    }
  };

  const formatDate = (date) =>
    date ? new Date(date).toLocaleDateString("en-GB") : "N/A";

  useEffect(() => {
    getApplicationSummary();
    getCV();
    getApplicationReviewers();
    getReviewerList();
  }, []);

  const assignReviewer = async () => {
    if (!selectedReviewerId) return;

    const res = await api.post(
      `Recruiters/applications/${applicationId}/reviewers`,
      {
        reviewerId: selectedReviewerId,
      }
    );

    if (res.status == 200) {
      getApplicationReviewers();
      setReviewers([]);
      getReviewerList();
      alert("Reviewer Added");
    }
  };

  if (loading)
    return <div className="text-center py-10">Loading profile...</div>;
  if (!applicationSummary)
    return <div className="text-center py-10">Profile not found</div>;

  return (
    <div className="w-full mx-auto">
      <Card className="shadow-sm">
        <CardHeader>
          <div className="flex items-center justify-between">
            <CardTitle className="text-xl">
              {applicationSummary.fullName}
            </CardTitle>
            <div>{applicationSummary.currentStatus}</div>
          </div>
          <p className="text-sm text-muted-foreground">
            Applied on{" "}
            {new Date(applicationSummary.applicationDate).toLocaleDateString()}
          </p>
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

        <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div className="border rounded-lg p-4">
            <h3 className="font-semibold mb-2">Resume</h3>

            <Document file={pdfFile} onLoadSuccess={onDocumentLoadSuccess}>
              <Page
                key={`page_`}
                pageNumber={1}
                scale={0.7}
                devicePixelRatio={window.devicePixelRatio || 1}
                renderTextLayer={false}
                renderAnnotationLayer={false}
                className="mb-2"
              />
            </Document>

            <Button className="mt-3 w-full" variant="outline">
              Download CV
            </Button>
          </div>

          <div className="border rounded-lg p-4">
            <h3 className="font-semibold mb-4">Assigned Reviewers</h3>

            {loading ? (
              <p>Loading reviewers...</p>
            ) : appliReviewers?.length === 0 ? (
              <p className="text-sm text-muted-foreground">
                No appliReviewers assigned
              </p>
            ) : (
              <ul className="space-y-3">
                {appliReviewers?.length > 0 &&
                  appliReviewers.map((r) => (
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
                          Assigned On: {formatDate(r.assignedDate) ?? "error"}
                        </span>
                        <span className="text-xs">
                          Reviewed On: {formatDate(r.reviewedOn) ?? "Pending"}
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
        </CardContent>
      </Card>

      {/* reviews by reviewer */}
      <Card className="w-full">
        <CardHeader>
          <CardTitle>Reviewes</CardTitle>
        </CardHeader>

        <CardContent></CardContent>
      </Card>
    </div>
  );
};

export default RecruiterCandidateView;
