import React, { useState } from "react";
import styles from "./styles.module.css";

export default function FilterStatus({ handleFilter }) {
  const [ativo, setAtivo] = useState(true);

  const handleInput = () => {
    const novoValorAtivo = !ativo;
    setAtivo(novoValorAtivo);
    handleFilter(novoValorAtivo);
  };



  return (
    <div className={styles.page}>
      <input
        type="radio"
        id="ativo"
        name="opcoes"
        checked={ativo}
        onChange={handleInput}
      />
      <label htmlFor="ativo">Ativo</label>

      <input
        type="radio"
        id="inativo"
        name="opcoes"
        checked={!ativo}
        onChange={handleInput}
      />
      <label htmlFor="inativo">Inativo</label>
    </div>
  );
}
