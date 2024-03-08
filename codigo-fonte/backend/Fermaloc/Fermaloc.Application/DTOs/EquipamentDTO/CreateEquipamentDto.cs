namespace Fermaloc.Application;

public class CreateEquipamentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberOfClicks { get; set; }
    public bool Active { get; set; }
    public Guid AdministratorId { get; set; }
    public Guid CategoryId { get; set; }
}
