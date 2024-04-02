import React from "react";
import "./styles.css";
import logonavbar from "../../assets/imgs/logonavbar.png";
import { Link } from "react-router-dom";

export default function NavBar() {
  return (
    <header>
      <nav>
        <div className="navlogo">
          <img src={logonavbar} alt="logo" />
        </div>
        <ul>
          <li>
            <Link to="/" style={{ textDecoration: "none", color: "white" }}>
              <p>Home</p>
            </Link>
          </li>
          <li>
            <Link
              to="/produtos"
              style={{ textDecoration: "none", color: "white" }}
            >
              <p>Produtos</p>
            </Link>
          </li>
          <li>
            <Link
              to="/aboutus"
              style={{ textDecoration: "none", color: "white" }}
            >
              <p>Quem Somos</p>
            </Link>
          </li>
        </ul>
      </nav>
    </header>
  );
}
