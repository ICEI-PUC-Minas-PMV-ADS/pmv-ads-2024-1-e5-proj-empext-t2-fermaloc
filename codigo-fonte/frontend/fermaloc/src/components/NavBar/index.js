import React, { useEffect, useState } from "react";
import { Link, useLocation } from "react-router-dom";

// Estilização
import "./styles.css";

// Serviço
import { getBannerById } from "../../services/bannerService.js";

// Imagem
import logonavbar from "../../assets/imgs/logonavbar.png";

export default function NavBar() {
    const [banner, setBanner] = useState(null);

    useEffect(() => {
        async function fetchBanner(id) {
            const bannerData = await getBannerById(id);
            setBanner(bannerData.image);
        }

        //tera que remover esse id posteriormente, temos que ver uma melhor forma de deifnir qual banner ira ficar na home, talvez mais um endpont para que o admin escolha.
        // latest => banner/latest => {SQL SELECT * ORDER BY insertDate}[0]
        //FAVOR NÃO MUDAR A ID
        const id = "08dc4eb0-fa0f-40e7-82f1-7e82cca58ef9";
        fetchBanner(id);
    }, []);

    const location = useLocation();

    if (location.pathname.trim() === "/admin/login") {
        return undefined;
    }

    return (
        <header>
            <nav
                style={
                    location.pathname.trim() === "/" ||
                    location.pathname.trim() === "/produtos"
                        ? { marginBottom: "25vh" }
                        : { height: "25vh" }
                }
            >
                <Link to="/" className="navlogo">
                    <img src={logonavbar} alt="logo" />
                </Link>
                <div className="navSearch">
                    <div className="navSearchInput">
                        <div />
                        <input type="text" />
                    </div>
                    <button>
                        <div />
                        <svg
                            viewBox="0 0 32 32"
                            version="1.1"
                            xmlns="http://www.w3.org/2000/svg"
                        >
                            <g
                                stroke="none"
                                stroke-width="1"
                                fill="none"
                                fill-rule="evenodd"
                            >
                                <g transform="translate(-256.000000, -1139.000000)">
                                    <path d="M269.46,1163.45 C263.17,1163.45 258.071,1158.44 258.071,1152.25 C258.071,1146.06 263.17,1141.04 269.46,1141.04 C275.75,1141.04 280.85,1146.06 280.85,1152.25 C280.85,1158.44 275.75,1163.45 269.46,1163.45 L269.46,1163.45 Z M287.688,1169.25 L279.429,1161.12 C281.591,1158.77 282.92,1155.67 282.92,1152.25 C282.92,1144.93 276.894,1139 269.46,1139 C262.026,1139 256,1144.93 256,1152.25 C256,1159.56 262.026,1165.49 269.46,1165.49 C272.672,1165.49 275.618,1164.38 277.932,1162.53 L286.224,1170.69 C286.629,1171.09 287.284,1171.09 287.688,1170.69 C288.093,1170.3 288.093,1169.65 287.688,1169.25 L287.688,1169.25 Z"></path>
                                </g>
                            </g>
                        </svg>
                    </button>
                </div>
                {location.pathname.trim() === "/" ||
                location.pathname.trim() === "/produtos" ? (
                    <img
                        src={`data:image/png;base64,${banner}`}
                        alt="Banner"
                        className="imgBanner"
                    />
                ) : undefined}
                <ul>
                    <li className="navLink">
                        <Link to="/produtos">
                            <div />
                            <p>Produtos</p>
                        </Link>
                    </li>
                    <li className="navLink">
                        <Link to="/aboutus">
                            <div />
                            <p>Quem Somos</p>
                        </Link>
                    </li>
                </ul>
            </nav>
        </header>
    );
}
