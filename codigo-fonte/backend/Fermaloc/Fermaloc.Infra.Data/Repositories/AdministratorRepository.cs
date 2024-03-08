using Fermaloc.Domain;

namespace Fermaloc.Infra.Data;

public class AdministratorRepository : IAdministratorRepository
{
    private readonly ApplicationDbContext _context;

    public AdministratorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Administrator> CreateAdministratorAsync(Administrator administrator)
    {
        _context.Administrators.Add(administrator);
        await _context.SaveChangesAsync();
        return administrator;
    }

    public async Task<Administrator> GetAdministratorAsync(Guid id)
    {
        Administrator administrator = await _context.Administrators.FindAsync(id);
        return administrator;
    }

    public async Task<Administrator> UpdateAdministratorAsync(Administrator administrator)
    {
        _context.Administrators.Update(administrator);
        await _context.SaveChangesAsync();
        return administrator;
    }

    public async Task<Administrator> DeleteAdministratorAsync(Guid id)
    {
        Administrator administrator = await _context.Administrators.FindAsync(id);
        _context.Administrators.Remove(administrator);
        await _context.SaveChangesAsync();
        return administrator;
    }
}
