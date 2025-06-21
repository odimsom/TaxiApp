namespace TaxiApp.Core.Domain.Common;

public class BasicEntity<T>
{
    public required T Id { get; set; }
}