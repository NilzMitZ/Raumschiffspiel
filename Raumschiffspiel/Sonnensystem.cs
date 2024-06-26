namespace Raumschiffspiel.Raumschiffspiel;

public class Sonnensystem
{
    public static void Main(string[] args)
    {
        var raumschiffe = new List<Raumschiff>();
        var planets = new List<Planet>();

        var random = new Random();
        const int range = 20;

        planets.Add(new Planet("Mercury", true, 10, 10));
        planets.Add(new Planet("Venus", false, random.Next(-range, range), random.Next(-range, range)));
        planets.Add(new Planet("Earth", true, random.Next(-range, range), random.Next(-range, range)));
        planets.Add(new Planet("Mars", false, random.Next(-range, range), random.Next(-range, range)));
        planets.Add(new Planet("Jupiter", true, random.Next(-range, range), random.Next(-range, range)));

        planets[0].AddLadung(new Ladung("Metalle", 200));
        planets[0].AddLadung(new Ladung("Suppe", 50));


        var alexiaNova = new Kapitaen("Alexia Nova", 10, 10);
        var admiralZenith = new Kapitaen("Admiral Zenith Nightfall", 5, 5);

        var eosNova = new Raumschiff("Eos Nova", 0, 0, alexiaNova, 100, 50, 5, 10, 35);
        var auroraQuest = new Raumschiff("Aurora Quest", 1, 1, admiralZenith, 50, 20, 20, 40, 10);

        raumschiffe.Add(eosNova);
        raumschiffe.Add(auroraQuest);

        var eigenesRaumschiff = raumschiffe.First();

        eigenesRaumschiff.AddLadung(new Ladung("Gemüse", 20));
        eigenesRaumschiff.AddLadung(new Ladung("Äpfel", 25));

        eigenesRaumschiff.Kapitaen.Name = "Alexia Starlight Nova";

        Console.WriteLine("Das Spiel beginnt. Sie Fliegen das Raumschiff {0}! Gesteuert von {1}",
            eigenesRaumschiff.Name,
            eigenesRaumschiff.Kapitaen.Name);
        var gameOver = false;

        while (!gameOver)
        {
            Console.WriteLine("Raumschiff Kooridnaten: ({0}, {1})", eigenesRaumschiff.PosX, eigenesRaumschiff.PosY);
            Console.WriteLine("Bewegung (w, a, s, d)");

            var direction = Console.ReadKey().KeyChar;

            if (direction.ToString().ToLower().Equals("q"))
                break;

            eigenesRaumschiff.Move(direction);

            Console.WriteLine();

            for (var i = 1; i < raumschiffe.Count; i++)
            {
                var current = raumschiffe[i];

                if (current != null && eigenesRaumschiff.CheckCoordinates(current.PosX, current.PosY))
                {
                    Console.WriteLine("Wollen sie gegen das Raumschiff {0} kämpfen? (j/n)", current.Name);

                    var input = Console.ReadKey().KeyChar;

                    if (input.ToString().ToLower().Equals("j"))
                    {
                        if (!Kampf(eigenesRaumschiff, current)) break;

                        eigenesRaumschiff.Energieschild = 50;
                        raumschiffe[i] = null;
                    }
                }
            }


            foreach (var planet in planets)
                if (eigenesRaumschiff.PosX == planet.GetCoordinates()[0] &&
                    eigenesRaumschiff.PosY == planet.GetCoordinates()[1])
                    planet.MeetPlanet(eigenesRaumschiff);
        }
    }

    public static bool Kampf(Raumschiff eigenesSchiff, Raumschiff gegnerSchiff)
    {
        eigenesSchiff.PrintStatus();
        Console.WriteLine("\n");
        gegnerSchiff.PrintStatus();

        while (true)
        {
            Console.WriteLine("Sie greifen an!\n");
            eigenesSchiff.Angreifen(gegnerSchiff);

            if (gegnerSchiff.Integritaetsgrad <= 0)
            {
                Console.WriteLine("Sie haben gewonnen!");
                return true;
            }

            Console.WriteLine("Sie werden angegriffen!\n");
            gegnerSchiff.Angreifen(eigenesSchiff);

            if (eigenesSchiff.Integritaetsgrad <= 0)
            {
                Console.WriteLine("Sie haben verloren!");
                return false;
            }

            eigenesSchiff.PrintStatus();
            Console.WriteLine("\n");
            gegnerSchiff.PrintStatus();

            Console.WriteLine("Geben sie eine taste ein um weiter zu Kämpfen!");
            var temp = Console.ReadKey().KeyChar;
        }
    }
}