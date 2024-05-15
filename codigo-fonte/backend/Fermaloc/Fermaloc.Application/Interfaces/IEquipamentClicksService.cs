using Fermaloc.Application.DTOs.EquipamentClicksDTO;

namespace Fermaloc.Application;

public interface IEquipamentClicksService
{
    Task AddClickAsync(EquipamentClicksDto equipamentClicksDto);
    
    Task<IEnumerable<EquipamentClicksDto>> GetClicksBetweenDatesAsync(DateOnly startDate, DateOnly endDate);
}