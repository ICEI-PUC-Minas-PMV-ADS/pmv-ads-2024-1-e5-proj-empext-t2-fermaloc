import React from "react";
import style from "./styles.module.css";

export default function Product({ image, name, id }) {
  return (
    <div className={style.productContainer}>
      <img
        src={`data:image/png;base64,${image}`}
        alt="produto"
        className={style.imgProduc}
      />
      <p>{name}</p>
    </div>
  );
}
