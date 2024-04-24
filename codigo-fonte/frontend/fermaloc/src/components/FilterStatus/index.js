import React, { useState } from "react";

export default function FilterStatus({ handleFilter }) {
  const [ativo, setAtivo] = useState(true);

  const handleInput = () => {
    const novoValorAtivo = !ativo;
    setAtivo(novoValorAtivo);
    handleFilter(novoValorAtivo);
  };



  return (
    <div>
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
