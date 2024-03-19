namespace Fermaloc.Application;

public class ReadCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public ReadAdministratorDto AdministratorDto { get; set; }
}
