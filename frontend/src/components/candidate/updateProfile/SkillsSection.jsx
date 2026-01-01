import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Button } from "@/components/ui/button";
import { Plus, Trash2, Zap } from "lucide-react";
import SkillComboBox from "../../shared/skillComboBox";

export default function SkillsSection({ formData, setFormData }) {
  console.log(formData.skills);

  const addSkill = () => {
    setFormData({
      ...formData,
      skills: [
        ...formData.skills,
        {
          skillId: "",
          experienceYears: "",
          proficiencyLevel: "",
        },
      ],
    });
  };

  const removeSkill = (index) => {
    const updated = [...formData.skills];
    updated.splice(index, 1);
    setFormData({ ...formData, skills: updated });
  };

  const handleChange = (i, field, value, name) => {
    const updated = [...formData.skills];

    // Create a fresh copy of the skill object at index i
    if (field === "skillId") {
      updated[i] = {
        ...updated[i],
        skillId: value,
        name: name,
      };
    } else {
      updated[i] = {
        ...updated[i],
        [field]: value,
      };
    }

    setFormData({ ...formData, skills: updated });
  };

  return (
    <section className="space-y-4">
      <div className="flex items-center gap-2 text-lg font-semibold text-primary">
        <Zap className="h-5 w-5" />
        <h2>Skills</h2>
      </div>

      {formData.skills.map((skill, i) => (
        <Card key={i}>
          <CardHeader className="pb-3">
            <div className="flex justify-between items-start">
              <CardTitle className="text-base">Skill #{i + 1}</CardTitle>

              <Button
                variant="ghost"
                size="sm"
                className="text-destructive flex items-center gap-1"
                onClick={() => removeSkill(i)}
              >
                <Trash2 className="h-4 w-4" /> Delete
              </Button>
            </div>
          </CardHeader>

          <CardContent className="grid grid-cols-1 md:grid-cols-3 gap-4">
            <div className="space-y-2">
              <Label>Skill Name</Label>
              <SkillComboBox
                value={skill.skillId}
                intialLabel={skill.name}
                onChange={(skillId, skillName) =>
                  handleChange(i, "skillId", skillId, skillName)
                }
              />
            </div>

            <div className="space-y-2">
              <Label>Experience (Years)</Label>
              <Input
                type="number"
                min="0"
                value={skill.experienceYears}
                onChange={(e) =>
                  handleChange(i, "experienceYears", e.target.value)
                }
              />
            </div>

            <div className="space-y-2">
              <Label>Proficiency Level</Label>
              <Input
                placeholder="Beginner / Intermediate / Expert"
                value={skill.proficiencyLevel}
                onChange={(e) =>
                  handleChange(i, "proficiencyLevel", e.target.value)
                }
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
          onClick={addSkill}
        >
          <Plus className="h-4 w-4" /> Add Skill
        </Button>
      </div>
    </section>
  );
}
