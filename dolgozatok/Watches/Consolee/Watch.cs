namespace Consolee;

/*
| Mező                 | Jelentés                                     |
| -------------------- | -------------------------------------------- |
| `manufacturer`       | Az óra gyártója (pl. Rolex)                  |
| `model`              | A modell neve                                |
| `release_year`       | Megjelenési év                               |
| `type`               | Típus (analog, digital, smartwatch, stb.)    |
| `movement`           | Szerkezet (automatic, quartz, manual, smart) |
| `water_resistance_m` | Vízállóság méterben                          |
| `case_material`      | Tok anyaga                                   |
| `functions`          | Funkciók (pl. dátum, kronográf, GPS)         |
| `category`           | Kategória (luxury, midrange, budget, stb.)   |*/

public class Watch
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int ReleaseYear { get; set; }
    public string Type { get; set; }
    public string Movement { get; set; }
    public int WaterResistanceM { get; set; }
    public string CaseMaterial { get; set; }
    public List<string> Functions { get; set; }
    public string Category { get; set; }
    public Watch()
    {
        
    }

    public override string ToString()
    {
        return $"{Manufacturer} {Model} ({ReleaseYear}) - {Type}, {Movement}, {WaterResistanceM} m water resistance, {CaseMaterial} case, functions: {string.Join(", ", Functions)}, category: {Category}";
    }
}
