import React from "react";

// Estilização
import "./styles.css";

export default function Title(props) {
    return (
        <div className="titleContainer">
            <div className="titleContainerBackground" />
            <div className="titleText">
                <div className="titleTextBackground" />
                <span>{props.title}</span>
            </div>
        </div>
    );
}
