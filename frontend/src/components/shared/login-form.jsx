import { cn } from "@/lib/utils";
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
import { useContext, useState } from "react";
import api from "../../services/api";
import { AuthContext } from "../../context/AuthContext";

import { jwtDecode } from "jwt-decode";

export function LoginForm({ className, ...props }) {
  const { login } = useContext(AuthContext);

  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  const handleChange = (e) => {
    const { id, value } = e.target;
    setFormData((prev) => ({ ...prev, [id]: value }));
  };

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const response = await api.post("/Auth/login", formData);
      const token = response.data.authToken;

      const decoded = jwtDecode(token);

      let userType = null;
      let employeeRoles = [];

      // depends if role is arr or string[single]
      const roleClaimKey =
        "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"; // this is a must to check
      const roles = Array.isArray(decoded[roleClaimKey])
        ? decoded[roleClaimKey]
        : [decoded[roleClaimKey]];

      if (roles.includes("Candidate")) {
        userType = "Candidate";
        employeeRoles = [];
      } else if (roles.includes("Employee")) {
        userType = "Employee";
        // flitr out employee roles
        employeeRoles = roles.filter((r) => r !== "Employee");
      } else {
        // last try else null
        userType = roles[0] || null;
        employeeRoles = ["aa"];
      }

      // if (roles) {
      //   userType = [decoded];
      // }

      // update context and localStorage
      login({ token, role: userType, employeeRoles: employeeRoles });
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className={cn("flex flex-col gap-6", className)} {...props}>
      <Card>
        <CardHeader>
          <CardTitle>Login to your account</CardTitle>
          <CardDescription>
            Enter your email below to login to your account
          </CardDescription>
        </CardHeader>
        <CardContent>
          <form onSubmit={handleLogin}>
            <FieldGroup>
              <Field>
                <FieldLabel htmlFor="email">Email</FieldLabel>
                <Input
                  id="email"
                  type="email"
                  placeholder="m@example.com"
                  required
                  value={formData.email}
                  onChange={handleChange}
                />
              </Field>

              <Field>
                <div className="flex items-center">
                  <FieldLabel htmlFor="password">Password</FieldLabel>
                  <a
                    href="#"
                    className="ml-auto inline-block text-sm underline-offset-4 hover:underline"
                  >
                    Forgot your password?
                  </a>
                </div>
                <Input
                  id="password"
                  type="password"
                  required
                  value={formData.password}
                  onChange={handleChange}
                />
              </Field>

              <Field>
                <Button type="submit">Login</Button>
                <FieldDescription className="text-center">
                  Don&apos;t have an account? <a href="#">Sign up</a>
                </FieldDescription>
              </Field>
            </FieldGroup>
          </form>
        </CardContent>
      </Card>
    </div>
  );
}
