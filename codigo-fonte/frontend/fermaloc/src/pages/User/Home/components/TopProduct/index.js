import React from "react";
import styles from "./styles.module.css";
import { Link } from "react-router-dom";

export default function TopProduct({ image, name, id }) {
    return (
        <Link
            to={`/produtos/${id}`}
            style={{ textDecoration: "none", color: "black" }}
        >
            <div className={styles.topProductContainer}>
                <img
                    src={`data:image/png;base64,${image}`}
                    alt={`${name}`}
                    className={styles.imageProduct}
                />
                <h2>{name}</h2>
                <div className={styles.topProductFooter}>
                    <div />
                    <span>Sobre</span>
                </div>
            </div>
        </Link>
    );
}
