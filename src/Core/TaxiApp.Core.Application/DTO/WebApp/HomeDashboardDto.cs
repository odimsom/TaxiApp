namespace TaxiApp.Core.Application.DTO.WebApp;

public class HomeDashboardDto
{
    public int TotalTaxis { get; set; }
    public int TaxisEnViaje { get; set; }
    public int TotalTripsMes { get; set; }
    public int TripsEnCurso { get; set; }
    public int TotalUsuarios { get; set; }
    public int UsuariosActivos { get; set; }
    public List<TripSummaryDto> UltimosViajes { get; set; } = new();
}