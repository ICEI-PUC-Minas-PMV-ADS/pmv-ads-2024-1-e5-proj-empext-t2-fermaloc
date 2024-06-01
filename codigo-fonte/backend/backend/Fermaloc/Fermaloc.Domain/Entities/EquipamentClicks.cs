namespace Fermaloc.Domain;

public class EquipamentClicks
{
    public Guid Id { get; private set; }
    public int NumberOfClicks { get; private set; }
    public DateOnly Date { get; private set; }
    public Guid EquipamentId { get; private set; }
    public virtual Equipament Equipament { get; set; }

    public EquipamentClicks(int numberOfClicks, Guid equipamentId, DateOnly date)
    {
        NumberOfClicks = numberOfClicks;
        EquipamentId = equipamentId;
        Date = date;
    }

    public void AddClick()
    {
        NumberOfClicks += 1;
    }
    
}
