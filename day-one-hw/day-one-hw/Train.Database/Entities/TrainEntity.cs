namespace Train.Database.Entities;

[Table("Train")]
public class TrainEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(128)]
    [Required]
    public string PublicId { get; set; }

    [StringLength(128)]
    public string? ImageId { get; set; }

    [StringLength(512)]
    public string? WebContentLink { get; set; }

    [StringLength(128)]
    [Required]
    public string Name { get; set; }

    [StringLength(64)]
    [Required]
    public string Type { get; set; }

    [Required]
    public int BuildDate { get; set; }

    [Required]
    public int MaxSpeed { get; set; }

    [Required]
    public float Weight { get; set; }

    [Required]
    public float Length { get; set; }

    [Required]
    public float Gauge { get; set; }

    [Required]
    public float Power { get; set; }
}