using System.Reflection.Metadata;
using Fermaloc.Domain.Validations;

namespace Fermaloc.Domain;

public class Equipament
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int EquipamentCode { get; private set; }
    public bool Status { get; private set; }
    public int NumberOfClicks { get; private set; }
    public byte[] Image { get; private set; }
    public Guid AdministratorId { get; private set; }
    public virtual Administrator Administrator { get; set; }
    public Guid CategoryId { get; private set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<EquipamentClicks> EquipamentsClicks { get; set; }

    public Equipament(string name, string description, int equipamentCode, bool status, Guid administratorId, Guid categoryId)
    {
        ValidateDomain(name, description, equipamentCode, status, administratorId, categoryId);
    }

    public Equipament(string name, string description, int equipamentCode, bool status, byte[] image, Guid administratorId, Guid categoryId)
    {
        DomainExceptionValidation.ValidateRequiredValue(description == null, "Descrição");
        DomainExceptionValidation.ValidateByte(5 * 1024 * 1024, "Imagem do equipamento", image);
        ValidateDomain(name, description, equipamentCode, status, administratorId, categoryId);
        Image = image;
    }
    
    public Equipament(Guid id, string name, string description, int equipamentCode, bool status, byte[] image, Guid administratorId, Guid categoryId)
    {
        DomainExceptionValidation.ValidateGuid(id);
        DomainExceptionValidation.ValidateRequiredValue(description == null, "Descrição");
        DomainExceptionValidation.ValidateByte(5 * 1024 * 1024, "Imagem do equipamento", image);
        Id = id;
        Image = image;
        ValidateDomain(name, description, equipamentCode, status, administratorId, categoryId);
    }
    
    private void ValidateDomain(string name, string description, int equipamentCode, bool status, Guid administratorId, Guid categoryId)
    {
        DomainExceptionValidation.ValidateGuid(administratorId);
        DomainExceptionValidation.ValidateGuid(categoryId);
        DomainExceptionValidation.ValidateString(name, 150, 3, "Nome");
        DomainExceptionValidation.ValidateString(description, 1024, 3, "Descrição");
        DomainExceptionValidation.ValidateInt(equipamentCode, "Codigo do equipamento");

        Name = name;
        Description = description;
        AdministratorId = administratorId;
        EquipamentCode = equipamentCode;
        Status = status;
        CategoryId = categoryId;
    }


    public void SetStatus(bool status){
        Status = status;
    }

    public void SetImage(byte[] image){
        DomainExceptionValidation.ValidateByte(5 * 1024 * 1024, "Imagem do equipamento", image);
        Image = image;
    }

    public void AddClick()
    {
        NumberOfClicks += 1;
    }
}
