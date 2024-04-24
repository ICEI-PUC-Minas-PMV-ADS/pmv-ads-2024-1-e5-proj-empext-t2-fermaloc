namespace Fermaloc.Application;

public class UpdateEquipamentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public int EquipamentCode { get; private set; }
    public Guid CategoryId { get; set; }
}
