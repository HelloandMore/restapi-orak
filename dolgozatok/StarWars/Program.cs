// See https://aka.ms/new-console-template for more information
/* 

Enum javaslatok (C#)

OrderType
- Jedi
- Sith

Era
- OldRepublic
- CloneWars
- Empire
- Rebellion
- FirstOrder

Rang
- Youngling
- Padawan
- Knight
- Master
- Lord
- Apprentice
- DarkLord

 1. feladat – CSV beolvasás (4 pont)
2. feladat – Összes karakter száma (2 pont)
3. feladat – Jedi és Sith száma (3 pont)
4. feladat – Piros fénykardosok listája (3 pont) 
   Várható eredmény: Karakterek nevei, pl. Darth Vader, Darth Maul, Count Dooku….
5. feladat – Tatooine származású karakterek (3 pont)
   Várható eredmény: Karakterek nevei, pl. Anakin Skywalker, Luke Skywalker
6. feladat – Jedi mesterek (3 pont)
   Várható eredmény: Karakterek nevei, pl. Yoda, Obi-Wan Kenobi, Mace Windu….
7. feladat – Különböző bolygók száma (2 pont)
   Várható eredmény: Egész szám, pl. 18.
8. feladat – Era szerinti csoportosítás (4 pont)
   Várható eredmény:
   - CloneWars: 15
   - Rebellion: 1
   - Empire: 2
   - FirstOrder: 2
   - OldRepublic: 5
9. feladat – Leggyakoribb fénykard szín (3 pont)
   Várható eredmény: Pl. Blue.   
10. feladat – Tanítvánnyal rendelkező karakterek (5 pont)
    Várható eredmény:
    - Yoda → Luke Skywalker
    - Obi-Wan Kenobi → Anakin Skywalker
    - Anakin Skywalker → Ahsoka Tano
    - Darth Sidious → Darth Vader
    - Count Dooku → Asajj Ventress
    - Kit Fisto → Aayla Secura*/

var fileData = await File.ReadAllLinesAsync("star wars.csv", Encoding.UTF8);
var characters = new List<Character>();
foreach (var line in fileData)
{
    if (line == fileData[0]) continue;
    var data = line.Split(',');
    characters.Add(new Character
    {
        Id = int.Parse(data[0]),
        Name = data[1],
        OrderType = Enum.Parse<OrderEnum>(data[2]),
        Species = data[3],
        Homeworld = data[4],
        Era = Enum.Parse<EraEnum>(data[5]),
        Rank = Enum.Parse<RankEnum>(data[6]),
        LightsaberColor = data[7],
        Master = data[8],
        Apprentice = data[9],
        ForceSpecialty = data[10],
        IsAlive = bool.Parse(data[11])
    });
}

// 2. feladat – Összes karakter száma
Console.WriteLine($"Összes karakter száma: {characters.Count}");

// 3. feladat – Jedi és Sith száma
Console.WriteLine($"Jedi száma: {characters.Count(c => c.OrderType == OrderEnum.Jedi)}");
Console.WriteLine($"Sith száma: {characters.Count(c => c.OrderType == OrderEnum.Sith)}");

// 4. feladat – Piros fénykardosok listája
Console.WriteLine("Piros fénykardosok: ");
foreach (var character in characters.Where(c => c.LightsaberColor == "Red"))
{
    Console.Write(character.Name + ", ");
}
Console.WriteLine("\n");

// 5. feladat – Tatooine származású karakterek 
Console.WriteLine("Tatooine származású karakterek: ");
foreach (var character in characters.Where(c => c.Homeworld == "Tatooine"))
{
    Console.Write(character.Name + ", ");
}
Console.WriteLine("\n");

// 6. feladat – Jedi mesterek
Console.WriteLine("Jedi mesterek: ");
foreach (var character in characters.Where(c => c.Rank == RankEnum.Master && c.OrderType == OrderEnum.Jedi))
{
    Console.Write(character.Name + ", ");
}
Console.WriteLine("\n");

// 7. feladat – Különböző bolygók száma
Console.WriteLine($"Különböző bolygók száma: {characters.Select(c => c.Homeworld).Distinct().Count()}");
Console.WriteLine("\n");

// 8. feladat – Era szerinti csoportosítás
Console.WriteLine("Era szerinti csoportosítás: ");
foreach (var group in characters.GroupBy(c => c.Era))
{
    Console.WriteLine($"{group.Key}: {group.Count()}");
}
Console.WriteLine("\n");

// 9. feladat – Leggyakoribb fénykard szín
var mostCommonColor = characters.Where(c => !string.IsNullOrEmpty(c.LightsaberColor))
    .GroupBy(c => c.LightsaberColor)
    .OrderByDescending(g => g.Count())
    .FirstOrDefault().Key;
Console.WriteLine($"Leggyakoribb fénykard szín: {mostCommonColor}");
Console.WriteLine("\n");

// 10. feladat – Tanítvánnyal rendelkező karakterek
Console.WriteLine("Tanítvánnyal rendelkező karakterek: ");
foreach (var character in characters.Where(c => !string.IsNullOrEmpty(c.Apprentice) && c.Apprentice != "None"))
{
    Console.WriteLine($"{character.Name} - {character.Apprentice}");
}