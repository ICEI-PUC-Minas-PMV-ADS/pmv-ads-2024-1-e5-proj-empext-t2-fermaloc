namespace Fermaloc.Application;

public class CreateEquipamentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string EquipamentCode { get; set; }
    public bool Status { get; set; }
    public Guid AdministratorId { get; set; }
    public Guid CategoryId { get; set; }
}
