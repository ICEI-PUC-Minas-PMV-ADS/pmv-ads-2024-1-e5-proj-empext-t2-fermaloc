import React from "react";
import "./styles.css";
import { Link, useNavigate } from "react-router-dom";

export default function SimilarProduct({ image, id }) {
  const nativate = useNavigate()
    return (
    <Link onClick={() => nativate(`/produtos/${id}`)}>
      <img
        src={`data:image/png;base64,${image}`}
        alt="Banner"
        className="similarProductImage"
      />
    </Link>
  );
}
