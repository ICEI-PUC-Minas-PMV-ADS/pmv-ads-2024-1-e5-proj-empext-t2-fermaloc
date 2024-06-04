import React from "react";
import style from "./styles.module.css";
import { Link } from "react-router-dom";
import { addClick } from "../../../../../services/productService";

export default function Product({ image, name, id }) {
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
      to={`${id}`}
      style={{
        textDecoration: "none",
        color: "black",
      }}
      onClick={() => hadleClick()}
    >
      <div className={style.productContainer}>
        <img
          src={`data:image/png;base64,${image}`}
          alt="produto"
          className={style.imgProduc}
        />
        <p>{name}</p>
      </div>
    </Link>
  );
}