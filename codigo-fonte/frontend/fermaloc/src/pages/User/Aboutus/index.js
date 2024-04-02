import React from "react";
import { useLocation } from "react-router-dom";
import NavBar from "../../../components/NavBar";
import Footer from "../../../components/Footer";
import "./styles.css"
export default function AboutUs() {
  const location = useLocation();

  return (
    <>
      {location.pathname !== "/admin/login" && <NavBar />}
      <div className="pageContainer">
        <h1> Quem somos </h1>
        <div className="quemsomos">
          <div>
            <p>
              A Fermaloc é uma empresa que atua no ramo de ferramentas elétricas
            </p>
          </div>
        </div>
      </div>
      {location.pathname !== "/admin/login" && <Footer />}
    </>
  );
}