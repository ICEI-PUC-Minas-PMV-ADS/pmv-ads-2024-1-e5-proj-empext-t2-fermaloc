import React from "react";
import styles from "./styles.module.css";
import useAuthentication from "../../../hooks/useAuthentication";

export default function BannersAdmin() {
  const { authenticated } = useAuthentication();
  return (
    authenticated && (
      <div>
        <h1>Banners</h1>
      </div>
    )
  );
}
