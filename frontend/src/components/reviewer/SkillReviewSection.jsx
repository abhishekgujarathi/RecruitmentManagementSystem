import { useEffect, useState } from "react";
import { Card } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import axios from "axios";
import api from "../../services/api";
import { toast } from "sonner";

const SkillReviewSection = ({ applicationId }) => {
  const [skills, setSkills] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    api
      .get(`Applications/${applicationId}/skills`)
      .then((res) => setSkills(res.data))
      .catch(console.error);
  }, [applicationId]);

  const toggleSkill = (skillId) => {
    setSkills((prev) =>
      prev.map((s) =>
        s.skillId === skillId
          ? {
              ...s,
              hasSkill: !s.hasSkill,
              yearsOfExperience: s.hasSkill ? null : s.yearsOfExperience,
            }
          : s
      )
    );
  };

  const updateExperience = (skillId, value) => {
    setSkills((prev) =>
      prev.map((s) =>
        s.skillId === skillId ? { ...s, yearsOfExperience: value } : s
      )
    );
  };

  const updateSkills = async () => {
    setLoading(true);
    try {
      await api.post(
        `Applications/${applicationId}/skills`,
        skills.map((s) => ({
          skillId: s.skillId,
          hasSkill: s.hasSkill ?? false,
          yearsOfExperience: s.hasSkill ? Number(s.yearsOfExperience) : null,
        }))
      );
      toast.success("Skill Review Updated!");
    } finally {
      setLoading(false);
    }
  };

  return (
    <>
      <Card className="p-4 space-y-4">
        <h3 className="font-semibold">Skill Review</h3>

        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
          {skills.map((skill) => (
            <div
              key={skill.skillId}
              className="flex items-center gap-3 text-sm border rounded p-3"
            >
              <input
                type="checkbox"
                checked={!!skill.hasSkill}
                onChange={() => toggleSkill(skill.skillId)}
              />

              <div className="flex-1">
                <div className="font-medium">{skill.skillName}</div>
                <div className="text-xs text-muted-foreground">
                  Min required: {skill.minExperienceYears} yrs
                </div>
              </div>

              {skill.hasSkill && (
                <input
                  type="number"
                  min="0"
                  className="w-20 border rounded px-2 py-1 text-sm"
                  placeholder="Yrs"
                  value={skill.yearsOfExperience ?? ""}
                  onChange={(e) =>
                    updateExperience(skill.skillId, e.target.value)
                  }
                />
              )}
            </div>
          ))}
        </div>

        <Button onClick={updateSkills} disabled={loading}>
          {loading ? "Saving..." : "Update Skills"}
        </Button>
      </Card>
    </>
  );
};

export default SkillReviewSection;
