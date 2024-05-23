import React from "react";
import styles from "./styles.module.css";

export default function FilterStatus({ handleFilter, status, setStatus }) {
  
  const handleInput = () => {
    const newValue = !status;
    setStatus(newValue);
    handleFilter(newValue);
  };

  return (
    <div className={styles.options}>
      <div className={styles.option}>
        <input
          type="radio"
          id="ativo"
          name="opcoes"
          checked={status}
          onChange={handleInput}
        />
        <label htmlFor="ativo">Ativo</label>
      </div>

      <div className={styles.option}>
        <input
          type="radio"
          id="inativo"
          name="opcoes"
          checked={!status}
          onChange={handleInput}
        />
        <label htmlFor="inativo">Inativo</label>
      </div>
    </div>
  );
}
