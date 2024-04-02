import React from "react";
import "./styles.css";
import { Link } from "react-router-dom";

export default function TopProduct({ image, name, id }) {
  return (
    <Link
      to={`/produtos/${id}`}
      style={{ textDecoration: "none", color: "black" }}
    >
      <div className="topProductContainer">
        <img
          src={`data:image/png;base64,${image}`}
          alt={`${name}`}
          className="imageProduct"
        />
        <h2>{name}</h2>
      </div>
    </Link>
  );
}
