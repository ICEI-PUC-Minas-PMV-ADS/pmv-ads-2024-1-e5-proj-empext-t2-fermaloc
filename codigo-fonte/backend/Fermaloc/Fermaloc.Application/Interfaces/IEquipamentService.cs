using Fermaloc.Domain;

namespace Fermaloc.Application;

public interface IEquipamentService
{
    Task<ReadEquipamentDto> CreateEquipamentAsync (CreateEquipamentDto equipamentDto, byte[] image);
    Task<ReadEquipamentDto> GetEquipamentByIdAsync (Guid id);
    Task<IEnumerable<ReadEquipamentDto>> GetAllEquipamentsAsync();
    Task<IEnumerable<ReadEquipamentDto>> GetActiveEquipamentsOrderByNumberOfClicksAsync();
    Task<IEnumerable<ReadEquipamentDto>> GetEquipamentsByStatusAsync(bool status);
    Task<IEnumerable<ReadEquipamentDto>> GetActiveSimilarEquipamentsByCategoryAsync(Guid productId, Guid categoryId);
    Task<IEnumerable<ReadEquipamentDto>> GetEquipamentsByStatusAndCategoryAsync(bool status, Guid categoryId);
    Task<IEnumerable<ReadEquipamentDto>> GetEquipamentsSearchNameEquipamentAsync(string nameEquipament);
    Task<ReadEquipamentDto> UpdateEquipamentAsync (Guid id, UpdateEquipamentDto equipamentDto, byte[]? image);
    Task<ReadEquipamentDto> UpdateEquipamentStatusAsync (Guid id);
    Task<ReadEquipamentDto> AddClickCountEquipamentAsync (Guid id);
    Task<ReadEquipamentDto>  DeleteEquipamentAsync (Guid id);
}
