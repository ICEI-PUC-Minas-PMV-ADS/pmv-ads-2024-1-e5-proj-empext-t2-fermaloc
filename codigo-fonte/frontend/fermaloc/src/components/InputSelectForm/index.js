import React from "react";
import styles from "./styles.module.css";

export default function InputSelectForm({ options, selectedOption, onChange }) {
  return (
    <div className={styles.page}>
    <select value={selectedOption ? selectedOption : ""} onChange={(e) => onChange(e.target.value)}>
      <option value="">Selecione uma opção</option>
      {options.length > 0 ? (
        options.map((option) => (
          <option key={option.id} value={option.id}>
            {option.name}
          </option>
        ))
      ) : (
        <option disabled>Nenhuma categoria cadastrada ou ativa</option>
      )}
    </select></div>
  );
}
