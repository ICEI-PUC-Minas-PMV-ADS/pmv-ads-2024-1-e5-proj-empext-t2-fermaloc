using AutoMapper;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class EquipamentService : IEquipamentService
{
    private readonly IEquipamentRepository _equipamentRepository;
    private readonly IMapper _mapper;

    public EquipamentService(IEquipamentRepository equipamentRepository, IMapper mapper)
    {
        _equipamentRepository = equipamentRepository;
        _mapper = mapper;
    }

    public async Task<ReadEquipamentDto> CreateEquipamentAsync(CreateEquipamentDto equipamentDto, byte[] image)
    {
        var equipament = _mapper.Map<Equipament>(equipamentDto);
        equipament.Image = image;
        var equipamentCreated = await _equipamentRepository.CreateEquipamentAsync(equipament);
        return _mapper.Map<ReadEquipamentDto>(equipamentCreated);
    }
    public async Task<ReadEquipamentDto> GetEquipamentByIdAsync(Guid id)
    {
        var equipament = await _equipamentRepository.GetEquipamentByIdAsync(id);
        var equipamentDto = _mapper.Map<ReadEquipamentDto>(equipament);
        return equipamentDto;
    }
    public async Task<IEnumerable<ReadEquipamentDto>> GetAllEquipamentsAsync()
    {
        var categories = await _equipamentRepository.GetAllEquipamentsAsync();
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(categories);
        return readCategoriesDto;
    }
    public async Task<ReadEquipamentDto> UpdateEquipamentAsync(Guid id, UpdateEquipamentDto equipamentDto, byte[]? image)
    {
        var equipament = await _equipamentRepository.GetEquipamentByIdAsync(id);
        _mapper.Map(equipamentDto, equipament);
        if(image is not null){
            equipament.Image = image;
        }
        var equipamentUpdated = await _equipamentRepository.UpdateEquipamentAsync(equipament);
        return _mapper.Map<ReadEquipamentDto>(equipamentUpdated);
    }
    public async Task<ReadEquipamentDto> DeleteEquipamentAsync(Guid id)
    {
        var equipament = await _equipamentRepository.DeleteEquipamentAsync(id);
        return _mapper.Map<ReadEquipamentDto>(equipament);
    }
}
