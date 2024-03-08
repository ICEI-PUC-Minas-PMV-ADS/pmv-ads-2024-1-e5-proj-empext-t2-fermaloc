namespace Fermaloc.Application;

public class CreateBannerDto
{
    public byte[] Image { get; set; }
    public Guid AdministratorId { get; set; }    
}
