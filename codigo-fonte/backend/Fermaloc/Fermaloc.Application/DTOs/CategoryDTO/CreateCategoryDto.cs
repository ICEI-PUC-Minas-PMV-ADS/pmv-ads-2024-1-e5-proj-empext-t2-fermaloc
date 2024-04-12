namespace Fermaloc.Application;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public Guid AdministratorId { get; set; }
}
