using AutoMapper;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Common;
using TaxiApp.Core.Domain.Repository.Common;

namespace TaxiApp.Core.Application.Services.Common;

public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity>
    where TDto : class
    where TEntity : class
{
    private readonly IGenericRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<OperationResult<ICollection<TDto>>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        if (!result.IsSuccess)
            return OperationResult<ICollection<TDto>>.Failure(result.Message, null, null);

        var mapped = result.Data.Select(_mapper.Map<TDto>).ToList();
        return OperationResult<ICollection<TDto>>.Success(mapped, "Success");
    }

    public virtual async Task<OperationResult<ICollection<TDto>>> GetAllIncludeAsync(ICollection<string> properties)
    {
        var result = await _repository.GetAllIncludeAsync(properties);
        if (!result.IsSuccess)
            return OperationResult<ICollection<TDto>>.Failure(result.Message, null, null);

        var mapped = result.Data.Select(_mapper.Map<TDto>).ToList();
        return OperationResult<ICollection<TDto>>.Success(mapped, "Success");
    }

    public virtual async Task<OperationResult<TDto>> GetByIdAsync(int id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (!result.IsSuccess)
            return OperationResult<TDto>.Failure(result.Message, null, null);

        var mapped = _mapper.Map<TDto>(result.Data);
        return OperationResult<TDto>.Success(mapped, "Success");
    }

    public virtual async Task<OperationResult<TDto>> AddAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        var result = await _repository.AddAsync(entity);

        if (!result.IsSuccess)
            return OperationResult<TDto>.Failure(result.Message, null, null);

        var mapped = _mapper.Map<TDto>(result.Data);
        return OperationResult<TDto>.Success(mapped, "Success");
    }

    public virtual async Task<OperationResult<ICollection<TDto>>> AddRangeAsync(ICollection<TDto> dtos)
    {
        var entities = dtos.Select(_mapper.Map<TEntity>).ToList();
        var result = await _repository.AddRangeAsync(entities);

        if (!result.IsSuccess)
            return OperationResult<ICollection<TDto>>.Failure(result.Message, null, null);

        var mapped = result.Data.Select(_mapper.Map<TDto>).ToList();
        return OperationResult<ICollection<TDto>>.Success(mapped, "Success");
    }

    public virtual async Task<OperationResult<TDto>> UpdateAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        var result = await _repository.Update(entity);

        if (!result.IsSuccess)
            return OperationResult<TDto>.Failure(result.Message, null, null);

        var mapped = _mapper.Map<TDto>(result.Data);
        return OperationResult<TDto>.Success(mapped, "Success");
    }

    public virtual async Task<OperationResult<TDto>> RemoveAsync(int id)
    {
        var result = await _repository.RemoveAsync(id);

        if (!result.IsSuccess)
            return OperationResult<TDto>.Failure(result.Message, null, null);

        var mapped = _mapper.Map<TDto>(result.Data);
        return OperationResult<TDto>.Success(mapped, "Success");
    }
}