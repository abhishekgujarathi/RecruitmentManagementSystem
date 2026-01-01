import { useEffect, useState } from "react";
import { Document, Page, pdfjs } from "react-pdf";
import api from "../../services/api";
import { X } from "lucide-react";

pdfjs.GlobalWorkerOptions.workerSrc = new URL(
  "pdfjs-dist/build/pdf.worker.min.mjs",
  import.meta.url
).toString();

const CVViwer = ({ onClose }) => {
  const [pdfFile, setPdfFile] = useState(null);
  const [numPages, setNumPages] = useState(1);
  const [pageNumber, setPageNumber] = useState(1);

  const getCV = async () => {
    const res = await api.get("/Candidate/cv/download", {
      responseType: "blob",
    });
    console.log("download cv -", res);
    if (res.status == 200) {
      const fileURL = URL.createObjectURL(res.data);
      setPdfFile(fileURL);
    }
  };

  useEffect(() => {
    getCV();
  }, []);

  const onDocumentLoadSuccess = ({ numPages }) => {
    setNumPages(numPages);
  };

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black/60">
      <div className="bg-gray-700 w-5/6 h-5/6 rounded-lg shadow-xl flex flex-col relative">
        <div className="flex items-center justify-between px-4 py-3 border-b">
          <h2 className="text-lg font-semibold text-white">CV Preview</h2>

          <button
            onClick={onClose}
            className="p-2 rounded-md hover:bg-gray-500"
          >
            <X className="w-5 h-5 text-white" />
          </button>
        </div>

        <div className="flex-1 overflow-auto flex justify-center bg-gray-400 p-4">
          <Document file={pdfFile} onLoadSuccess={onDocumentLoadSuccess}>
            {console.log(numPages)}
            {Array.from({ length: numPages }, (_, idx) => {
              return (
                <Page
                  key={`page_${idx + 1}`}
                  pageNumber={idx + 1}
                  scale={1.5}
                  devicePixelRatio={window.devicePixelRatio || 1}
                  renderTextLayer={false}
                  renderAnnotationLayer={false}
                  className="mb-2"
                />
              );
            })}
          </Document>
        </div>
      </div>
    </div>
  );
};

export default CVViwer;
