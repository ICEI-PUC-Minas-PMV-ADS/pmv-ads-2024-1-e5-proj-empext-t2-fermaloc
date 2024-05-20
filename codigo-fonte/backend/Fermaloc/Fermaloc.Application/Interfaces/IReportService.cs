namespace Fermaloc.Application;

public interface IReportService
{
     Task<byte[]> CreateReport(DateOnly startDate, DateOnly endDate);
}