namespace Consolee;

public class Route
{
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public int DepartureHour { get; set; }
    public int DepartureMinute { get; set; }
    public int ArrivalHour { get; set; }
    public int ArrivalMinute { get; set; }
    public int DistanceKm { get; set; }

    public override string ToString()
    {
        return $"{DepartureCity} -> {ArrivalCity} | Indulás: {DepartureHour:D2}:{DepartureMinute:D2} | Érkezés: {ArrivalHour:D2}:{ArrivalMinute:D2} | Távolság: {DistanceKm} km";
    }
}
