using AutoMapper;
using Fermaloc.Domain;
using Fermaloc.Domain.Validations;

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
        try{
            var equipament = _mapper.Map<Equipament>(equipamentDto);
            equipament.SetImage(image);
            var equipamentExits = await _equipamentRepository.GetEquipamentByEquipamentCodeAsync(Int32.Parse(equipamentDto.EquipamentCode));
            if (equipamentExits == null){
                var equipamentCreated = await _equipamentRepository.CreateEquipamentAsync(equipament);
                return _mapper.Map<ReadEquipamentDto>(equipamentCreated);
            }
            throw new InvalidDataException("Já existe um equipamente com mesmo código criado");
        }catch(DomainExceptionValidation ex){
            throw new InvalidDataException(ex.Message);
        }
    }
    public async Task<ReadEquipamentDto> GetEquipamentByIdAsync(Guid id)
    {
        var equipament = await _equipamentRepository.GetEquipamentByIdAsync(id);
        if(equipament == null){
            throw new NotFoundException("Equipamento não encontrado");
        }          
        var equipamentDto = _mapper.Map<ReadEquipamentDto>(equipament);
        return equipamentDto;
    }
    public async Task<IEnumerable<ReadEquipamentDto>> GetAllEquipamentsAsync()
    {
        var equipaments = await _equipamentRepository.GetAllEquipamentsAsync();
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
        return readCategoriesDto;
    }
    public async Task<IEnumerable<ReadEquipamentDto>> GetActiveEquipamentsOrderByNumberOfClicksAsync()
    {
        var equipaments = await _equipamentRepository.GetActiveEquipamentsOrderByNumberOfClicksAsync();
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
        return readCategoriesDto;
    }
    
    public async Task<IEnumerable<ReadEquipamentDto>> GetEquipamentsByStatusAsync(bool status)
    {
        var equipaments = await _equipamentRepository.GetEquipamentsByStatusAsync(status);
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
        return readCategoriesDto;
    }
    public async Task<IEnumerable<ReadEquipamentDto>> GetActiveSimilarEquipamentsByCategoryAsync(Guid productId, Guid categoryId)
    {
        var equipaments = await _equipamentRepository.GetActiveSimilarEquipamentsByCategoryAsync(productId, categoryId);
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
        return readCategoriesDto;
    }
    public async Task<IEnumerable<ReadEquipamentDto>> GetEquipamentsByStatusAndCategoryAsync(bool status, Guid categoryId)
    {
        var equipaments = await _equipamentRepository.GetEquipamentsByStatusAndCategoryAsync(status, categoryId);
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
        return readCategoriesDto;
    }
    public async Task<IEnumerable<ReadEquipamentDto>> GetEquipamentsSearchNameEquipamentAsync(string? nameEquipament)
    {
        var equipaments = await _equipamentRepository.GetEquipamentsSearchNameEquipamentAsync(nameEquipament);
        IEnumerable<ReadEquipamentDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadEquipamentDto>>(equipaments);
        return readCategoriesDto;
    }
    public async Task<ReadEquipamentDto> UpdateEquipamentAsync(Guid id, UpdateEquipamentDto equipamentDto, byte[]? image)
    {
        try{
            var equipament = await _equipamentRepository.GetEquipamentByIdAsync(id);
            if(equipament == null){
                throw new NotFoundException("Equipamento não encontrado");
            }          
            _mapper.Map(equipamentDto, equipament);
            if(image is not null){
                equipament.SetImage(image);
            }
            var equipamentUpdated = await _equipamentRepository.UpdateEquipamentAsync(equipament);
            return _mapper.Map<ReadEquipamentDto>(equipamentUpdated);
        }catch(DomainExceptionValidation ex){
            throw new InvalidDataException(ex.Message);
        }

    }
    public async Task<ReadEquipamentDto> UpdateEquipamentStatusAsync(Guid id)
    {
        var equipament = await _equipamentRepository.GetEquipamentByIdAsync(id);
        if(equipament == null){
            throw new NotFoundException("Equipamento não encontrado");
        }          
        equipament.SetStatus(!equipament.Status);
        var equipamentUpdated = await _equipamentRepository.UpdateEquipamentStatusAsync(equipament);
        return _mapper.Map<ReadEquipamentDto>(equipamentUpdated);
    }

    public async Task<ReadEquipamentDto> DeleteEquipamentAsync(Guid id)
    {
        var equipament = await _equipamentRepository.GetEquipamentByIdAsync(id);
        if(equipament == null){
            throw new NotFoundException("Equipamento não encontrado");
        }           
        var equipamentDeleted = await _equipamentRepository.DeleteEquipamentAsync(equipament);
        return _mapper.Map<ReadEquipamentDto>(equipamentDeleted);
    }
}
