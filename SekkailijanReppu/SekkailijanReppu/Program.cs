using System;
using System.Collections.Generic;

// Pääluokka tavaroille
abstract class Tavara
{
    public double Paino { get; }
    public double Tilavuus { get; }

    protected Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }
}

// Eri tavaraluokat
class Nuoli : Tavara { public Nuoli() : base(0.1, 0.05) { } }
class Jousi : Tavara { public Jousi() : base(1, 4) { } }
class Köysi : Tavara { public Köysi() : base(1, 1.5) { } }
class Vesi : Tavara { public Vesi() : base(2, 2) { } }
class RuokaAnnoss : Tavara { public RuokaAnnoss() : base(1, 0.5) { } }
class Miekka : Tavara { public Miekka() : base(5, 3) { } }

// Reppu-luokka
class Reppu
{
    private List<Tavara> tavarat;
    private int maxTavarat;
    private double maxPaino;
    private double maxTilavuus;

    public Reppu(int maxTavarat, double maxPaino, double maxTilavuus)
    {
        this.maxTavarat = maxTavarat;
        this.maxPaino = maxPaino;
        this.maxTilavuus = maxTilavuus;
        this.tavarat = new List<Tavara>();
    }

    public bool Lisää(Tavara tavara)
    {
        if (tavarat.Count >= maxTavarat ||
            NykyinenPaino + tavara.Paino > maxPaino ||
            NykyinenTilavuus + tavara.Tilavuus > maxTilavuus)
        {
            return false;
        }

        tavarat.Add(tavara);
        return true;
    }

    public int NykyinenMäärä => tavarat.Count;
    public double NykyinenPaino => tavarat.Sum(t => t.Paino);
    public double NykyinenTilavuus => tavarat.Sum(t => t.Tilavuus);

    public override string ToString()
    {
        return $"Reppu: {NykyinenMäärä}/{maxTavarat} tavaraa, " +
               $"Paino {NykyinenPaino}/{maxPaino} kg, " +
               $"Tilavuus {NykyinenTilavuus}/{maxTilavuus} L";
    }
}

// Pääohjelma
class Program
{
    static void Main()
    {
        Reppu reppu = new Reppu(10, 10, 10);
        Dictionary<int, Tavara> tavarat = new Dictionary<int, Tavara>
        {
            { 1, new Nuoli() },
            { 2, new Jousi() },
            { 3, new Köysi() },
            { 4, new Vesi() },
            { 5, new RuokaAnnoss() },
            { 6, new Miekka() }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine(reppu);
            Console.WriteLine("\nValitse lisättävä tavara:");
            Console.WriteLine("1. Nuoli\n2. Jousi\n3. Köysi\n4. Vesi\n5. Ruoka-annos\n6. Miekka\n0. Poistu");
            Console.Write("Valinta: ");

            if (!int.TryParse(Console.ReadLine(), out int valinta) || valinta == 0)
                break;

            if (tavarat.ContainsKey(valinta))
            {
                if (reppu.Lisää(tavarat[valinta]))
                {
                    Console.WriteLine("Tavara lisätty reppuun!");
                }
                else
                {
                    Console.WriteLine("Tavaran lisääminen epäonnistui, reppu on täynnä!");
                }
            }
            else
            {
                Console.WriteLine("Virheellinen valinta.");
            }

            Console.WriteLine("Paina Enter jatkaaksesi...");
            Console.ReadLine();
        }
    }
}

