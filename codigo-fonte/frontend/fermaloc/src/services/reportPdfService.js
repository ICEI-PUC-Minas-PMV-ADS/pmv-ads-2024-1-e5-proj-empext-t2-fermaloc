import api from "../api/api";

async function getReportPdf(startDate = null, endDate = null) {
  try {
    const response = await api.get(`reportpdf?startDate=${startDate}&endDate=${endDate}`, {
      responseType: "blob", // Para lidar com a resposta binária
    });

    // Crie um URL para o blob recebido
    const url = window.URL.createObjectURL(
      new Blob([response.data], { type: "application/pdf" })
    );

    // Crie um link para simular o clique e iniciar o download
    const link = document.createElement("a");
    link.href = url;
    link.setAttribute("download", "relatorio.pdf"); // Nome do arquivo para download
    document.body.appendChild(link);
    link.click();

    // Remova o link após o download
    link.parentNode.removeChild(link);
  } catch (error) {
    console.error("Erro ao baixar o PDF:", error);
  }
}

export { getReportPdf };
