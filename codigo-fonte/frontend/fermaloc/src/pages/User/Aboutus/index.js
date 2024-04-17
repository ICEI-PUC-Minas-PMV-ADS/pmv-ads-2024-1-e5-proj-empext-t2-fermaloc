import React from "react";

// Estilização
import styles from "./styles.module.css";

export default function AboutUs() {
  return (
    <div className={styles.page}>
      <h1> Quem somos </h1>
      <div className={styles.quemsomos}>
        <div>
          <p>
            A Fermaloc é uma empresa que atua no ramo de ferramentas elétricas
          </p>
        </div>
      </div>
    </div>
  );
}
