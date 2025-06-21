namespace TaxiApp.Core.Application.DTO.Common;

public class BasicDto<T>
{
    public required T Id { get; set; }
}