using Fermaloc.Domain;
namespace Fermaloc.Infra.Data;

public class BannerRepository : IBannerRepository
{
    private readonly ApplicationDbContext _context;

    public BannerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Banner> CreateBannerAsync(Banner banner)
    {
        _context.Add(banner);
        await _context.SaveChangesAsync();
        return banner;
    }
    public async Task<Banner> GetBannerByIdAsync(Guid id)
    {
        Banner banner = await _context.Banners.FindAsync(id);
        return banner;
    }

    public async Task<Banner> UpdateBannerAsync(Banner banner)
    {
        _context.Banners.Update(banner);
        await _context.SaveChangesAsync();
        return banner;
    }
    public async Task<Banner> DeleteBannerAsync(Banner banner)
    {
        _context.Banners.Remove(banner);
        await _context.SaveChangesAsync();
        return banner;
    }
}
