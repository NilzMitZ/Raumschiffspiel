namespace Raumschiffspiel.Raumschiffspiel;

public class Handelsstation
{
    public Handelsstation(string name, int posX, int posY)
    {
        Name = name;
        PosX = posX;
        PosY = posY;
        Ladungen = new List<Ladung>();
    }

    public string Name { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public List<Ladung> Ladungen { get; set; }

    public void Handeln(Raumschiff raumschiff)
    {
        Console.WriteLine("Sie haben die Handelsstation {0} erreicht.", Name);
        Console.WriteLine("Sie haben folgende Ladungen an Bord:");
        Console.WriteLine(raumschiff.LadungenToString());

        Console.WriteLine("Wollen Sie Ladungen abladen? (j/n)");
        if (Console.ReadKey().KeyChar == 'j') RaumschiffLadungHandel(raumschiff);
    }

    public void RaumschiffLadungHandel(Raumschiff raumschiff)
    {
        Console.WriteLine("Welche Ladung wollen Sie abladen?");
        var id = Convert.ToInt32(Console.ReadLine());

        if (id > 0 && id <= raumschiff.Ladungen.Count)
        {
            var ladung = raumschiff.Ladungen[id - 1];
            raumschiff.RemoveLadung(ladung);
            Ladungen.Add(ladung);
            Console.WriteLine("Die Ladung wurde abgeladen.");
        }
        else
        {
            Console.WriteLine("Die Ladung konnte nicht abgeladen werden.");
        }
    }

    public string LadungenToString()
    {
        var result = "---------\nLadungen auf der Handelsstation:";

        for (var i = 0; i < Ladungen.Count; i++)
        {
            var ladung = Ladungen[i];
            result += "\n| ID: " + (i + 1) + " Name: " + ladung.Name + " Einheiten: " + ladung.Einheiten;
        }

        result += "\n---------";

        return result;
    }
}