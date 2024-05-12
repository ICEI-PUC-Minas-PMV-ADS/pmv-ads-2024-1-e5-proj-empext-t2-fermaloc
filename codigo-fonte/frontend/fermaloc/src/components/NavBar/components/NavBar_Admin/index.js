import React from "react";
import { Link } from "react-router-dom";
import styles from "./styles.module.css";

export default function NavBar_Admin({ location, logonavbar }) {
  return (
    <>
      <div className={styles.navlogo}>
        <Link to="/">
          <img src={logonavbar} alt="logo" />
        </Link>
      </div>
      <ul>
        <li className={styles.navLink}>
          <Link
            to="/admin/home"
            style={{ textDecoration: "none", color: "white" }}
          >
            <div />
            <p>Home</p>
          </Link>
        </li>
        <li className={styles.navLink}>
          <Link
            to="/admin/banners"
            style={{ textDecoration: "none", color: "white" }}
          >
            <div />
            <p>Banner</p>
          </Link>
        </li>
        <li className={styles.navLink}>
          <Link
            to="/admin/categorias"
            style={{ textDecoration: "none", color: "white" }}
          >
            <div />
            <p>Categorias</p>
          </Link>
        </li>
        <li className={styles.navLink}>
          <Link
            to="/admin/produtos"
            style={{ textDecoration: "none", color: "white" }}
          >
            <div />
            <p>Produtos</p>
          </Link>
        </li>
      </ul>
    </>
  );
}
