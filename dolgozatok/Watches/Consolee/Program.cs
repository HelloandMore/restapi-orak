/*
 FELADATOK:

1 - Olvasd be a CSV fájlt, és tárold az adatokat egy megfelelő adatszerkezetben

2 - Hány karóra található az adatbázisban

3 - Határozd meg melyik a legrégebbi modell és írd ki a teljes adatait

4- Listázd ki azokat az órákat amelyek vízállósága legalább 200 méter

5 - Kérj be a felhasználótól egy kulcsszót (pl. "GPS" vagy "kronográf"), majd:
    listázd ki azokat az órákat, amelyek functions mezője tartalmazza ezt

6 - Számold ki az órák átlagos vízállóságát

7 - Csoportosítsd az órákat category szerint, majd írd ki:
	luxury (15 db):
	 - Rolex Submariner
	 - Omega Speedmaster
	midrange (20 db):

8 - Gyártónként írd ki:
	- hány modelljük van
	- átlagos vízállóság
	
	Példa:

	Rolex:
	  Modellek száma: 3
	  Átlag vízállóság: 166.6 m
	  
9 - Határozd meg melyik movement típus fordul elő a legtöbbször
10 - Listázd ki azokat az órákat:
	 - amelyek luxury kategóriába tartozna és vízállóságuk ≥ 100 m
	Majd:
	- csoportosítsd őket gyártó szerint
	- rendezd gyártón belül év szerint növekvően
	- formázottan írd ki:	
		Omega:
		  - 1957 Speedmaster Professional
		  - 1993 Seamaster Diver 300M

		Rolex:
		  - 1953 Submariner
		  - 1963 Daytona
 */

var fileData = await File.ReadAllLinesAsync("adatok.csv", Encoding.UTF8);
var watches = new List<Watch>();
foreach (var line in fileData)
{
    if (line == fileData[0]) continue;
    var data = line.Split(',');
    watches.Add(new Watch
    {
		Manufacturer = data[0],
		Model = data[1],
		ReleaseYear = int.Parse(data[2]),
		Type = data[3],
		Movement = data[4],
		WaterResistanceM = int.Parse(data[5]),
		CaseMaterial = data[6],
		Functions = data[7].Split("|").ToList(),
        Category = data[8]
    });
}


// 2. feladat
Console.WriteLine($"2. feladat: Az adatbázisban {watches.Count} karóra van.\n");

// 3. feladat
var oldestWatch = watches.OrderBy(w => w.ReleaseYear).First();
Console.WriteLine($"3. feladat: A legrégebbi modell adatai: {oldestWatch}\n");

// 4. feladat
Console.WriteLine("4. feladat: Azok az órák, amelyek vízállósága legalább 200 méter:");
foreach (var watch in watches.Where(w => w.WaterResistanceM >= 200))
{
	Console.WriteLine(watch);
}
Console.WriteLine("\n");

// 5. feladat
Console.WriteLine("5. feladat: Kérem adjon meg egy kulcsszót:");
var keyword = Console.ReadLine();
Console.WriteLine($"Azok az órák, amelyek functions mezője tartalmazza a '{keyword}' kulcsszót:");
foreach (var watch in watches.Where(w => w.Functions.Any(f => f.Contains(keyword, StringComparison.OrdinalIgnoreCase))))
{
	Console.WriteLine(watch);
}

// 6. feladat
Console.WriteLine($"\n6. feladat: Az órák átlagos vízállósága: {watches.Average(w => w.WaterResistanceM):F2} m\n");

// 7. feladat
Console.WriteLine("7. feladat: Az órák csoportosítva category szerint:");
var groupedByCategory = watches.GroupBy(w => w.Category);
foreach (var group in groupedByCategory)
{
	Console.WriteLine($"{group.Key} ({group.Count()} db):");
	foreach (var watch in group)
	{
		Console.WriteLine($" - {watch.Manufacturer} {watch.Model}");
    }
}
Console.WriteLine("\n");

// 8. feladat
Console.WriteLine("8. feladat: Az órák csoportosítva gyártó szerint:");
var groupedByManufacturer = watches.GroupBy(w => w.Manufacturer);
foreach (var group in groupedByManufacturer)
{
	Console.WriteLine($"{group.Key}:");
	Console.WriteLine($"  Modellek száma: {group.Count()}");
	Console.WriteLine($"  Átlag vízállóság: {group.Average(w => w.WaterResistanceM):F2} m\n");
}
Console.WriteLine("\n");

// 9. feladat
var mostCommonMovement = watches.GroupBy(w => w.Movement)
	.OrderByDescending(g => g.Count())
	.First().Key;
Console.WriteLine($"9. feladat: A legtöbbször előforduló movement típus: {mostCommonMovement}\n");

// 10. feladat
Console.WriteLine("10. feladat: Azok az órák, amelyek luxury kategóriába tartoznak és vízállóságuk >= 100 m:");
var luxuryWatches = watches.Where(w => w.Category == "luxury" && w.WaterResistanceM >= 100)
	.GroupBy(w => w.Manufacturer)
	.OrderBy(g => g.Key);

foreach (var group in luxuryWatches)
{
	Console.WriteLine($"{group.Key}:");
	foreach (var watch in group.OrderBy(w => w.ReleaseYear))
	{
		Console.WriteLine($"  - {watch.ReleaseYear} {watch.Model}");
	}
}