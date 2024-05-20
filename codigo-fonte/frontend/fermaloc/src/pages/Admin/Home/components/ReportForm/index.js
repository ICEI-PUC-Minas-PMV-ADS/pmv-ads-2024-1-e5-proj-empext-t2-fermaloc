import { React, useState } from "react";
import { getReportPdf } from "../../../../../services/reportPdfService.js";

export default function ReportForm() {
  const [startDate, setStartDate] = useState(
    new Date().toISOString().split("T")[0]
  );
  const [endDate, setEndDate] = useState(
    new Date().toISOString().split("T")[0]
  );

  const handleStartDateChange = (event) => {
    setStartDate(event.target.value);
  };

  const handleEndDateChange = (event) => {
    setEndDate(event.target.value);
  };

  const handleGetReportPdf = () => {
    getReportPdf(startDate, endDate);
  };

  return (
    <div>
      <h3>Relatório de visitas</h3>
      <input
        type="date"
        id="start"
        name="trip-start"
        value={startDate}
        onChange={handleStartDateChange}
      />
      <input
        type="date"
        id="end"
        name="trip-end"
        value={endDate}
        onChange={handleEndDateChange}
      />
      <button onClick={handleGetReportPdf}>Gerar relatório</button>
    </div>
  );
}
