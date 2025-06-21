using TaxiApp.Core.Domain.Common;

namespace TaxiApp.Core.Application.Interfaces.Common;

public interface IGenericService<TDto, TEntity> 
    where TDto : class
    where TEntity : class
{
    Task<OperationResult<ICollection<TDto>>> GetAllAsync();
    Task<OperationResult<ICollection<TDto>>> GetAllIncludeAsync(ICollection<string> properties);
    Task<OperationResult<TDto>> GetByIdAsync(int id);
    Task<OperationResult<TDto>> AddAsync(TDto dto);
    Task<OperationResult<ICollection<TDto>>> AddRangeAsync(ICollection<TDto> dtos);
    Task<OperationResult<TDto>> UpdateAsync(TDto dto);
    Task<OperationResult<TDto>> RemoveAsync(int id);
}