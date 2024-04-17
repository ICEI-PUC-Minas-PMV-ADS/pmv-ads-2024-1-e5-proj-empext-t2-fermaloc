import React from "react";
import { Link } from "react-router-dom";

// Estilização
import styles from "./styles.module.css";

export default function SimilarProduct({ image, id }) {
  return (
    <Link to={`/produtos/${id}`} className={styles.similarProduct}>
      <img
        src={`data:image/png;base64,${image}`}
        alt="Banner"
        className={styles.similarProductImage}
      />
      <div className={styles.similarProductbackground} />
      <div
        className={`${styles.similarProductbackground} ${styles["--delayed"]}`}
      />
    </Link>
  );
}
