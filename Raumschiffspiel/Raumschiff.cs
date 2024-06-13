namespace Raumschiffspiel.Raumschiffspiel;

public class Raumschiff
{
    public Raumschiff(string name, int posX, int posY, Kapitaen kapitaen, int integritaetsgrad, int energieschild,
        int energieVersorgung, int manoevrierFaehigkeit, int waffenstaerke)
    {
        Name = name;
        PosX = posX;
        PosY = posY;
        Kapitaen = kapitaen;
        Ladungen = new List<Ladung>();
        Integritaetsgrad = integritaetsgrad;
        Energieschild = energieschild;
        EnergieVersorgung = energieVersorgung;
        ManoevrierFaehigkeit = manoevrierFaehigkeit;
        Waffenstaerke = waffenstaerke;
    }

    public string Name { set; get; }
    public int PosX { set; get; }
    public int PosY { set; get; }
    public Kapitaen Kapitaen { set; get; }
    public List<Ladung> Ladungen { set; get; }
    public int Integritaetsgrad { set; get; }
    public int Energieschild { set; get; }
    public int EnergieVersorgung { set; get; }
    public int ManoevrierFaehigkeit { set; get; }
    public int Waffenstaerke { set; get; }

    public void Move(char direction)
    {
        switch (direction)
        {
            case 'w':
            case 'W':
                PosY++;
                break;
            case 's':
            case 'S':
                PosY--;
                break;
            case 'a':
            case 'A':
                PosX--;
                break;
            case 'd':
            case 'D':
                PosX++;
                break;
        }
    }

    public bool CheckCoordinates(int x, int y)
    {
        if (PosX == x && PosY == y)
        {
            Console.WriteLine("Hier ist das Raumschiff {0}.", Name);
            Kapitaen.DiplomatischeVerhandlung();
            return true;
        }

        return false;
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
        var result = "---------\nIhre Ladungen:";

        for (var i = 0; i < Ladungen.Count; i++)
        {
            var ladung = Ladungen[i];
            result += "\n| ID: " + (i + 1) + " Name: " + ladung.Name + " Einheiten: " + ladung.Einheiten;
        }

        result += "\n---------";

        return result;
    }

    public void PrintStatus()
    {
        var result = "";

        result += "----" + Name + "-----\n";

        result += "Integritaetsgrad: " + Integritaetsgrad + "\n";
        result += "Energieschild: " + Energieschild + "\n";
        result += "Energieversorgung: " + EnergieVersorgung + "\n";
        result += "Manoevrierfaehigkeit: " + ManoevrierFaehigkeit + "\n";
        result += "Waffenstaerke: " + Waffenstaerke + "\n";
        result += "-----" + Name + "-----";

        Console.WriteLine(result);
    }

    public void Angreifen(Raumschiff schiff)
    {
        var random = new Random();
        var luckFactor = random.Next(1, 25);
        var wert = (Waffenstaerke + ManoevrierFaehigkeit + Kapitaen.Erfahrung) / luckFactor;

        Console.Write("Es wurde " + wert + " Schaden gemacht!\n");

        var temp = schiff.Integritaetsgrad + schiff.Energieschild - wert;

        schiff.Integritaetsgrad = temp;
        schiff.Energieschild = 0;
    }
}