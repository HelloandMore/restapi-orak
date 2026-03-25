namespace StarWars;

public class Character
{
    /* | Tulajdonság     | Típus  | Magyarázat               |
| --------------- | ------ | ------------------------ |
| Id              | int    | Egyedi azonosító         |
| Name            | string | Karakter neve            |
| OrderType       | enum   | Jedi vagy Sith           |
| Species         | string | Faj (Human, Zabrak stb.) |
| Homeworld       | string | Származási bolygó        |
| Era             | enum   | Korszak                  |
| Rank            | enum   | Rang                     |
| LightsaberColor | string | Fénykard színe           |
| Master          | string | Mestere                  |
| Apprentice      | string | Tanítványa               |
| ForceSpecialty  | string | Speciális erőhasználat   |
| IsAlive         | bool   | Él-e                     |*/

    public int Id { get; set; }

    public string Name { get; set; }

    public OrderEnum OrderType { get; set; }

    public string Species { get; set; }

    public string Homeworld { get; set; }

    public EraEnum Era { get; set; }

    public RankEnum Rank { get; set; }

    public string LightsaberColor { get; set; }

    public string Master { get; set; }

    public string Apprentice { get; set; }

    public string ForceSpecialty { get; set; }

    public bool IsAlive { get; set; }

    public override string ToString()
    {
        return $"{Name} ({OrderType}) - {Rank}";
    }
}
