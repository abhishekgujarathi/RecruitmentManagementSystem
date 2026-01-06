import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { useState } from "react";

export default function ApplicantsTable({
  applicants,
  stageTitle,
  nextStage,
  onBulkStatusChange,
}) {
  const [search, setSearch] = useState("");
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [selected, setSelected] = useState([]);

  const filtered = applicants.filter((a) => {
    const matchesSearch = `${a.candidateName}`
      .toLowerCase()
      .includes(search.toLowerCase());
    const appliedDate = new Date(a.applicationDate);
    const matchesFrom = !fromDate || appliedDate >= new Date(fromDate);
    const matchesTo = !toDate || appliedDate <= new Date(toDate);
    return matchesSearch && matchesFrom && matchesTo;
  });

  const toggleSelect = (id) =>
    setSelected((prev) =>
      prev.includes(id) ? prev.filter((x) => x !== id) : [...prev, id]
    );

  const toggleSelectAll = () => {
    if (selected.length === filtered.length) {
      setSelected([]);
    } else {
      setSelected(filtered.map((a) => a.jobApplicationId));
    }
  };

  const handleBulkMove = () => {
    if (selected.length === 0 || !nextStage) return;

    onBulkStatusChange(selected, nextStage.value);

    setSelected([]);
  };
  
  const disabled = !(nextStage && selected.length > 0);

  return (
    <section className="space-y-4">
      {stageTitle && <h3 className="text-lg font-medium">{stageTitle}</h3>}

      <div className="flex flex-wrap gap-3 items-center mb-2">
        <Input
          placeholder="Search name"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          className="max-w-sm"
        />
        <Input
          type="date"
          value={fromDate}
          onChange={(e) => setFromDate(e.target.value)}
          className="w-[160px]"
        />
        <Input
          type="date"
          value={toDate}
          onChange={(e) => setToDate(e.target.value)}
          className="w-[160px]"
        />

        <Button
          disabled={disabled}
          onClick={handleBulkMove}
          className="ml-auto"
        >
          Move {selected.length} to {nextStage.name}
        </Button>
      </div>

      <div className="border rounded-md max-h-[400px] overflow-y-auto">
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>
                <input
                  type="checkbox"
                  checked={
                    selected.length === filtered.length && filtered.length > 0
                  }
                  onChange={toggleSelectAll}
                />
              </TableHead>
              <TableHead>Candidate</TableHead>
              <TableHead>Applied On</TableHead>
              <TableHead>Status</TableHead>
              <TableHead> Status Updated At</TableHead>
              <TableHead className="text-right">Actions</TableHead>
            </TableRow>
          </TableHeader>

          <TableBody>
            {filtered.length === 0 ? (
              <TableRow>
                <TableCell
                  colSpan={5}
                  className="text-center text-muted-foreground"
                >
                  No applicants found
                </TableCell>
              </TableRow>
            ) : (
              filtered.map((a) => (
                <TableRow key={a.jobApplicationId}>
                  <TableCell>
                    <input
                      type="checkbox"
                      checked={selected.includes(a.jobApplicationId)}
                      onChange={() => toggleSelect(a.jobApplicationId)}
                    />
                  </TableCell>

                  <TableCell>
                    <div className="font-medium">{a.candidateName}</div>
                    <div className="text-sm text-muted-foreground">
                      {a.email}
                    </div>
                  </TableCell>

                  <TableCell>
                    {new Date(a.applicationDate).toLocaleDateString()}
                  </TableCell>

                  <TableCell className="capitalize">
                    {a.currentStatus}
                  </TableCell>

                  <TableCell className="capitalize">
                    {new Date(a.statusUpdatedAt).toLocaleDateString()}
                  </TableCell>

                  <TableCell className="text-right">
                    <Button size="sm" asChild>
                      <a href={`/employee/applications/${a.applicationId}`}>
                        View
                      </a>
                    </Button>
                  </TableCell>
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>
      </div>
    </section>
  );
}
