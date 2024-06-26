using Fermaloc.Domain;
using FileSignatures;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Fermaloc.Application;

public class ReportService : IReportService
{
    private readonly IEquipamentClicksService _equipamentClicksService;

    public ReportService(IEquipamentClicksService equipamentClicksService)
    {
        _equipamentClicksService = equipamentClicksService;
    }

public async Task<byte[]> CreateReport(DateOnly startDate, DateOnly endDate)
{
    try
    {
        var equipamentsClicks = await _equipamentClicksService.GetClicksBetweenDatesAsync(startDate, endDate);
        IList<Equipament> equipaments = new List<Equipament>();

        foreach (var equipamentClick in equipamentsClicks)
        {
            if (!equipaments.Any(e => e.Id == equipamentClick.EquipamentId))
            {
                equipaments.Add(equipamentClick.Equipament);
            }
        }

        MemoryStream ms = new MemoryStream();
        PdfWriter writer = new PdfWriter(ms);
        PdfDocument pdf = new PdfDocument(writer);
        Document document = new Document(pdf);

        //string projectDirectory = Directory.GetCurrentDirectory();
        //string logoDirectory = Path.Combine(projectDirectory, "Public/images");
        //string logoPath = Path.Combine(logoDirectory, "logo.jpg");

        string logoUrl =
            "https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t2-fermaloc/main/Imgs/Logo.jpg";
        
        
        
        ImageData logoImageData = ImageDataFactory.Create(new Uri(logoUrl));
        Image logoImg = new Image(logoImageData);
        logoImg.SetMaxWidth(70);
        logoImg.SetMaxHeight(70);

        Table headerTable = new Table(2);
        headerTable.SetMarginBottom(20);
        headerTable.SetWidth(UnitValue.CreatePercentValue(100));

        Cell logoCell = new Cell().Add(logoImg);
        logoCell.SetBorder(Border.NO_BORDER);
        logoCell.SetTextAlignment(TextAlignment.RIGHT);
        logoCell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
        headerTable.AddCell(logoCell);

        Paragraph documentNameTitle = new Paragraph("Relatório de visitas")
            .SetFontSize(20)
            .SetBold();
        Cell titleCell = new Cell().Add(documentNameTitle);
        titleCell.SetBorder(Border.NO_BORDER);
        titleCell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
        headerTable.AddCell(titleCell);

        document.Add(headerTable);

        foreach (var equipament in equipaments)
        {
            TestFormat(equipament.Image);

            Table tableTitle = new Table(2);
            tableTitle.SetWidth(UnitValue.CreatePercentValue(100));

            ImageData imageData = ImageDataFactory.Create(equipament.Image);
            Image image = new Image(imageData);
            image.SetMaxWidth(40);
            image.SetMaxHeight(40);

            Cell imageCell = new Cell().Add(image);
            imageCell.SetBorder(Border.NO_BORDER);
            imageCell.SetTextAlignment(TextAlignment.CENTER);
            imageCell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            image.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            imageCell.SetWidth(60);
            tableTitle.AddCell(imageCell);

            Cell textCell = new Cell().Add(new Paragraph(equipament.Name));
            textCell.SetBorder(Border.NO_BORDER);
            textCell.SetTextAlignment(TextAlignment.LEFT);
            textCell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            tableTitle.AddCell(textCell);

            document.Add(tableTitle);

            LineSeparator ls = new LineSeparator(new SolidLine(1f));
            document.Add(ls);

            Table tableDates = new Table(2);
            tableDates.SetWidth(UnitValue.CreatePercentValue(100));

            var newEquipamentsClicks = equipamentsClicks
                .Where(equipamentClick => equipamentClick.EquipamentId == equipament.Id).OrderBy(equipamentClick => equipamentClick.Date).ToList();

            Cell titleDayCell = new Cell().Add(new Paragraph("Data"));
            titleDayCell.SetBorder(Border.NO_BORDER);
            titleDayCell.SetTextAlignment(TextAlignment.LEFT);
            titleDayCell.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell tileVisitCell = new Cell().Add(new Paragraph("Numero de visitas"));
            tileVisitCell.SetBorder(Border.NO_BORDER);
            tileVisitCell.SetTextAlignment(TextAlignment.CENTER);
            tileVisitCell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            tableDates.AddCell(titleDayCell);
            tableDates.AddCell(tileVisitCell);

            foreach (var equipamentClick in newEquipamentsClicks)
            {
                Cell dayCell = new Cell().Add(new Paragraph(equipamentClick.Date.ToString("dd/MM/yyyy")));
                dayCell.SetBorder(Border.NO_BORDER);
                dayCell.SetTextAlignment(TextAlignment.LEFT);
                dayCell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                tableDates.AddCell(dayCell);

                Cell numberOfClicksCell = new Cell().Add(new Paragraph(equipamentClick.NumberOfClicks.ToString()));
                numberOfClicksCell.SetBorder(Border.NO_BORDER);
                numberOfClicksCell.SetTextAlignment(TextAlignment.CENTER);
                numberOfClicksCell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                tableDates.AddCell(numberOfClicksCell);
            }

            tableDates.SetMarginBottom(30);
            document.Add(tableDates);
        }

        document.Close();
        writer.Close();
        //ms.Seek(0, SeekOrigin.Begin);
        return ms.ToArray();
    }
    catch (Exception ex)
    {
        // Log the error (consider using a logging framework such as Serilog, NLog, or log4net)
        Console.WriteLine($"Error generating PDF: {ex.Message}");
        throw;
    }
}


    private static void TestFormat(byte[] image)
    {
        var stream = new MemoryStream(image);
        var inspector = new FileFormatInspector();
        var format = inspector.DetermineFileFormat(stream);
    }
}