namespace Raumschiffspiel.Raumschiffspiel;

public class Planet
{
    public Planet(string name, bool atmosphere, int posX, int posY)
    {
        Name = name;
        Atmosphere = atmosphere;
        PosX = posX;
        PosY = posY;
        Ladungen = new List<Ladung>();
    }

    public string Name { get; set; }
    public bool Atmosphere { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }

    public List<Ladung> Ladungen { get; set; }

    public int[] GetCoordinates()
    {
        return new[] { PosX, PosY };
    }

    public void AddLadung(Ladung ladung)
    {
        Ladungen.Add(ladung);
    }

    public void RemoveLadung(Ladung ladung)
    {
        Ladungen.Remove(ladung);
    }

    public string LadungenToString()
    {
        var result = "---------\nLadungen vom Planeten:";

        for (var i = 0; i < Ladungen.Count; i++)
        {
            var ladung = Ladungen[i];
            result += "\n| ID: " + (i + 1) + " Name: " + ladung.Name + " Einheiten: " + ladung.Einheiten;
        }

        result += "\n---------";

        return result;
    }

    public void MeetPlanet(Raumschiff raumschiff)
    {
        Console.WriteLine("Sie haben den Planeten {0} erreicht.", Name);
        if (Ladungen.Count >= 1)
        {
            Console.WriteLine("Es gibt folgende Ladungen auf dem Planeten:");
            Console.WriteLine(LadungenToString());
            Console.WriteLine("Wollen Sie Ladungen aufnehmen? (j/n)");
            if (Console.ReadKey().KeyChar == 'j') PlanetLadungHandel(raumschiff);
        }
        else
        {
            Console.WriteLine("Es gibt keine Ladungen auf dem Planeten.");
        }

        if (raumschiff.Ladungen.Count >= 1)
        {
            Console.WriteLine("Sie haben folgende Ladungen an Bord:");
            Console.WriteLine(raumschiff.LadungenToString());

            Console.WriteLine("Wollen Sie Ladungen abladen? (j/n)");
            if (Console.ReadKey().KeyChar == 'j') RaumschiffLadungHandel(raumschiff);
        }
        else
        {
            Console.WriteLine("Sie haben keine Ladungen an Bord.");
        }

        Console.WriteLine("Vielen Dank für den Handel.");
    }

    private void RaumschiffLadungHandel(Raumschiff raumschiff)
    {
        Console.WriteLine("Sie können folgende Ladungen abladen:");
        Console.WriteLine(raumschiff.LadungenToString());

        Console.WriteLine("Welche Ladung möchten Sie abladen? Bitte geben Sie die Id ein.");
        var ladungId = Convert.ToInt32(Console.ReadLine());
        if (raumschiff.Ladungen.ElementAtOrDefault(ladungId - 1) != null)
        {
            var ladung = raumschiff.Ladungen[ladungId - 1];
            AddLadung(ladung);
            raumschiff.RemoveLadung(ladung);
        }

        if (raumschiff.Ladungen.Count < 1) return;

        Console.WriteLine("Wollen Sie noch weitere Ladungen abgeben? (j/n)");
        if (Console.ReadKey().KeyChar == 'j') RaumschiffLadungHandel(raumschiff);
    }

    private void PlanetLadungHandel(Raumschiff raumschiff)
    {
        Console.WriteLine("Sie können folgende Ladungen vom Planeten aufnehman:");
        Console.WriteLine(LadungenToString());

        Console.WriteLine("Welche Ladung möchten Sie aufnehmen? Bitte geben Sie die Id ein.");
        var ladungId = Convert.ToInt32(Console.ReadLine());
        if (Ladungen.ElementAtOrDefault(ladungId - 1) != null)
        {
            var ladung = Ladungen[ladungId - 1];
            raumschiff.AddLadung(ladung);
            RemoveLadung(ladung);
        }

        if (Ladungen.Count < 1) return;

        Console.WriteLine("Wollen Sie noch weitere Ladungen aufnehmen? (j/n)");
        if (Console.ReadKey().KeyChar == 'j') PlanetLadungHandel(raumschiff);
    }
}