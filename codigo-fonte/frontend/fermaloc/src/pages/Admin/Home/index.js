import React from "react";
import useAuthentication from "../../../hooks/useAuthentication";
import { Link } from "react-router-dom";
import styles from "./styles.module.css";

export default function HomeAdmin() {
  const { authenticated } = useAuthentication();
  return <>{authenticated && <div className={styles.classButton}></div>}</>;
}
