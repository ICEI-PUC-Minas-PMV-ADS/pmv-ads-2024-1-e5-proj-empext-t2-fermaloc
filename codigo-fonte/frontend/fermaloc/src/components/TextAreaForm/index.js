import { React, useState } from "react";
import styles from "./styles.module.css";

export default function TextAreaForm({ value, onChange, maxLength }) {
  const handleChange = (e) => {
    const inputValue = e.target.value;
    if (inputValue.length <= maxLength) {
      onChange(inputValue);
    }
  };

  return (
    
    <div className={styles.page}>
    <textarea
    placeholder="Descrição"
      value={value}
      onChange={handleChange}
      maxLength={maxLength}
      rows={10}
    /></div>
  );
}
