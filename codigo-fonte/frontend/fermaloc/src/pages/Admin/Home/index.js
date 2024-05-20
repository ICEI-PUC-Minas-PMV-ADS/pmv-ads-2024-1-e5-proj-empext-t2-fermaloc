import React from "react";
import ReportForm from "./components/ReportForm/index.js";
import useAuthentication from "../../../hooks/useAuthentication";
import { Link } from "react-router-dom";
import styles from "./styles.module.css";


export default function HomeAdmin() {
  const { authenticated } = useAuthentication();


  return (
    <>
      {authenticated && (
        <div>
          <ReportForm/>
        </div>
      )}
    </>
  );
}
