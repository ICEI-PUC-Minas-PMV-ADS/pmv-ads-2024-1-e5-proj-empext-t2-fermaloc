import React from "react";
import "./styles.css";
import { useLocation } from "react-router-dom";
import NavBar from "../../../components/NavBar/index.js";
import Footer from "../../../components/Footer/index.js";

export default function Products() {
  const location = useLocation();

  return (
    <>
      {location.pathname !== "/admin/login" && <NavBar />}
      <div>Products</div>
      {location.pathname !== "/admin/login" && <Footer />}
    </>
  );
}
