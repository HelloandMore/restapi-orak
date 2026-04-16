namespace Database.Entities;

[Table("Watches")]
public class WatchEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Manufacturer { get; set; }

    [Required]
    public string Model { get; set; }

    [Required]
    public int ReleaseYear { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public string Movement { get; set; }

    [Required]
    [Column("WaterResistance")]
    public int WaterResistanceM { get; set; }

    [Required]
    public string CaseMaterial { get; set; }

    [Required]
    public string Functions { get; set; }

    [Required]
    public string Category { get; set; }
}