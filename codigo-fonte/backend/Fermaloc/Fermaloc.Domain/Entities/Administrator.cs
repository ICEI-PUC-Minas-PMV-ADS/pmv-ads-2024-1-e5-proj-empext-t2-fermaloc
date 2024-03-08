namespace Fermaloc.Domain;

public class Administrator
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string  Password { get; private set; }
    public string CNPJ { get; private set; }
    public string Role { get; set; }

    public virtual ICollection<Banner> Banners { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Equipament> Equipaments { get; set; }
}
