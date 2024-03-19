namespace Fermaloc.Application;

public class ReadEquipamentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberOfClicks { get; set; }
    public int EquipamentCode { get; private set; }
    public bool Status { get; set; }
    public byte[] Image { get; set; }
    public ReadAdministratorDto AdministratorDto { get; set; }
    public ReadCategoryDto CategoryDto { get; set; }
}
