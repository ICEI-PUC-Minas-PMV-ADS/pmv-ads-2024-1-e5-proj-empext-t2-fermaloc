import React, { useState } from "react";
import { FaEdit } from "react-icons/fa";
import EditProductForm from "../EditProductForm/index.js";
import styles from "./styles.module.css";

export default function Product({ product }) {
  const [viewEditForm, setViewEditForm] = useState(false);

  return !viewEditForm ? (
    <div className={styles.container}>
      <div className={styles.product}>
        <img
          src={`data:image/png;base64,${product.image}`}
          alt="produto"
          className={styles.imgProduct}
        />
        <p>{product.name}</p>
      </div>
      <FaEdit onClick={() => setViewEditForm(true)} />
    </div>
  ) : (
    <EditProductForm product={product} setViewEditForm={setViewEditForm} />
  );
}
