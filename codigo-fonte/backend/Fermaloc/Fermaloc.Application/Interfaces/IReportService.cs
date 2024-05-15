using iTextSharp.text;

namespace Fermaloc.Application;

public interface IReportService
{
     byte[] CreateReport();
}