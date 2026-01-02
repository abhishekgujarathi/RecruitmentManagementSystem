import { createContext, useState, useEffect } from "react";

export const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
  const [authState, setAuthState] = useState({
    user: null,
    token: null,
    refreshToken: null,
    // candi/empl
    role: null,
    // inter/rev/recr
    employeeRoles: [], // aded this new for rec/rev/int
    isLoading: true,
    error: null,
  });

  useEffect(() => {
    const savedToken = localStorage.getItem("token");
    const savedRefreshToken = localStorage.getItem("refreshToken");
    const savedUser = localStorage.getItem("user");
    const savedUserType = localStorage.getItem("role");
    const savedEmployeeRoles = localStorage.getItem("employeeRoles");

    if (savedToken) {
      setAuthState({
        user: savedUser ? JSON.parse(savedUser) : null,
        token: savedToken,
        refreshToken: savedRefreshToken,
        role: savedUserType || null,
        employeeRoles: savedEmployeeRoles ? JSON.parse(savedEmployeeRoles) : [],
        isLoading: false,
        error: null,
      });
    } else {
      setAuthState((prev) => ({ ...prev, isLoading: false }));
    }
  }, []);

  const login = ({ token, refreshToken, user, role, employeeRoles }) => {
    if (token) localStorage.setItem("token", token);
    if (refreshToken) localStorage.setItem("refreshToken", refreshToken);
    if (user) localStorage.setItem("user", JSON.stringify(user));
    if (role) localStorage.setItem("role", role);
    if (employeeRoles)
      localStorage.setItem("employeeRoles", JSON.stringify(employeeRoles));

    setAuthState((prev) => ({
      ...prev,
      user: user || prev.user,
      token: token || prev.token,
      refreshToken: refreshToken || prev.refreshToken,
      role: role || prev.role,
      employeeRoles: employeeRoles || prev.employeeRoles,
      isLoading: false,
      error: null,
    }));
  };

  const updateAuthState = (newState) => {
    setAuthState((prev) => {
      const updated = { ...prev, ...newState };

      if (updated.token) localStorage.setItem("token", updated.token);
      if (updated.refreshToken)
        localStorage.setItem("refreshToken", updated.refreshToken);
      if (updated.user)
        localStorage.setItem("user", JSON.stringify(updated.user));
      if (updated.role) localStorage.setItem("role", updated.role);
      if (updated.employeeRoles)
        localStorage.setItem(
          "employeeRoles",
          JSON.stringify(updated.employeeRoles)
        );

      return updated;
    });
  };

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("user");
    localStorage.removeItem("role");
    localStorage.removeItem("employeeRoles");

    setAuthState({
      user: null,
      token: null,
      refreshToken: null,
      role: null,
      employeeRoles: [],
      isLoading: false,
      error: null,
    });
  };

  return (
    <AuthContext.Provider
      value={{
        authState,
        login,
        updateAuthState,
        logout,
      }}
    >
      {children}
      {console.log(authState)}
    </AuthContext.Provider>
  );
};
