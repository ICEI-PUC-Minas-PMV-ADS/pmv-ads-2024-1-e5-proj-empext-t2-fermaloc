import React from "react";
import styles from "./styles.module.css";

export default function InputForm({
  onChange,
  value,
  placeholder = null,
  maxLength = null,
  type = "text",
}) {
  return (
    <div className={styles.inputBox}>
    <div className={styles.page}>
    <input
      onChange={(e) => onChange(e.target.value)}
      value={value}
      placeholder={placeholder}
      maxLength={maxLength}
      type={type}
    /></div></div>
  );
}
