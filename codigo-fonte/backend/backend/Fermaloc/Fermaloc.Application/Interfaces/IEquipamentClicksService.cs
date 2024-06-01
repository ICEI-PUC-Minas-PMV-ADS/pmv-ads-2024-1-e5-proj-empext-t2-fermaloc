using Fermaloc.Application.DTOs.EquipamentClicksDTO;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public interface IEquipamentClicksService
{
    Task AddClickAsync(EquipamentClicksDto equipamentClicksDto);
    
    Task<IEnumerable<EquipamentClicks>> GetClicksBetweenDatesAsync(DateOnly startDate, DateOnly endDate);
}