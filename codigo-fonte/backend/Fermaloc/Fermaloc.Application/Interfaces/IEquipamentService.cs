using Fermaloc.Domain;

namespace Fermaloc.Application;

public interface IEquipamentService
{
    Task<ReadEquipamentDto> CreateEquipamentAsync (CreateEquipamentDto equipamentDto, byte[] image);
    Task<ReadEquipamentDto> GetEquipamentByIdAsync (Guid id);
    Task<IEnumerable<ReadEquipamentDto>> GetAllEquipamentsAsync();
    Task<ReadEquipamentDto> UpdateEquipamentAsync (Guid id, UpdateEquipamentDto equipamentDto, byte[]? image);
    Task<ReadEquipamentDto>  DeleteEquipamentAsync (Guid id);
}
