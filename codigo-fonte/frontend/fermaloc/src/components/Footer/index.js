import React from "react";
import { useLocation } from "react-router-dom";

// Estilização
import "./styles.css";

// Imagens
import cartaomascote from "../../assets/imgs/mascoteteste.png";
import instagram from "../../assets/imgs/instagram.png";

export default function Footer() {
    const location = useLocation();

    if (location.pathname.trim() === "/admin/login") {
        return undefined;
    }

    return (
        <footer>
            <div className="dados">
                <p> Telefone: (31) 3665-3051</p>

                <p>
                    Endereço: R. São Sebastião, 232 - Centro, Pedro Leopoldo -
                    MG
                </p>
            </div>

            <div className="mascote">
                <img src={cartaomascote} alt="Horário" />
            </div>

            <div className="mapa">
                <iframe
                    src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3758.170723883018!2d-44.04823172456286!3d-19.61999762873054!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xa6618551f89a9f%3A0x7c54a99cf097260b!2sFermaloc%20-%20Ferramentas%20El%C3%A9tricas%2C%20M%C3%A1quina%20e%20Loca%C3%A7%C3%A3o!5e0!3m2!1spt-BR!2sbr!4v1710905719512!5m2!1spt-BR!2sbr"
                    width="250"
                    height="118"
                    allowfullscreen=""
                    loading="lazy"
                    referrerpolicy="no-referrer-when-downgrade"
                    className="map"
                    title="map"
                ></iframe>
            </div>

            <div className="instagram">
                <a href="https://www.instagram.com/fermaloc.locacoes/">
                    <img src={instagram} alt="Instagram Fermaloc" />
                </a>
            </div>
        </footer>
    );
}
