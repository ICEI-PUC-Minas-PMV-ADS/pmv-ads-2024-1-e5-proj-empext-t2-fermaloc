namespace Fermaloc.Application;

public class ReadBannerDto
{
    public Guid Id { get; set; }
    public byte[] Image { get; set; }
    public ReadAdministratorDto AdministratorDto { get; set; }
}
