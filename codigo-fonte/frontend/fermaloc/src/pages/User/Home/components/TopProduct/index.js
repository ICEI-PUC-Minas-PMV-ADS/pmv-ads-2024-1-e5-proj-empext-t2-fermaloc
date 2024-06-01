import React from "react";
import styles from "./styles.module.css";
import { Link } from "react-router-dom";
import { addClick } from "../../../../../services/productService";

export default function TopProduct({ image, name, id }) {
  const hadleClick = async () => {
    const date = getCurrentDateFormatted();
    await addClick(date, id);
  };

  function getCurrentDateFormatted() {
    const date = new Date();
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, "0");
    const day = String(date.getDate()).padStart(2, "0");
    return `${year}-${month}-${day}`;
  }

  return (
    <Link
      to={`/produtos/${id}`}
      // style={{ textDecoration: "none", color: "black", textAlign: "center" }}

      // CSS em substituição do acima.
      className={styles.TextProduct}
      onClick={() => hadleClick()}
    >
      <div className={styles.topProductContainer}>
        <img
          src={`data:image/png;base64,${image}`}
          alt={`${name}`}
          className={styles.imageProduct}
        />
        <h2>{name}</h2>
        {/* <div className={styles.topProductFooter}>
                    <div />
                    <span>Sobre</span>
                </div> */}
      </div>
    </Link>
  );
}
