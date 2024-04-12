namespace Fermaloc.Domain;

public class EquipamentsClicks
{
    public Guid Id { get; private set; }
    public int NumberOfClicks { get; private set; }
    public DateOnly Date { get; private set; }
    public Guid EquipamentId { get; private set; }
    public virtual Equipament Equipament { get; set; }

    public void SetDate(){
        Date = DateOnly.FromDateTime(DateTime.Now);
    }
}
