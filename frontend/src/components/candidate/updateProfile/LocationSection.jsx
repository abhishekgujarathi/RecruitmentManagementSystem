import { Card, CardContent } from "@/components/ui/card";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { MapPin } from "lucide-react";

export default function LocationSection({ formData, handleChange }) {
  return (
    <section className="space-y-4">
      <div className="flex items-center gap-2 text-lg font-semibold text-primary">
        <MapPin className="h-5 w-5" />
        <h2>Location Details</h2>
      </div>

      <Card>
        <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-6 pt-6">
          <div className="md:col-span-2 space-y-2">
            <Label>Full Address</Label>
            <Textarea
              name="address"
              value={formData.address}
              onChange={handleChange}
              className="resize-none"
            />
          </div>

          <div className="space-y-2">
            <Label>City</Label>
            <Input name="city" value={formData.city} onChange={handleChange} />
          </div>

          <div className="space-y-2">
            <Label>State</Label>
            <Input
              name="state"
              value={formData.state}
              onChange={handleChange}
            />
          </div>

          <div className="space-y-2">
            <Label>Country</Label>
            <Input
              name="country"
              value={formData.country}
              onChange={handleChange}
            />
          </div>

          <div className="space-y-2">
            <Label>Postal Code</Label>
            <Input
              name="postalCode"
              value={formData.postalCode}
              onChange={handleChange}
            />
          </div>
        </CardContent>
      </Card>
    </section>
  );
}
