import React from "react";
import { Link } from "react-router-dom";

// Estilização
import "./styles.css";

export default function SimilarProduct({ image, id }) {
    return (
        <Link to={`/produtos/${id}`} className="similarProduct">
            <img
                src={`data:image/png;base64,${image}`}
                alt="Banner"
                className="similarProductImage"
            />
            <div className="similarProductbackground" />
            <div className="similarProductbackground --delayed" />
        </Link>
    );
}
