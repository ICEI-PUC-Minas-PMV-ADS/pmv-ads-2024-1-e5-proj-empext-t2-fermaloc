using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fermaloc.Infra.Data;

public class EquipamentClicksRepositoryRepository : IEquipamentClicksRepository
{
    private readonly ApplicationDbContext _context;

    public EquipamentClicksRepositoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task CreateClickAsync(Guid equipamentId, DateOnly date)
    {
        EquipamentClicks equipamentClick = new EquipamentClicks(1, equipamentId, date);
        
        await _context.EquipamentClicks.AddAsync(equipamentClick);
        await _context.SaveChangesAsync();
   
    }

    public async Task AddClickAsync(DateOnly date, EquipamentClicks equipamentClick)
    {
        equipamentClick.AddClick();
        _context.EquipamentClicks.Update(equipamentClick);
        await _context.SaveChangesAsync();
    }
    
    public async Task<EquipamentClicks> GetEquipamentClickOnDate(DateOnly date, Guid equipamentId)
    {
            return await _context.EquipamentClicks.FirstOrDefaultAsync(e => e.EquipamentId == equipamentId && e.Date == date);
    }

    public async Task<IEnumerable<EquipamentClicks>> GetClicksBetweenDatesAsync(DateOnly startDate, DateOnly endDate)
    {
        var equipamentClicks = await _context.EquipamentClicks
            .Where(e => e.Date >= startDate && e.Date <= endDate)
            .ToListAsync();
        
        return equipamentClicks;
    }
}