using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities;

[Table("Route")]
public class RouteEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
}
