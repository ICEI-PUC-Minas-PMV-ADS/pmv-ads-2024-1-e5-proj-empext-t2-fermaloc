using Fermaloc.Domain.Validations;

namespace Fermaloc.Domain;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Guid AdministratorId { get; private set; }
    public bool Status { get; private set; }
    public virtual Administrator Administrator { get; set; }
    public virtual ICollection<Equipament> Equipaments { get; set; }

    public Category(string name, string description, Guid administratorId, bool status)
    {
        ValidateDomain(name, description, administratorId, status);
    }
    
    public Category(Guid id, string name, string description, Guid administratorId, bool status)
    {
        DomainExceptionValidation.ValidateGuid(id);
        Id = id;
        ValidateDomain(name, description, administratorId, status);
    }
    
    private void ValidateDomain(string name, string description, Guid administratorId, bool status){
        DomainExceptionValidation.ValidateGuid(administratorId);
        DomainExceptionValidation.ValidateString(name, 50, 3, "Nome");
        DomainExceptionValidation.ValidateString(description, 300, 3, "Descrição");
        DomainExceptionValidation.ValidateRequiredValue(name == null, "Nome");
        DomainExceptionValidation.ValidateRequiredValue(description == null, "Descrição");
        
        Name = name;
        Description = description;
        AdministratorId = administratorId;
        Status = status;
    }


    public void SetStatus(bool status){
        Status = status;
    }
}
