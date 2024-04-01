namespace Fermaloc.Domain;

public class Administrator
{
    public Administrator()
    {
        Role = "admin";
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; set; }
    public string  Password { get; set; }
    public string CNPJ { get; private set; }
    public string Role { get; private set; }

    public virtual ICollection<Banner> Banners { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Equipament> Equipaments { get; set; }
}
