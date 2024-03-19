namespace Fermaloc.Domain;

public interface IEquipamentRepository
{
    Task<Equipament> CreateEquipamentAsync (Equipament equipament);
    Task<Equipament> GetEquipamentByIdAsync (Guid id);
    Task<IEnumerable<Equipament>> GetAllEquipamentsAsync();
    Task<IEnumerable<Equipament>> GetEquipamentsByStatusAsync(bool status);
    Task<IEnumerable<Equipament>> GetEquipamentsByStatusAndCategoryAsync(bool status, Guid categoryId);
    Task<IEnumerable<Equipament>> GetEquipamentsSearchNameEquipamentAsync(string nameEquipament);
    Task<Equipament> UpdateEquipamentAsync (Equipament equipament);
    Task<Equipament> UpdateEquipamentStatusAsync (Guid id);
    Task<Equipament> AddClickCountEquipamentAsync (Guid id);
    Task<Equipament>  DeleteEquipamentAsync (Guid id);
}
