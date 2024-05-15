using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Fermaloc.Application;



public class ReportService : IReportService
{
    private readonly IEquipamentClicksService _equipamentClicksService;
    private readonly IEquipamentService _equipamentService;

    public ReportService(IEquipamentClicksService equipamentClicksService, IEquipamentService equipamentService)
    {
        _equipamentClicksService = equipamentClicksService;
        _equipamentService = equipamentService;
    }

    public byte[] CreateReport()
    {

        using (var document = new Document(PageSize.A4, 50, 50, 25, 25))
        {
            var output = new MemoryStream();

            var writer = PdfWriter.GetInstance(document, output);
            writer.CloseStream = false;

            document.Open();
            document.Add(new Paragraph("Teste de relatorio"));
            document.Close();

            output.Seek(0, SeekOrigin.Begin);

            return output.ToArray();
        }
    }
    

    
}