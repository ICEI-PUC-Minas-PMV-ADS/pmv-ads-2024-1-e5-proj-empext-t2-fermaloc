namespace Fermaloc.Domain;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Guid AdministratorId { get; private set; }
    public virtual Administrator Administrator { get; set; }
    public virtual ICollection<Equipament> Equipaments { get; set; }
}
