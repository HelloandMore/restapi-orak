namespace Database.Models;

public class WatchModel
{
    public WatchModel()
    {
    }

    public WatchModel(WatchEntity e)
    {
        Id = e.Id;
        Manufacturer = e.Manufacturer;
        Model = e.Model;
        ReleaseYear = e.ReleaseYear;
        Type = e.Type;
        Movement = e.Movement;
        WaterResistanceM = e.WaterResistanceM;
        CaseMaterial = e.CaseMaterial;
        Functions = e.Functions;
        Category = e.Category;
    }

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
    public int WaterResistanceM { get; set; }

    [Required]
    public string CaseMaterial { get; set; } = string.Empty;

    [Required]
    public string Functions { get; set; } = string.Empty;

    [Required]
    public string Category { get; set; } = string.Empty;

    public WatchEntity ToEntity()
    {
        return new WatchEntity
        {
            Id = this.Id,
            Manufacturer = this.Manufacturer,
            Model = this.Model,
            ReleaseYear = this.ReleaseYear,
            Type = this.Type,
            Movement = this.Movement,
            WaterResistanceM = this.WaterResistanceM,
            CaseMaterial = this.CaseMaterial,
            Functions = this.Functions,
            Category = this.Category
        };
    }
}