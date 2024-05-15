import React from "react";
import useAuthentication from "../../../hooks/useAuthentication";
import { Link } from "react-router-dom";
import styles from "./styles.module.css";
import {getReportPdf} from "../../../services/reportPdfService.js"

export default function HomeAdmin() {
  const { authenticated } = useAuthentication();
  return (
    <>
      {authenticated && (
        <div>
          <button onClick={() => getReportPdf()}>PDF</button>
        </div>
      )}
    </>
  );
}
