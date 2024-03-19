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
        equipament.Status = true;
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
        var equipaments = await _equipamentRepository.GetAllEquipamentsAsync();
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
        return readCategoriesDto;
    }
    public async Task<IEnumerable<ReadEquipamentDto>> GetEquipamentsByStatusAsync(bool status)
    {
        var equipaments = await _equipamentRepository.GetEquipamentsByStatusAsync(status);
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
        return readCategoriesDto;
    }
    public async Task<IEnumerable<ReadEquipamentDto>> GetEquipamentsByStatusAndCategoryAsync(bool status, Guid categoryId)
    {
        var equipaments = await _equipamentRepository.GetEquipamentsByStatusAndCategoryAsync(status, categoryId);
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
        return readCategoriesDto;
    }
    public async Task<IEnumerable<ReadEquipamentDto>> GetEquipamentsSearchNameEquipamentAsync(string nameEquipament)
    {
        var equipaments = await _equipamentRepository.GetEquipamentsSearchNameEquipamentAsync(nameEquipament);
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
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
    public async Task<ReadEquipamentDto> UpdateEquipamentStatusAsync(Guid id)
    {
        var equipamentUpdated = await _equipamentRepository.UpdateEquipamentStatusAsync(id);
        return _mapper.Map<ReadEquipamentDto>(equipamentUpdated);
    }
    public async Task<ReadEquipamentDto> AddClickCountEquipamentAsync(Guid id)
    {
        var equipamentUpdated = await _equipamentRepository.AddClickCountEquipamentAsync(id);
        return _mapper.Map<ReadEquipamentDto>(equipamentUpdated);
    }
    public async Task<ReadEquipamentDto> DeleteEquipamentAsync(Guid id)
    {
        var equipament = await _equipamentRepository.DeleteEquipamentAsync(id);
        return _mapper.Map<ReadEquipamentDto>(equipament);
    }

}
