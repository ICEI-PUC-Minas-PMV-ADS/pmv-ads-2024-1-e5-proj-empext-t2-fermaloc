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
        IEnumerable<Equipament> equipaments = await _context.Equipaments.ToListAsync();
        return equipaments;
    }
    public async Task<IEnumerable<Equipament>> GetActiveEquipamentsOrderByNumberOfClicksAsync()
    {
        IEnumerable<Equipament> equipaments = await _context.Equipaments.Where(e => e.Status == true).OrderByDescending(e => e.NumberOfClicks).ToListAsync();
        return equipaments;
    }
    public async Task<IEnumerable<Equipament>> GetEquipamentsByStatusAsync(bool status)
    {
        IEnumerable<Equipament> equipaments = await _context.Equipaments.Where(e => e.Status == status).ToListAsync();
        return equipaments;
    }
public async Task<IEnumerable<Equipament>> GetActiveSimilarEquipamentsByCategoryAsync(Guid productId, Guid categoryId)
{
    var random = new Random();
    IEnumerable<Equipament> equipaments = await _context.Equipaments
        .Where(e => e.Status == true && e.CategoryId == categoryId && e.Id != productId)
        .OrderBy(e => Guid.NewGuid())
        .Take(3)
        .ToListAsync();

    return equipaments;
}
    public async Task<IEnumerable<Equipament>> GetEquipamentsByStatusAndCategoryAsync(bool status, Guid categoryId)
    {
        IEnumerable<Equipament> equipaments = await _context.Equipaments.Where(e => e.Status == status && e.CategoryId == categoryId).ToListAsync();
        return equipaments;
    }
    public async Task<IEnumerable<Equipament>> GetEquipamentsSearchNameEquipamentAsync(string nameEquipament)
    {
        IEnumerable<Equipament> equipaments = await _context.Equipaments.Where(e => e.Name.Contains(nameEquipament)).ToListAsync();
        return equipaments;
    }
    public async Task<Equipament> UpdateEquipamentAsync(Equipament equipament)
    {
        _context.Equipaments.Update(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
    public async Task<Equipament> UpdateEquipamentStatusAsync(Equipament equipament)
    {
        _context.Equipaments.Update(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
    public async Task<Equipament> AddClickCountEquipamentAsync(Equipament equipament)
    {
        _context.Equipaments.Update(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
    public async Task<Equipament> DeleteEquipamentAsync(Equipament equipament)
    {
        _context.Equipaments.Remove(equipament);
        await _context.SaveChangesAsync();
        return equipament;
    }
}
