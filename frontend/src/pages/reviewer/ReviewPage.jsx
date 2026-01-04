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

const ReviewPage = () => {
  const { applicationId } = useParams();

  const { authState } = useAuth();

  const [applicationSummary, setapplicationSummary] = useState(null);
  const [pdfFile, setPdfFile] = useState(null);
  const [loading, setLoading] = useState(true);

  const onDocumentLoadSuccess = ({ numPages }) => {
    setNumPages(numPages);
  };

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

  const formatDate = (date) =>
    date ? new Date(date).toLocaleDateString("en-GB") : "N/A";

  useEffect(() => {
    getApplicationSummary();
    getCV();
  }, []);

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

      <Card className="w-full">
        <CardHeader>
          <CardTitle>Resume</CardTitle>
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

export default ReviewPage;
