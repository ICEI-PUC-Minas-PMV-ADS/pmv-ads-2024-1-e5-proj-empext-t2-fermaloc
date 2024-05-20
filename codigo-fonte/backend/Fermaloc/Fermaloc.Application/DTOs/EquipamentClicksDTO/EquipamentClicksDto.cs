namespace Fermaloc.Application.DTOs.EquipamentClicksDTO;

public class EquipamentClicksDto
{
    public int? NumberOfClicks { get;  set; }
    public DateOnly Date { get; set; }
    public Guid EquipamentId { get; set; }
}