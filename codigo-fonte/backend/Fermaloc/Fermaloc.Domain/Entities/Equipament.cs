using System.Reflection.Metadata;

namespace Fermaloc.Domain;

public class Equipament
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int EquipamentCode { get; private set; }
    public int NumberOfClicks { get; set; }
    public bool Status { get; set; }
    public byte[] Image { get; set; }
    public Guid AdministratorId { get; private set; }
    public virtual Administrator Administrator { get; set; }
    public Guid CategoryId { get; private set; }
    public virtual Category Category { get; set; }
}
