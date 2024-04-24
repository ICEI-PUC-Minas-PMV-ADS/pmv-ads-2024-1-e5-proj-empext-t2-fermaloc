import React from "react";
import useAuthentication from "../../../hooks/useAuthentication";
import { Link } from "react-router-dom";
import styles from "./styles.module.css";

export default function HomeAdmin() {
  const { authenticated } = useAuthentication();
  return <>{authenticated && 
  
  <div className={styles.classButton}>
    <div>
      <Link to="/admin/banners">Banners</Link>
    </div>
    <div>
      <Link to="/admin/categorias">Categorias</Link>
    </div>
    <div>
      <Link to="/admin/produtos">Products</Link>
    </div>

  </div>

  
  }</>;
}
