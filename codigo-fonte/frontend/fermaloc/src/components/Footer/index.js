import React from "react";
import { useLocation } from "react-router-dom";

// Estilização
import styles from "./styles.module.css";

// Imagens
import cartaomascote from "../../assets/imgs/mascoteteste.png";
import instagram from "../../assets/imgs/instagram.png";

export default function Footer() {
  const location = useLocation();

  if (location.pathname.trim() === "/login" || location.pathname.trim() === "/admin/home" || location.pathname.trim() === "/admin/categorias" || location.pathname.trim() === "/admin/produtos" || location.pathname.trim() === "/admin/banners") {
    return undefined;
  }

  return (
    <footer>
      <div className={styles.dados}>
        <p> Telefone: (31) 3665-3051</p>

        <p>Endereço: R. São Sebastião, 232 - Centro, Pedro Leopoldo - MG</p>
      </div>

      <div className={styles.mascote}>
        <img src={cartaomascote} alt="Horário" />
      </div>



      <div className={styles.instagram}>
        <a target="_blank" href="https://www.instagram.com/fermaloc.locacoes/">
          <img src={instagram} alt="Instagram Fermaloc" />
        </a>
      </div>
    </footer>
  );
}
