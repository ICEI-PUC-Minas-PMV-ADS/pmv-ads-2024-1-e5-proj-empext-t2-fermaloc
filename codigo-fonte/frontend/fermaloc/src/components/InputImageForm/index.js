import React from "react";
import styles from "./styles.module.css";

export default function InputImageForm({ handleImageChange }) {
  return (
    <div className={styles.page}>
      <input
        type="file"
        onChange={handleImageChange}
        accept=".jpg,.jpeg,.png"
      />
    </div>
  );
}
