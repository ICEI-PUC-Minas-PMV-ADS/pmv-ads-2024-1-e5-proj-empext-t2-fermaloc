namespace Fermaloc.Domain;

public interface IEquipamentClicksRepository
{
    Task CreateClickAsync(Guid equipamentId, DateOnly date);
    Task AddClickAsync(DateOnly date, EquipamentClicks equipamentClick);

    Task<EquipamentClicks> GetEquipamentClickOnDate(DateOnly date, Guid equipamentId);

    Task<IEnumerable<EquipamentClicks>> GetClicksBetweenDatesAsync(DateOnly startDate, DateOnly endDate);
}