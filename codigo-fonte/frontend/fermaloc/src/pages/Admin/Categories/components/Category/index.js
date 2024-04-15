import React from "react";
import { FaEdit } from "react-icons/fa";
import styles from "./styles.module.css"

export default function Category({ category }) {
  return (
    <div className={styles.container}>
      <p>{category.name}</p>
      <FaEdit />
    </div>
  );
}
