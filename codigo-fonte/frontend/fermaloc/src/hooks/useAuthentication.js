import { useState, useEffect, useCallback } from "react";
import { jwtDecode } from "jwt-decode";
import { useNavigate, useLocation } from "react-router-dom";
import { loginService } from "../services/authenticationService";

const useAuthentication = () => {
  const [authenticated, setAuthenticated] = useState(false);
  const [userId, setUserId] = useState("");

  const navigate = useNavigate();
  const location = useLocation();

  const getAdminId = () => {
    const token = localStorage.getItem("token");
    if (token) {
      const decoded = jwtDecode(token);
      setUserId(decoded.nameid)
      return userId
    }
    return userId;
  };

  const isTokenValid = useCallback(() => {
    const token = localStorage.getItem("token");

    const invalidToken = () => {
      setAuthenticated(false);
      localStorage.removeItem("token");

      if (location.pathname.startsWith("/admin")) {
        alert("sessão expirada!");
        navigate("/login");
      }
    };

    if (token) {
      try {
        const decoded = jwtDecode(token);
        const currentTime = Date.now() / 1000;
        if (decoded.exp > currentTime) {
          setAuthenticated(true);
        } else {
          invalidToken();
        }
      } catch (error) {
        invalidToken();
      }
    } else {
      invalidToken();
    }
  }, [navigate, location.pathname]);

  useEffect(() => {
    isTokenValid();
  }, [isTokenValid]);

  const login = async (userLogin) => {
    try {
      const response = await loginService(userLogin);
      const token = response.data.token;
      localStorage.setItem("token", token);
      navigate(`/admin/home`);
    } catch (erros) {
      console.error(erros);
    }
  };

  const logout = async () => {
    localStorage.removeItem("token");
    navigate("/");
    setAuthenticated(false);
  };
  return { authenticated, login, logout, isTokenValid, getAdminId };
};

export default useAuthentication;
