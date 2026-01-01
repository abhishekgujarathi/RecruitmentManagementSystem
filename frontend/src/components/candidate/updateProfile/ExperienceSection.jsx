import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Button } from "@/components/ui/button";
import { Plus, Trash2, Briefcase } from "lucide-react";

export default function ExperienceSection({ formData, setFormData }) {
  const addExperience = () => {
    setFormData({
      ...formData,
      experiences: [
        ...formData.experiences,
        {
          companyName: "",
          position: "",
          startDate: "",
          endDate: "",
          isCurrent: false,
          description: "",
        },
      ],
    });
  };

  const removeExperience = (index) => {
    const updated = [...formData.experiences];
    updated.splice(index, 1);
    setFormData({ ...formData, experiences: updated });
  };

  const handleChange = (i, field, value) => {
    const updated = [...formData.experiences];
    updated[i][field] = value;
    setFormData({ ...formData, experiences: updated });
  };

  return (
    <section className="space-y-4">
      <div className="flex items-center gap-2 text-lg font-semibold text-primary">
        <Briefcase className="h-5 w-5" />
        <h2>Experience</h2>
      </div>

      {formData.experiences.map((exp, i) => (
        <Card key={i}>
          <CardHeader className="pb-3">
            <div className="flex justify-between items-start">
              <CardTitle className="text-base">Experience #{i + 1}</CardTitle>

              <Button
                variant="ghost"
                size="sm"
                className="text-destructive flex items-center gap-1"
                onClick={() => removeExperience(i)}
              >
                <Trash2 className="h-4 w-4" /> Delete
              </Button>
            </div>
          </CardHeader>

          <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div className="space-y-2 md:col-span-2">
              <Label>Company Name</Label>
              <Input
                value={exp.companyName}
                onChange={(e) => handleChange(i, "companyName", e.target.value)}
              />
            </div>

            <div className="space-y-2">
              <Label>Job Title</Label>
              <Input
                value={exp.position}
                onChange={(e) => handleChange(i, "position", e.target.value)}
              />
            </div>

            <div className="space-y-2">
              <Label>Start Date</Label>
              <Input
                type="date"
                value={exp.startDate ? exp.startDate.split("T")[0] : ""}
                onChange={(e) => handleChange(i, "startDate", e.target.value)}
              />
            </div>

            <div className="space-y-2">
              <Label>End Date</Label>
              <Input
                type="date"
                value={exp.endDate ? exp.endDate.split("T")[0] : ""}
                onChange={(e) => handleChange(i, "endDate", e.target.value)}
                disabled={exp.isCurrent}
              />
            </div>

            <div className="flex items-center gap-2 md:col-span-2">
              <input
                type="checkbox"
                checked={exp.isCurrent}
                onChange={(e) => handleChange(i, "isCurrent", e.target.checked)}
                className="accent-primary"
              />
              <Label>Currently Working</Label>
            </div>

            <div className="space-y-2 md:col-span-2">
              <Label>Description</Label>
              <Input
                value={exp.description}
                onChange={(e) => handleChange(i, "description", e.target.value)}
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
          onClick={addExperience}
        >
          <Plus className="h-4 w-4" /> Add Experience
        </Button>
      </div>
    </section>
  );
}
