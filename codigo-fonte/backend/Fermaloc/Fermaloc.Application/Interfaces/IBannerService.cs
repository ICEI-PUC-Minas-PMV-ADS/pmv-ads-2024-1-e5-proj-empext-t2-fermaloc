namespace Fermaloc.Application;

public interface IBannerService
{
    Task<ReadBannerDto> CreateBannerAsync (CreateBannerDto bannerDto, byte[] image);
    Task<ReadBannerDto> GetBannerByIdAsync (Guid id);
    Task<ReadBannerDto> UpdateBannerAsync (Guid id, byte[] image);
    Task<ReadBannerDto>  DeleteBannerAsync (Guid id);
}
