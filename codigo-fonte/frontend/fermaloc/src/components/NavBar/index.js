import React from "react";
import { useLocation } from "react-router-dom";
import styles from "./styles.module.css";

// Imagem
import logonavbar from "../../assets/imgs/logonavbar.png";
import NavBar_User from "./components/NavBar_User/index.js";
import NavBar_Admin from "./components/NavBar_Admin/index.js";

export default function NavBar() {
    const location = useLocation();

    if (location.pathname.trim().includes("/login")) {
        return undefined;
    } else if (
        location.pathname.trim() === "/admin/home" ||
        location.pathname.trim() === "/admin/categorias" ||
        location.pathname.trim() === "/admin/produtos" ||
        location.pathname.trim() === "/admin/banners"
    ) {
        return (
            <header>
                <nav>
                    <NavBar_Admin location={location} logonavbar={logonavbar} />{" "}
                </nav>
            </header>
        );
    }

    return (
        <header>
            <nav>
                <NavBar_User location={location} logonavbar={logonavbar} />
            </nav>
        </header>
    );
}
