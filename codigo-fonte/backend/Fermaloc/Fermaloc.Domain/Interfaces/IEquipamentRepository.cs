namespace Fermaloc.Domain;

public interface IEquipamentRepository
{
    Task<Equipament> CreateEquipamentAsync (Equipament equipament);
    Task<Equipament> GetEquipamentByIdAsync (Guid id);
    Task<Equipament> GetEquipamentByEquipamentCodeAsync (int code);
    Task<IEnumerable<Equipament>> GetAllEquipamentsAsync();
    Task<IEnumerable<Equipament>> GetActiveEquipamentsOrderByNumberOfClicksAsync();
    Task<IEnumerable<Equipament>> GetEquipamentsByStatusAsync(bool status);
    Task<IEnumerable<Equipament>> GetActiveSimilarEquipamentsByCategoryAsync (Guid productId, Guid categoryId);
    Task<IEnumerable<Equipament>> GetEquipamentsByStatusAndCategoryAsync(bool status, Guid categoryId);
    Task<IEnumerable<Equipament>> GetEquipamentsSearchNameEquipamentAsync(string nameEquipament);
    Task<Equipament> UpdateEquipamentAsync (Equipament equipament);
    Task<Equipament> UpdateEquipamentStatusAsync (Equipament equipament);
    Task<Equipament>  DeleteEquipamentAsync (Equipament equipament);
}
