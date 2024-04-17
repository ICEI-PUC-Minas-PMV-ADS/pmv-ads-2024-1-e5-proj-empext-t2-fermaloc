import React from "react";

// Estilização
import styles from "./styles.module.css";

export default function Title(props) {
    return (
        <div className={styles.titleContainer}>
            <div className={styles.titleContainerBackground} />
            <div className={styles.titleText}>
                <div className={styles.titleTextBackground} />
                <span>{props.title}</span>
            </div>
        </div>
    );
}
