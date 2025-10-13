import { createContext, useState, useEffect } from "react";

export const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
  const [authState, setAuthState] = useState({
    user: null,
    token: null,
    refreshToken: null,
    role: null,
    permissions: [],
    isLoading: true,
    error: null,
  });

  useEffect(() => {
    const savedToken = localStorage.getItem("token");
    const savedRefreshToken = localStorage.getItem("refreshToken");
    const savedUser = localStorage.getItem("user");
    const savedRole = localStorage.getItem("role");

    if (savedToken) {
      setAuthState({
        user: savedUser ? JSON.parse(savedUser) : null,
        token: savedToken,
        refreshToken: savedRefreshToken,
        role: savedRole || null,
        permissions: [],
        isLoading: false,
        error: null,
      });
    } else {
      setAuthState((prev) => ({ ...prev, isLoading: false }));
    }
  }, []);

  const login = ({ token, refreshToken, user, role }) => {
    if (token) localStorage.setItem("token", token);
    if (refreshToken) localStorage.setItem("refreshToken", refreshToken);
    if (user) localStorage.setItem("user", JSON.stringify(user));
    if (role) localStorage.setItem("role", role);

    setAuthState((prev) => ({
      ...prev,
      user: user || prev.user,
      token: token || prev.token,
      refreshToken: refreshToken || prev.refreshToken,
      role: role || prev.role,
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

      return updated;
    });
  };

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("user");
    localStorage.removeItem("role");

    setAuthState({
      user: null,
      token: null,
      refreshToken: null,
      role: null,
      permissions: [],
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
      {console.log(authState)}
      {children}
    </AuthContext.Provider>
  );
};
