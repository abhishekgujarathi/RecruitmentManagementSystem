import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Button } from "@/components/ui/button";
import { Plus, Trash2, GraduationCap } from "lucide-react";

export default function EducationSection({
  formData,
  addItem,
  removeItem,
  handleNestedChange,
  EMPTY_EDUCATION,
}) {
  return (
    <section className="space-y-4">
      <div className="flex items-center gap-2 text-lg font-semibold text-primary">
        <GraduationCap className="h-5 w-5" />
        <h2>Education</h2>
      </div>

      {formData.educations.map((edu, i) => (
        <Card key={i}>
          <CardHeader className="pb-3">
            <div className="flex justify-between items-start">
              <CardTitle className="text-base">Education #{i + 1}</CardTitle>

              <Button
                variant="ghost"
                size="sm"
                className="text-destructive flex items-center gap-1"
                onClick={() => removeItem("educations", i)}
              >
                <Trash2 className="h-4 w-4" /> Delete
              </Button>
            </div>
          </CardHeader>

          <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div className="space-y-2 md:col-span-2">
              <Label>Institute Name</Label>
              <Input
                name="instituteName"
                value={edu.instituteName}
                onChange={(e) => handleNestedChange("educations", i, e)}
              />
            </div>

            <div className="space-y-2">
              <Label>Degree Type</Label>
              <Input
                name="degreeType"
                value={edu.degreeType}
                onChange={(e) => handleNestedChange("educations", i, e)}
              />
            </div>

            <div className="space-y-2">
              <Label>Field of Study</Label>
              <Input
                name="fieldOfStudy"
                value={edu.fieldOfStudy}
                onChange={(e) => handleNestedChange("educations", i, e)}
              />
            </div>

            <div className="space-y-2">
              <Label>Score / CGPA</Label>
              <Input
                name="percentageScore"
                value={edu.percentageScore}
                onChange={(e) => handleNestedChange("educations", i, e)}
              />
            </div>

            <div className="space-y-2">
              <Label>Start Date</Label>
              <Input
                type="date"
                name="startDate"
                value={edu.startDate?.split("T")[0] || ""}
                onChange={(e) => handleNestedChange("educations", i, e)}
              />
            </div>

            <div className="space-y-2">
              <Label>End Date</Label>
              <Input
                type="date"
                name="endDate"
                value={edu.endDate?.split("T")[0] || ""}
                onChange={(e) => handleNestedChange("educations", i, e)}
              />
            </div>
          </CardContent>
        </Card>
      ))}

      <div className="flex justify-center mt-2">
        <Button
          variant="outline"
          size="sm"
          className="flex items-center gap-2"
          onClick={() => addItem("educations", EMPTY_EDUCATION)}
        >
          <Plus className="h-4 w-4" /> Add Education
        </Button>
      </div>
    </section>
  );
}
