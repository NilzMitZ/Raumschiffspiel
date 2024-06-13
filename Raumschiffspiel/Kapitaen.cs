namespace Raumschiffspiel.Raumschiffspiel;

public class Kapitaen
{
    public Kapitaen(string name, int charisma, int erfahrung)
    {
        Name = name;
        Charisma = charisma;
        Erfahrung = erfahrung;
    }

    public string Name { get; set; }

    public int Charisma { get; set; }
    public int Erfahrung { get; set; }

    public void DiplomatischeVerhandlung()
    {
        var random = new Random();
        var luckFactor = random.Next(1, 11);
        var wert = (Charisma + Erfahrung) / luckFactor;

        if (wert > 3)
            Console.WriteLine("Die diplomatische Verhandlung war erfolgreich! Der wert war {0}", wert);
        else
            Console.WriteLine("Die diplomatische Verhandlung war nicht erfolgreich. Der wert war {0}", wert);
    }
}