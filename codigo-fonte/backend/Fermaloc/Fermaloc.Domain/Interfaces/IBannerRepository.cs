namespace Fermaloc.Domain;

public interface IBannerRepository
{
    Task<Banner> CreateBannerAsync (Banner banner);
    Task<Banner> GetBannerByIdAsync (Guid id);
    Task<Banner> UpdateBannerAsync (Banner banner);
    Task<Banner>  DeleteBannerAsync (Banner banner);
}
