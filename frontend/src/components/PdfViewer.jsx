import { useState, useEffect, useRef } from "react";
import { Document, Page } from "react-pdf";

export default function PdfViewer({ pdfFile }) {
  const [numPages, setNumPages] = useState(0);
  const [pageWidth, setPageWidth] = useState(0);
  const containerRef = useRef();

  const onDocumentLoadSuccess = ({ numPages }) => {
    setNumPages(numPages);
  };

  // Update page width whenever container resizes
  useEffect(() => {
    const handleResize = () => {
      if (containerRef.current) {
        setPageWidth(containerRef.current.offsetWidth);
      }
    };

    handleResize();
    window.addEventListener("resize", handleResize);

    return () => window.removeEventListener("resize", handleResize);
  }, []);

  return (
    <div
      className="w-full rounded-lg max-h-96 overflow-y-auto"
      ref={containerRef}
    >
      <Document file={pdfFile} onLoadSuccess={onDocumentLoadSuccess}>
        {Array.from({ length: numPages }, (_, i) => (
          <Page
            key={`page_${i + 1}`}
            pageNumber={i + 1}
            width={pageWidth}
            renderTextLayer={false}
            renderAnnotationLayer={false}
            className="mb-2"
            scale={1}
          />
        ))}
      </Document>
    </div>
  );
}
