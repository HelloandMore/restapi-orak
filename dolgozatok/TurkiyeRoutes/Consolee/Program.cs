/*TurkeyRoutes

Az adatállomány törökországi városok közötti utazásokat tartalmaz.
Minden egyes sor egy konkrét útvonalat ír le, amely megadja,
hogy honnan hova történik az utazás, mikor indul, mikor érkezik,
valamint mekkora a két város közötti távolság kilométerben.
Az adatokban szerepel az indulási város és az érkezési város neve.
Ezek egyszerű szöveges adatok, például Isztambul, Ankara vagy Izmir.
Az időpontokat külön mezőkben tároljuk: az indulási idő órára és percre bontva van megadva,
ugyanígy az érkezési idő is külön órát és percet tartalmaz.
Az időadatok 24 órás formátumban szerepelnek, tehát például a 6 óra 30 percet 6 és 30 értékek
jelölik.
A távolság egy egész szám, amely kilométerben adja meg a két város közötti utat.
Ezek az értékek becsült adatok, nem feltétlenül pontos közúti távolságok,
de alkalmasak számítási feladatokra.
Az adatokból többféle információ számítható. Meghatározható például az egyes utak menetideje úgy,
hogy az érkezési időt kivonjuk az indulási időből (percben számolva).
Ebből később kiszámítható az átlagsebesség is, ha a távolságot elosztjuk a menetidővel
(órában kifejezve).
Fontos feltételezés, hogy minden utazás egy napon belül történik, tehát nincs olyan eset,
amikor az indulás és az érkezés külön napra esne.
Az adatállomány jól használható gyakorlásra, például adatok beolvasására, szűrésére,
csoportosítására, valamint különböző számítások elvégzésére, mint például menetidő vagy
átlagsebesség meghatározása.
-------------------------------------------------------------------------------------------
Példa rekord értelmezése
Istanbul → Ankara, indulás: 06:30, érkezés: 11:15, távolság: 450 km
-------------------------------------------------------------------------------------------
Fontos megjegyzések az adatokhoz
Az időadatok 24 órás formátumban vannak megadva
Az indulási és érkezési idő azonos napon belüli utazást feltételez
-------------------------------------------------------------------------------------------
A menetidő kiszámítható:

menetidő (perc) = (ArrivalHour * 60 + ArrivalMinute) - (DepartureHour * 60 + DepartureMinute)
-------------------------------------------------------------------------------------------
Az átlagsebesség számítása:

átlagsebesség (km/h) = DistanceKm / (menetidő órában)
-------------------------------------------------------------------------------------------
FELADATOK:

1. Adatok beolvasása
Olvasd be a CSV fájlt egy megfelelő adatszerkezetbe.

2. Határozd meg, hány út szerepel az adatállományban.

3. Városok listája (kiinduló és érkező városok).

4. Készíts listát az összes különböző indulási városról.

5. Listázd ki azokat az utakat, amelyek reggel 8:00 előtt indulnak.

6. Számítsd ki minden út esetében a teljes menetidőt percben az indulási és érkezési idő alapján.

7. Határozd meg, melyik út rendelkezik a leghosszabb menetidővel, és add meg az adatokat.

8. Számítsd ki minden út esetében az átlagsebességet (km/h) a távolság és a menetidő alapján.

9. Listázd ki azokat az utakat, ahol az átlagsebesség:
   - nagyobb mint 130 km/h
   - kisebb mint 40 km/h
   
10. Csoportosítsd az adatokat érkezési város szerint, és határozd meg:
    - hány út érkezik az adott városba
    - az átlagos távolságot városonként */
var fileData = await File.ReadAllLinesAsync("adatok.csv", Encoding.UTF8);
var routes = new List<Route>();
foreach (var line in fileData)
{
    if (line == fileData[0]) continue;
    var data = line.Split(',');
    routes.Add(new Route
    {
        DepartureCity = data[0],
        ArrivalCity = data[1],
        DepartureHour = int.Parse(data[2]),
        DepartureMinute = int.Parse(data[3]),
        ArrivalHour = int.Parse(data[4]),
        ArrivalMinute = int.Parse(data[5]),
        DistanceKm = int.Parse(data[6])
    });
}

