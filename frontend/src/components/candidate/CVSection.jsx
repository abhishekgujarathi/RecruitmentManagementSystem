import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import api from "../../services/api";
import CVViwer from "../shared/CVViwer";

const CVSection = () => {
  const [cv, setCv] = useState(null);
  const [loading, setLoading] = useState(false);
  const [cvView, setCvView] = useState(false);

  const fetchCv = async () => {
    try {
      const res = await api.get("/Candidate/cv");

      console.log("fetch cv -", res);
      if (res.status == 200) {
        const data = res.data;
        setCv(data);
      } else {
        setCv(null);
      }
    } catch (err) {
      console.error("Failed to fetch CV", err);
    }
  };

  useEffect(() => {
    fetchCv();
  }, []);

  const handleUpload = async (e) => {
    const file = e.target.files[0];
    if (!file) return;

    const formData = new FormData();
    formData.append("file", file);

    setLoading(true);

    try {
      const res = await api.post("/Candidate/cv", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });

      console.log("upload cv", res);
      if (res.status === 200) {
        await fetchCv();
      } else {
        console.error("Upload failed", await res.text());
      }
    } catch (err) {
      console.error("Upload failed", err);
    } finally {
      setLoading(false);
    }
  };

  const handleDelete = async () => {
    setLoading(true);
    try {
      const res = await fetch("https://localhost:7081/api/Candidate/cv", {
        method: "DELETE",
        credentials: "include",
      });

      if (res.ok) {
        setCv(null);
      }
    } catch (err) {
      console.error("Delete failed", err);
    } finally {
      setLoading(false);
    }
  };

  const handleView = async () => {
    setCvView(!cvView);
  };

  return (
    <>
      <Card className="p-4">
        <CardHeader>
          <CardTitle>CVs / Documents</CardTitle>
        </CardHeader>

        <CardContent className="flex flex-col gap-2">
          {cv ? (
            <div className="flex items-center gap-2">
              <span>CV.pdf</span>

              {cv.url && (
                <Button variant="outline" size="sm" onClick={handleView}>
                  View
                </Button>
              )}

              <Button
                variant="destructive"
                size="sm"
                onClick={handleDelete}
                disabled={loading}
              >
                Delete
              </Button>

              <label>
                <input
                  type="file"
                  accept="application/pdf"
                  hidden
                  onChange={handleUpload}
                />
                <Button asChild variant="outline" size="sm" disabled={loading}>
                  <span>Upload New</span>
                </Button>
              </label>
            </div>
          ) : (
            <label>
              <input
                type="file"
                accept="application/pdf"
                hidden
                onChange={handleUpload}
              />
              <Button asChild variant="outline" size="sm" disabled={loading}>
                <span>Upload New</span>
              </Button>
            </label>
          )}
        </CardContent>
      </Card>
      {cvView && <CVViwer onClose={() => setCvView(false)} />}
    </>
  );
};

export default CVSection;
