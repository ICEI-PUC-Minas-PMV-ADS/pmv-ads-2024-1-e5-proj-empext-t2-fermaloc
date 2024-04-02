import React from 'react'
import "./styles.css";

export default function Product({image, name, id}) {
  return (
    <div>
    <img
      src={`data:image/png;base64,${image}`}
      alt="produto"
      className="imgProduc"
    />
    <p>{name}</p>
  </div>
  )
}
