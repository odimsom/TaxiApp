namespace TaxiApp.Core.Application.DTO.WebApp;

public class TripSummaryDto
{
    public int Id { get; set; }
    public string TaxiPlate { get; set; } = "";
    public string UsuarioNombre { get; set; } = "";
    public DateTime StartDate { get; set; }
    public string Estado { get; set; } = "";
}