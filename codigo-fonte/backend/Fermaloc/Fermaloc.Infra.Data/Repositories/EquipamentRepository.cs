using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;
namespace Fermaloc.Infra.Data;

public class EquipamentRepository : IEquipamentRepository
{
    private readonly ApplicationDbContext _context;

    public EquipamentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Equipament> CreateEquipamentAsync(Equipament equipament)
    {
        _context.Equipaments.Add(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
    public async Task<Equipament> GetEquipamentByIdAsync(Guid id)
    {
        Equipament equipament = await _context.Equipaments.FindAsync(id);
        return equipament;
    }
    public async Task<IEnumerable<Equipament>> GetAllEquipamentsAsync()
    {
        IEnumerable<Equipament> categories = await _context.Equipaments.ToListAsync();
        return categories;
    }
    public async Task<Equipament> UpdateEquipamentAsync(Equipament equipament)
    {
        _context.Equipaments.Update(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
    public async Task<Equipament> DeleteEquipamentAsync(Guid id)
    {
        Equipament equipament = await _context.Equipaments.FindAsync(id);
        _context.Equipaments.Remove(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
}
