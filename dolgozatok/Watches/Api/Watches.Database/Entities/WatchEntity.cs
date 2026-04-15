namespace Database.Entities;

[Table("Watches")]
public class WatchEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Manufacturer { get; set; } = string.Empty;

    [Required]
    public string Model { get; set; } = string.Empty;

    [Required]
    public int ReleaseYear { get; set; }

    [Required]
    public string Type { get; set; } = string.Empty;

    [Required]
    public string Movement { get; set; } = string.Empty;

    [Required]
    [Column("WaterResistance")]
    public int WaterResistanceM { get; set; }

    [Required]
    public string CaseMaterial { get; set; } = string.Empty;

    [Required]
    public string Functions { get; set; } = string.Empty;

    [Required]
    public string Category { get; set; } = string.Empty;
}