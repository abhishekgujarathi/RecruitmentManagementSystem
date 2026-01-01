import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Button } from "@/components/ui/button";
import { Plus, Trash2, Globe } from "lucide-react";

export default function SocialSection({ formData, setFormData }) {
  const addSocial = () => {
    setFormData({
      ...formData,
      socialLinks: [
        ...formData.socialLinks,
        {
          socialPlatformId: "", // Matches your API payload structure
          url: "",
        },
      ],
    });
  };

  const removeSocial = (index) => {
    const updated = [...formData.socialLinks];
    updated.splice(index, 1);
    setFormData({ ...formData, socialLinks: updated });
  };

  const handleChange = (i, field, value) => {
    const updated = [...formData.socialLinks];
    // Create a fresh copy of the social object at index i
    updated[i] = {
      ...updated[i],
      [field]: value,
    };
    setFormData({ ...formData, socialLinks: updated });
  };

  return (
    <section className="space-y-4">
      <div className="flex items-center gap-2 text-lg font-semibold text-primary">
        <Globe className="h-5 w-5" />
        <h2>Social Links</h2>
      </div>

      {formData.socialLinks.map((link, i) => (
        <Card key={i}>
          <CardHeader className="pb-3">
            <div className="flex justify-between items-start">
              <CardTitle className="text-base">Link #{i + 1}</CardTitle>

              <Button
                variant="ghost"
                size="sm"
                className="text-destructive flex items-center gap-1"
                onClick={() => removeSocial(i)}
              >
                <Trash2 className="h-4 w-4" /> Delete
              </Button>
            </div>
          </CardHeader>

          <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div className="space-y-2">
              <Label>Platform Name</Label>
              <Input
                placeholder="LinkedIn, GitHub, etc."
                value={link.socialPlatformId || ""}
                onChange={(e) =>
                  handleChange(i, "socialPlatformId", e.target.value)
                }
              />
            </div>

            <div className="space-y-2">
              <Label>Profile URL</Label>
              <Input
                placeholder="https://..."
                value={link.url || ""}
                onChange={(e) => handleChange(i, "url", e.target.value)}
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
          onClick={addSocial}
        >
          <Plus className="h-4 w-4" /> Add Social Link
        </Button>
      </div>
    </section>
  );
}
