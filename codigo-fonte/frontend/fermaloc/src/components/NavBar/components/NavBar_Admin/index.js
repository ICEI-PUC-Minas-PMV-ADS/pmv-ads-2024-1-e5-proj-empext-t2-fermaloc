import React from 'react';
import { Link } from 'react-router-dom';
import styles from "./styles.module.css"

export default function NavBar_Admin({location, logonavbar}) {
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
        <Link to="/" className={styles.navlogo}>
          <img src={logonavbar} alt="logo" />
        </Link>
        
        <ul>
          <li className={styles.navLink}>
            <Link to="/admin/home">
              <div />
              <p>Home</p>
            </Link>
          </li>
          <li className={styles.navLink}>
            <Link to="/admin/banners">
              <div />
              <p>Banner</p>
            </Link>
          </li>
          <li className={styles.navLink}>
            <Link to="/admin/categorias">
              <div />
              <p>Categorias</p>
            </Link>
          </li>
          <li className={styles.navLink}>
            <Link to="/admin/produtos">
              <div />
              <p>Produtos</p>
            </Link>
          </li>
        </ul>
      </nav>
    </header>
  )
}
