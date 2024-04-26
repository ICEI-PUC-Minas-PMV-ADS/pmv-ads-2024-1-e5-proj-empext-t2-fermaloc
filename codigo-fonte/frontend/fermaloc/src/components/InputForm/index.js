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
    <input
      onChange={(e) => onChange(e.target.value)}
      value={value}
      placeholder={placeholder}
      maxLength={maxLength}
      type={type}
    />
  );
}
