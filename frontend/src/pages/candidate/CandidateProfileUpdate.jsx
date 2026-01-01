"use client";

import { useState, useEffect } from "react";
import LocationSection from "../../components/candidate/updateProfile/LocationSection";
import EducationSection from "../../components/candidate/updateProfile/EducationSection";
import ExperienceSection from "../../components/candidate/updateProfile/ExperienceSection";
import SkillsSection from "../../components/candidate/updateProfile/SkillsSection";
import SocialSection from "../../components/candidate/updateProfile/SocialSection";
import { Button } from "@/components/ui/button";
import api from "../../services/api";
import { toast } from "sonner";

// ??? also show personal details like mob email dob

// ---- EMPTY STRUCTS ---- //
const EMPTY_EDUCATION = {
  instituteName: "",
  degreeType: "",
  fieldOfStudy: "",
  percentageScore: "",
  startDate: "",
  endDate: "",
  isCurrent: false,
};

const EMPTY_EXPERIENCE = {
  companyName: "",
  position: "",
  startDate: "",
  endDate: "",
  isCurrent: false,
  description: "",
};

const EMPTY_SKILL = {
  skillId: "",
  experienceYears: "",
  proficiencyLevel: "",
};

const EMPTY_SOCIAL = {
  socialPlatformId: "",
  url: "",
};

// ---- MAIN COMPONENT ---- //
export default function CandidateProfileUpdate() {
  const [formData, setFormData] = useState({
    address: "",
    city: "",
    state: "",
    country: "",
    postalCode: "",
    educations: [EMPTY_EDUCATION],
    experiences: [EMPTY_EXPERIENCE],
    skills: [EMPTY_SKILL],
    socialLinks: [EMPTY_SOCIAL],
  });

  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  // -------------------------------------------------------
  // FETCH CANDIDATE PROFILE ON PAGE LOAD
  // -------------------------------------------------------
  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const res = await api.get("Candidate/profile");
        const data = await res.data;

        console.log("profile update fetch", data);

        setFormData({
          address: data.address || "",
          city: data.city || "",
          state: data.state || "",
          country: data.country || "",
          postalCode: data.postalCode || "",
          educations:
            data.educations?.length > 0 ? data.educations : [EMPTY_EDUCATION],
          experiences:
            data.experiences?.length > 0
              ? data.experiences
              : [EMPTY_EXPERIENCE],
          skills:
            data.candidateSkills?.length > 0
              ? data.candidateSkills
              : [EMPTY_SKILL],
          socialLinks:
            data.socialLinks?.length > 0 ? data.socialLinks : [EMPTY_SOCIAL],
        });

        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    };

    fetchProfile();
  }, []);

  // -------------------------------------------------------
  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);

    try {
      // Prepare payload
      const payload = {
        address: formData.address || null,
        city: formData.city || null,
        state: formData.state || null,
        country: formData.country || null,
        postalCode: formData.postalCode || null,

        educations: formData.educations.map((edu) => ({
          educationId: edu.educationId || 0,
          instituteName: edu.instituteName || "",
          degreeType: edu.degreeType || null,
          fieldOfStudy: edu.fieldOfStudy || null,
          percentageScore: edu.percentageScore
            ? parseFloat(edu.percentageScore)
            : null,
          startDate: edu.startDate || null,
          endDate: edu.endDate || null,
          isCurrent: edu.isCurrent || false,
        })),

        experiences: formData.experiences.map((exp) => ({
          experienceId: exp.experienceId || 0,
          companyName: exp.companyName || "",
          position: exp.position || "",
          startDate: exp.startDate || null,
          endDate: exp.endDate || null,
          isCurrent: exp.isCurrent || false,
          description: exp.description || null,
        })),

        candidateSkills: formData.skills
          .filter((skill) => skill.skillId && skill.skillId.trim() !== "")
          .map((skill) => ({
            skillId: skill.skillId,
            name: skill.name || null,
            experienceYears: skill.experienceYears
              ? parseInt(skill.experienceYears)
              : 0,
            proficiencyLevel: skill.proficiencyLevel || null,
          })),

        socialLinks: formData.socialLinks
          .filter(
            (social) =>
              social.socialPlatformId && social.socialPlatformId.trim() !== ""
          )
          .map((social) => ({
            socialPlatformId: social.socialPlatformId,
            url: social.url || null,
          })),
      };

      console.log("Submitting Payload:", payload);

      // API call
      await api.put("/Candidate/profile", payload);
      toast.success("Profile updated successfully!");
    } catch (err) {
      console.error("Error updating profile:", err);
      toast.error("Failed to update profile. Check console for details.");
    } finally {
      setLoading(false);
    }
  };

  if (loading) return <p className="p-4">Loading profile...</p>;
  if (error)
    return <p className="p-4 text-red-600 font-semibold">Error: {error}</p>;

  // -------------------------------------------------------
  // UI
  // -------------------------------------------------------
  return (
    <div className="w-full max-w-5xl mx-auto p-4 space-y-6">
      <LocationSection formData={formData} setFormData={setFormData} />

      <EducationSection
        formData={formData}
        setFormData={setFormData}
        EMPTY_EDUCATION={EMPTY_EDUCATION}
      />

      <ExperienceSection
        formData={formData}
        setFormData={setFormData}
        EMPTY_EXPERIENCE={EMPTY_EXPERIENCE}
      />

      <SkillsSection
        formData={formData}
        setFormData={setFormData}
        EMPTY_SKILL={EMPTY_SKILL}
      />

      <SocialSection
        formData={formData}
        setFormData={setFormData}
        EMPTY_SOCIAL={EMPTY_SOCIAL}
      />

      <Button className="mt-4 w-full" onClick={handleSubmit}>
        Save Profile
      </Button>
    </div>
  );
}
