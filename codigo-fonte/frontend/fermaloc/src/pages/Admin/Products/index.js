import React from "react";
import styles from "./styles.module.css";
import useAuthentication from "../../../hooks/useAuthentication";

export default function ProductsAdmin() {
  const { authenticated } = useAuthentication();
  return (
    authenticated && (
      <div>
        <h1>Produtos</h1>
      </div>
    )
  );
}
