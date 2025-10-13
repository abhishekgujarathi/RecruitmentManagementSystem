import { useContext } from "react";
import { Menu } from "lucide-react";
import { Button } from "@/components/ui/button";
import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
} from "@/components/ui/navigation-menu";
import {
  Sheet,
  SheetContent,
  SheetHeader,
  SheetTitle,
  SheetTrigger,
} from "@/components/ui/sheet";
import { AuthContext } from "@/context/AuthContext";

const Navbar = ({
  logo = {
    alt: "Logo",
    title: "RPMS",
  },
}) => {
  const { authState, updateAuthState } = useContext(AuthContext);
  const isLoggedIn = !!authState?.token;

  // nav links
  const menu = [
    {
      title: "DashBoard",
      url: !!authState?.token
        ? authState.role === "Candidate"
          ? "/candidate/dashboard"
          : "/recruiter/dashboard"
        : "/login",
    },
    { title: "Jobs", url: "/jobs" },
    // { title: "Resources", url: "/resources" },
    // { title: "Pricing", url: "/pricing" },
    // { title: "Blog", url: "/blog" },
  ];
  const auth = {
    login: { title: "Login", url: "/login" },
    signup: { title: "Sign up", url: "/register" },
    logout: { title: "Logout" },
  };

  const handleLogout = () => {
    updateAuthState({
      user: null,
      token: null,
      refreshToken: null,
      role: null,
      permissions: [],
    });
    localStorage.removeItem("token");
    window.location.href = "/login";
  };

  return (
    <section className="py-4 border-b sticky top-0">
      <div className="container mx-auto px-4">
        <nav className="hidden lg:flex items-center justify-between">
          <a href="/" className="flex items-center gap-2">
            <span className="text-lg font-semibold tracking-tight">
              {logo.title}
            </span>
          </a>

          {/* pc menu */}
          <NavigationMenu>
            <NavigationMenuList className="flex gap-6">
              {menu.map((item) => (
                <NavigationMenuItem key={item.title}>
                  <NavigationMenuLink
                    href={item.url}
                    className="text-sm font-medium hover:text-primary transition-colors"
                  >
                    {item.title}
                  </NavigationMenuLink>
                </NavigationMenuItem>
              ))}
            </NavigationMenuList>
          </NavigationMenu>

          <div className="flex gap-2">
            {!isLoggedIn ? (
              <>
                <Button asChild variant="outline" size="sm">
                  <a href={auth.login.url}>{auth.login.title}</a>
                </Button>
                <Button asChild size="sm">
                  <a href={auth.signup.url}>{auth.signup.title}</a>
                </Button>
              </>
            ) : (
              <Button onClick={handleLogout} size="sm">
                {auth.logout.title}
              </Button>
            )}
          </div>
        </nav>

        {/* mob navbar */}
        <div className="flex items-center justify-between lg:hidden">
          <a href="/" className="flex items-center gap-2">
            <span className="text-lg font-semibold">{logo.title}</span>
          </a>

          <Sheet>
            <SheetTrigger asChild>
              <Button variant="outline" size="icon">
                <Menu className="h-5 w-5" />
              </Button>
            </SheetTrigger>

            <SheetContent side="right" className="p-6">
              <SheetHeader>
                <SheetTitle>{logo.title}</SheetTitle>
              </SheetHeader>

              <div className="flex flex-col gap-4 mt-6">
                {menu.map((item) => (
                  <a
                    key={item.title}
                    href={item.url}
                    className="text-md font-semibold hover:text-primary transition-colors"
                  >
                    {item.title}
                  </a>
                ))}

                <div className="flex flex-col gap-3 mt-6">
                  {!isLoggedIn ? (
                    <>
                      <Button asChild variant="outline">
                        <a href={auth.login.url}>{auth.login.title}</a>
                      </Button>
                      <Button asChild>
                        <a href={auth.signup.url}>{auth.signup.title}</a>
                      </Button>
                    </>
                  ) : (
                    <Button onClick={handleLogout} variant="destructive">
                      {auth.logout.title}
                    </Button>
                  )}
                </div>
              </div>
            </SheetContent>
          </Sheet>
        </div>
      </div>
    </section>
  );
};

export { Navbar };
