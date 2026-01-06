import { useEffect, useState } from "react";
import api from "../../services/api";
import { toast } from "sonner";

const STATUSES = [
  "Applied",
  "UnderReview",
  "Shortlisted",
  "TestScheduled",
  "TestPassed",
  "InterviewScheduled",
  "InterviewCompleted",
  "Hired",
  "Rejected",
  "OnHold",
];

export default function ChangeStatusButton({ applicationId, currentStatus }) {
  const [status, setStatus] = useState(currentStatus);
  const [note, setNote] = useState("");
  const [loading, setLoading] = useState(false);

  const handleChangeStatus = async () => {
    if (!status) {
      toast("Please select a status");
      return;
    }

    if (status === "OnHold" && !note.trim()) {
      toast("Note is required when status is OnHold");
      return;
    }

    try {
      setLoading(true);

      await api.patch(`Applications/${applicationId}/status`, {
        newStatus: status,
        note: status === "OnHold" ? note : null,
      });

      toast("Status updated successfully");
      setStatus("");
      setNote("");
    } catch (error) {
      console.error("Error updating status:", error);

      if (error.response) {
        toast(error.response.data);
      } else {
        toast("Something went wrong");
      }
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    setStatus(currentStatus);
  }, []);

  return (
    <div className="border rounded-md w-3/4">
      <select
        value={status}
        onChange={(e) => setStatus(e.target.value)}
        className="w-full border rounded-md px-3 py-2 text-sm"
      >
        {console.log(currentStatus)}
        <option value="">Select status</option>
        {STATUSES.map((s) => (
          <option key={s} value={s}>
            {s}
          </option>
        ))}
      </select>

      {status === "OnHold" && (
        <textarea
          value={note}
          onChange={(e) => setNote(e.target.value)}
          placeholder="Enter reason for On Hold"
          className="w-full border rounded-md px-3 py-2 text-sm"
          rows={3}
        />
      )}

      <button
        onClick={handleChangeStatus}
        disabled={loading}
        className="w-full border border-gray-300 rounded-md py-2 text-sm hover:bg-gray-100 transition disabled:opacity-50"
      >
        {loading ? "Updating..." : "Change Status"}
      </button>
    </div>
  );
}
