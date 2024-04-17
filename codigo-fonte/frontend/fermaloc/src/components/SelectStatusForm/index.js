import React from "react";

export default function SelectStatusForm({ value, onChange }) {
  return (
    <div>
      <label>
        <input
          type="radio"
          value={true}
          checked={value === true}
          onChange={() => onChange(true)}
        />
        Ativo
      </label>
      <label>
        <input
          type="radio"
          value={false}
          checked={value === false}
          onChange={() => onChange(false)}
        />
        Inativo
      </label>
    </div>
  );
};

