import React from "react";
import mascote from "../../../assets/imgs/mascote.png";
import { useLocation } from "react-router-dom";
import NavBar from "../../../components/NavBar";
import Footer from "../../../components/Footer";
import cartaomascote from "../../../assets/imgs/mascoteteste.png";
import "./styles.css"
export default function AboutUs() {
  const location = useLocation();

  return (
    <>
      {location.pathname !== "/admin/login" && <NavBar />}
      <div>
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