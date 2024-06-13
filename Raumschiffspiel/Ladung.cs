namespace Raumschiffspiel.Raumschiffspiel;

public class Ladung
{
    public Ladung(string name, int einheiten)
    {
        Name = name;
        Einheiten = einheiten;
    }

    public Ladung()
    {
        Name = "Leerladung";
        Einheiten = 0;
    }

    public string Name { get; set; }
    public int Einheiten { get; set; }

    public string ToString()
    {
        return "name:" + Name + ", Einheiten:" + Einheiten;
    }
}