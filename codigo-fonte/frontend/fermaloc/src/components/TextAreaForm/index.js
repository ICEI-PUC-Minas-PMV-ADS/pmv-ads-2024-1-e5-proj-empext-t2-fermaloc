import { React, useState } from "react";

export default function TextAreaForm({ value, onChange, maxLength }) {
  const handleChange = (e) => {
    const inputValue = e.target.value;
    if (inputValue.length <= maxLength) {
      onChange(inputValue);
    }
  };

  return (
    <textarea
      value={value}
      onChange={handleChange}
      maxLength={maxLength}
      rows={10}
    />
  );
}
