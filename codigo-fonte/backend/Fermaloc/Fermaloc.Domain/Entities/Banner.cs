using System.Reflection.Metadata;

namespace Fermaloc.Domain;

public class Banner
{
    public Guid Id { get; private set; }
    public byte[] Image { get; private set; }
    public Guid AdministratorId { get; private set; }    
    public virtual Administrator Administrator { get; set; }    
}