List<TimeSpan> durations = routes
    .Select(r =>
    {
        var departure = new TimeSpan(r.DepartureHour, r.DepartureMinute, 0);
        var arrival = new TimeSpan(r.ArrivalHour, r.ArrivalMinute, 0);
        return arrival - departure;
    })
    .ToList();

List<int> durationsInMinutes = durations
    .Select(ts => (int)ts.TotalMinutes)
    .ToList();

List<double> averageSpeeds = routes
    .Select((r, i) =>
    {
        var hours = durations[i].TotalHours;
        return hours > 0.0 ? r.DistanceKm / hours : 0.0;
    })
    .ToList();

// 2. feladat
Console.WriteLine($"2. Az adatállományban {routes.Count} út szerepel.");

// 3. feladat
var cities = routes
    .SelectMany(r => new[] { r.DepartureCity, r.ArrivalCity })
    .Distinct()
    .OrderBy(c => c)
    .ToList();
Console.WriteLine("3. Városok (kiinduló és érkező):");
Console.WriteLine(string.Join(", ", cities));
Console.WriteLine("\n");

// 4. feladat
var departureCities = routes
    .Select(r => r.DepartureCity)
    .Distinct()
    .OrderBy(c => c)
    .ToList();

Console.WriteLine("4. Különböző indulási városok:");
Console.WriteLine(string.Join(", ", departureCities));
Console.WriteLine("\n");

// 5. feladat
var earlyRoutes = routes
    .Where(r => r.DepartureHour < 8 || (r.DepartureHour == 8 && r.DepartureMinute == 0))
    .ToList();
Console.WriteLine("5. Utak, amelyek reggel 8:00 előtt indulnak:");
foreach (var route in earlyRoutes)
{
    Console.WriteLine($"{route.DepartureCity} - {route.ArrivalCity}, indulás: {route.DepartureHour:D2}:{route.DepartureMinute:D2}");
}
Console.WriteLine("\n");

// 6. feladat
Console.WriteLine("6. Minden út menetideje (percben):");
foreach (var r in routes)
{
    Console.WriteLine($"{r.DepartureCity} - {r.ArrivalCity}: {durationsInMinutes[routes.IndexOf(r)]} perc");
}
Console.WriteLine("\n");

// 7. feladat
var longestRoute = routes[durationsInMinutes.IndexOf(durationsInMinutes.Max())];
Console.WriteLine($"Leghosszabb menetidővel rendelkező út: {longestRoute}");
Console.WriteLine("\n");

// 8. feladat
Console.WriteLine("8. Minden út átlagsebessége (km/h):");
foreach (var r in routes)
{
    Console.WriteLine($"{r.DepartureCity} - {r.ArrivalCity}: {averageSpeeds[routes.IndexOf(r)]:F2} km/h");
}
Console.WriteLine("\n");

// 9. feladat
var fastRoutes = routes.Where((r, i) => averageSpeeds[i] > 130).ToList();
var slowRoutes = routes.Where((r, i) => averageSpeeds[i] < 40).ToList();

Console.WriteLine("9. Utak, ahol nagyobb az átlagsebesség 130 km/h-nál: ");
foreach (var route in fastRoutes)
{
    Console.WriteLine(route);
}

Console.WriteLine("\n9. Utak, ahol kisebb az átlagsebesség 40 km/h-nál: ");
foreach (var route in slowRoutes)
{
    Console.WriteLine(route);
}
Console.WriteLine("\n");

// 10. feladat
var groupedByArrivalCity = routes
    .GroupBy(r => r.ArrivalCity)
    .Select(g => new ArrivalCityStats(
        g.Key,
        g.Count(),
        g.Average(r => r.DistanceKm)
    ))
    .ToList();
Console.WriteLine("10. Csoportosítás érkezési város szerint:");
foreach (var group in groupedByArrivalCity)
{
    Console.WriteLine($"{group.ArrivalCity}: {group.RouteCount} út, átlagos távolság: {group.AverageDistance:F2} km");
}