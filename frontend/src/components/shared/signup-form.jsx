import { useState } from "react";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  Field,
  FieldDescription,
  FieldGroup,
  FieldLabel,
} from "@/components/ui/field";
import { Input } from "@/components/ui/input";
import api from "@/services/api";
import { toast } from "sonner";
import { useNavigate } from "react-router-dom";

export function SignupForm({ ...props }) {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    fname: "",
    lname: "",
    email: "",
    password: "",
    role: "Candidate",
    mobileNumber: "",
    dob: "",
    gender: "",
  });

  const handleChange = (e) => {
    const { id, value } = e.target;
    setFormData((prev) => ({ ...prev, [id]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await api.post("/Auth/register", formData);
      console.log("Registration success:", response.data);
      toast("succussfully registered");
      navigate("/login");
    } catch (error) {
      console.error(
        "Registration failed:",
        error.response?.data || error.message
      );
      toast.error("user already exists or invalid inputs.");
    }
  };

  return (
    <Card {...props}>
      <CardHeader>
        <CardTitle>Create an account</CardTitle>
        <CardDescription>
          Enter your information below to create your account
        </CardDescription>
      </CardHeader>
      <CardContent>
        <form onSubmit={handleSubmit}>
          <FieldGroup>
            <Field>
              <FieldLabel htmlFor="fname">First Name</FieldLabel>
              <Input
                id="fname"
                type="text"
                placeholder="John"
                value={formData.fname}
                onChange={handleChange}
                required
              />
            </Field>
            <Field>
              <FieldLabel htmlFor="lname">Last Name</FieldLabel>
              <Input
                id="lname"
                type="text"
                placeholder="Doe"
                value={formData.lname}
                onChange={handleChange}
                required
              />
            </Field>
            <Field>
              <FieldLabel htmlFor="email">Email</FieldLabel>
              <Input
                id="email"
                type="email"
                placeholder="m@example.com"
                value={formData.email}
                onChange={handleChange}
                required
              />
            </Field>
            <Field>
              <FieldLabel htmlFor="password">Password</FieldLabel>
              <Input
                id="password"
                type="password"
                value={formData.password}
                onChange={handleChange}
                required
              />
            </Field>
            <Field>
              <FieldLabel htmlFor="mobileNumber">Mobile Number</FieldLabel>
              <Input
                id="mobileNumber"
                type="tel"
                placeholder="1234567890"
                value={formData.mobileNumber}
                onChange={handleChange}
                required
              />
            </Field>
            <Field>
              <FieldLabel htmlFor="dob">Date of Birth</FieldLabel>
              <Input
                id="dob"
                type="date"
                value={formData.dob}
                onChange={handleChange}
              />
            </Field>
            <Field>
              <FieldLabel htmlFor="gender">Gender</FieldLabel>
              <Input
                id="gender"
                type="text"
                placeholder="Male/Female/Other"
                value={formData.gender}
                onChange={handleChange}
              />
            </Field>
            <FieldGroup>
              <Field>
                <Button type="submit">Create Account</Button>
                <FieldDescription className="px-6 text-center">
                  Already have an account? <a href="#">Sign in</a>
                </FieldDescription>
              </Field>
            </FieldGroup>
          </FieldGroup>
        </form>
      </CardContent>
    </Card>
  );
}
