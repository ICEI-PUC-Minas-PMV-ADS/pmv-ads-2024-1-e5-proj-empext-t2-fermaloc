using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

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

    public async Task<Administrator> GetAdministratorByIdAsync(Guid id)
    {
        var administrator = await _context.Administrators.FindAsync(id);
        return administrator;
    }

        public async Task<Administrator> GetAdministratorByEmailAsync(string email)
    {
        var administrator = await _context.Administrators.FirstOrDefaultAsync(a => a.Email.ToLower() == email.ToLower());
        return administrator;
    }

    public async Task<Administrator> UpdateAdministratorAsync(Administrator administrator)
    {
        _context.Administrators.Update(administrator);
        await _context.SaveChangesAsync();
      return administrator;
    }

    public async Task<Administrator> DeleteAdministratorAsync(Administrator administrator)
    {
        _context.Administrators.Remove(administrator);
        await _context.SaveChangesAsync();
        return administrator;
    }


}
