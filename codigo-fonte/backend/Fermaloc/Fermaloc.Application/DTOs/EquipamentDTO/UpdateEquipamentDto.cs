namespace Fermaloc.Application;

public class UpdateEquipamentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public string EquipamentCode { get; set; }
    public Guid CategoryId { get; set; }
}
