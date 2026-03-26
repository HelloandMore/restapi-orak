namespace Database.Models;

public class RouteModel
{
    public RouteModel()
    {
    }

    public RouteModel(RouteEntity e)
    {
        Id = e.Id;
        DepartureCity = e.DepartureCity;
        ArrivalCity = e.ArrivalCity;
        DepartureHour = e.DepartureHour;
        DepartureMinute = e.DepartureMinute;
        ArrivalHour = e.ArrivalHour;
        ArrivalMinute = e.ArrivalMinute;
        DistanceKm = e.DistanceKm;
    }

    public int Id { get; set; }

    [Required]
    public string DepartureCity { get; set; }

    [Required]
    public string ArrivalCity { get; set; }

    [Required]
    public int DepartureHour { get; set; }

    [Required]
    public int DepartureMinute { get; set; }

    [Required]
    public int ArrivalHour { get; set; }

    [Required]
    public int ArrivalMinute { get; set; }

    [Required]
    public int DistanceKm { get; set; }

    public RouteEntity ToEntity()
    {
        return new RouteEntity
        {
            Id = this.Id,
            DepartureCity = this.DepartureCity,
            ArrivalCity = this.ArrivalCity,
            DepartureHour = this.DepartureHour,
            DepartureMinute = this.DepartureMinute,
            ArrivalHour = this.ArrivalHour,
            ArrivalMinute = this.ArrivalMinute,
            DistanceKm = this.DistanceKm
        };
    }
}
