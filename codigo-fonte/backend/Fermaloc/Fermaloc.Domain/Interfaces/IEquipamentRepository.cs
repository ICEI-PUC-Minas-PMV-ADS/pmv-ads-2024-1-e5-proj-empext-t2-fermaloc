namespace Fermaloc.Domain;

public interface IEquipamentRepository
{
    Task<Equipament> CreateEquipamentAsync (Equipament equipament);
    Task<Equipament> GetEquipamentByIdAsync (Guid id);
    Task<IEnumerable<Equipament>> GetAllEquipamentsAsync();
    Task<Equipament> UpdateEquipamentAsync (Equipament equipament);
    Task<Equipament>  DeleteEquipamentAsync (Guid id);
}
