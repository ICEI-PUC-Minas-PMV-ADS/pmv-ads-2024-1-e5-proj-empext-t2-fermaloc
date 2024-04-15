using System.Runtime.CompilerServices;
using Fermaloc.Domain.Validations;

namespace Fermaloc.Domain;

public class Administrator
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string  Password { get; private set; }
    public string Cnpj { get; private set; }
    public string Role { get; private set; }
    public virtual ICollection<Banner> Banners { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Equipament> Equipaments { get; set; }

    public Administrator(string name, string email, string password, string cnpj, string role)
    {
        ValidateDomain(name, email, password, cnpj, role);
    }
    
    public Administrator(Guid id, string name, string email, string password, string cnpj, string role)
    {
        DomainExceptionValidation.ValidateGuid(id);
        Id = id;
        ValidateDomain(name, email, password, cnpj, role);
    }
    
    private void  ValidateDomain(string name, string email, string password, string cnpj, string role)
    {
        DomainExceptionValidation.ValidateRequiredValue(name == null, "Nome");
        DomainExceptionValidation.ValidateRequiredValue(email == null, "Email");
        DomainExceptionValidation.ValidateRequiredValue(password == null, "Senha");
        DomainExceptionValidation.ValidateRequiredValue(cnpj == null, "CNPJ");
        DomainExceptionValidation.ValidateRequiredValue(role == null, "Role");
        
        DomainExceptionValidation.ValidateString(name, 80, 3, "Nome");
        DomainExceptionValidation.ValidateString(email, 256, 7, "Email");
        DomainExceptionValidation.ValidateString(cnpj, 14, 14, "CNPJ");
        DomainExceptionValidation.ValidateString(role, 5, 5, "Role");
        DomainExceptionValidation.ValidatePassword(password);
        DomainExceptionValidation.ValidateEmail(email);
        
        Name = name;
        Email = email;
        Password = password;
        Cnpj = cnpj;
        Role = role;
    }

    public void SetPassword(string password){
        DomainExceptionValidation.ValidateRequiredValue(password == null, "Senha");
        DomainExceptionValidation.ValidatePassword(password);
        Password = password;
    }

    public void SetRole(string role){
        DomainExceptionValidation.ValidateRequiredValue(role == null, "Role");
        DomainExceptionValidation.ValidatePassword(role);
        Password = role;
    }
}
