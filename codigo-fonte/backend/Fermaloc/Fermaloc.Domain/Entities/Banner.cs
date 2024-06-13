using Fermaloc.Domain.Validations;

namespace Fermaloc.Domain;

public class Banner
{
    public Guid Id { get; private set; }
    public byte[] Image { get; private set; }
    public Guid AdministratorId { get; private set; }
    public virtual Administrator Administrator { get; set; }

    public Banner(byte[] image, Guid administratorId)
    {
        ValidateDomain(image, administratorId);
    }
    
    public Banner(){}
    
    public Banner(Guid id, byte[] image, Guid administratorId, Guid categoryId)
    {
        DomainExceptionValidation.ValidateGuid(id);
        Id = id;
        ValidateDomain(image, administratorId);
    }
    
    private void  ValidateDomain(byte[] image, Guid administratorId)
    {
        DomainExceptionValidation.ValidateGuid(administratorId);
        DomainExceptionValidation.ValidateByte(5 * 1024 * 1024, "Imagem do equipamento", image);
        DomainExceptionValidation.ValidateRequiredValue(image == null, "Imagem");
        
        Image = image;
        AdministratorId = administratorId;
    }

    public void SetImage(byte[] image){
        DomainExceptionValidation.ValidateByte(5 * 1024 * 1024, "Imagem do equipamento", image);
        Image = image;
    }
}
