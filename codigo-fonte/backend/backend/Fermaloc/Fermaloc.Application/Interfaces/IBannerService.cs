namespace Fermaloc.Application;

public interface IBannerService
{
    Task<ReadBannerDto> CreateBannerAsync (CreateBannerDto bannerDto, byte[] image);
    Task<ReadBannerDto> GetBannerAsync ();
    Task<ReadBannerDto> UpdateBannerAsync (byte[] image);
    Task<ReadBannerDto>  DeleteBannerAsync ();
}
