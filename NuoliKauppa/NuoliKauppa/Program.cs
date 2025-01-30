using System;

enum KarjenTyyppi
{
    Puu = 1,
    Teras = 2,
    Timantti = 3
}

enum PeranTyyppi
{
    Lehti = 0,
    Kanansulka = 1,
    Kotkansulka = 5
}

class Nuoli
{
    public KarjenTyyppi KarjenTyyppi { get; private set; }
    public PeranTyyppi PeranTyyppi { get; private set; }
    public int VarrenPituus { get; private set; }

    public Nuoli(KarjenTyyppi karjenTyyppi, PeranTyyppi peranTyyppi, int varrenPituus)
    {
        if (varrenPituus < 60 || varrenPituus > 100)
        {
            throw new ArgumentException("Varren pituuden tulee olla 60 ja 100 cm välillä.");
        }

        KarjenTyyppi = karjenTyyppi;
        PeranTyyppi = peranTyyppi;
        VarrenPituus = varrenPituus;
    }

    public double PalautaHinta()
    {
        double karjenHinta = KarjenTyyppi switch
        {
            KarjenTyyppi.Puu => 3,
            KarjenTyyppi.Teras => 5,
            KarjenTyyppi.Timantti => 50,
            _ => throw new InvalidOperationException("Virheellinen kärjen tyyppi")
        };

        double peranHinta = (int)PeranTyyppi;
        double varrenHinta = VarrenPituus * 0.05;
        return karjenHinta + peranHinta + varrenHinta;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Valitse kärjen tyyppi (1: Puu, 2: Teräs, 3: Timantti):");
        int karjenValinta = int.Parse(Console.ReadLine());
        KarjenTyyppi karjenTyyppi = (KarjenTyyppi)karjenValinta;

        Console.WriteLine("Valitse perän tyyppi (1: Lehti, 2: Kanansulka, 3: Kotkansulka):");
        int peranValinta = int.Parse(Console.ReadLine());
        PeranTyyppi peranTyyppi = peranValinta switch
        {
            1 => PeranTyyppi.Lehti,
            2 => PeranTyyppi.Kanansulka,
            3 => PeranTyyppi.Kotkansulka,
            _ => throw new ArgumentException("Virheellinen perän tyyppi")
        };

        Console.WriteLine("Anna varren pituus (60-100 cm):");
        int varrenPituus = int.Parse(Console.ReadLine());

        try
        {
            Nuoli nuoli = new Nuoli(karjenTyyppi, peranTyyppi, varrenPituus);
            double hinta = nuoli.PalautaHinta();
            Console.WriteLine($"Nuolen hinta on {hinta:F2} kultaa.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Virhe: {e.Message}");
        }
    }
}
