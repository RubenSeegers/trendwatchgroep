using System;

public static class Program
{
    public static int Main(string[] args)
    {
        try
        {
            // Voorbeeld: datum-checks (gebruik pure overload voor determinisme)
            var startDatum = new DateTime(2025, 6, 1);
            var eindDatum = new DateTime(2025, 6, 30);
            var sampleDatum = new DateTime(2025, 6, 15);

            Console.WriteLine("Aanbieding geldig (nu): " +
                Aanbiedingchecker.IsAanbiedingGeldig(startDatum, eindDatum));

            Console.WriteLine("Aanbieding geldig (sample datum): " +
                Aanbiedingchecker.IsAanbiedingGeldig(startDatum, eindDatum, sampleDatum));

            // Prijsberekeningen
            decimal originelePrijs = 2.75m;
            decimal kortingPct = 20m;

            var aanbiedingPrijs = Aanbiedingchecker.BerekenAanbiedingsPrijs(originelePrijs, kortingPct);
            var aanbiedingPrijsRounded = Aanbiedingchecker.BerekenAanbiedingsPrijsRounded(originelePrijs, kortingPct, 2);

            Console.WriteLine($"Origineel: €{originelePrijs:0.00}, Korting: {kortingPct}% -> Aanbieding: €{aanbiedingPrijsRounded:0.00} " +
                              $"(exact: €{aanbiedingPrijs:0.000})");

            // Kortingpercentage terugrekenen
            var berekendPct = Aanbiedingchecker.BerekenKortingPercentage(originelePrijs, aanbiedingPrijs);
            Console.WriteLine($"Teruggerekend kortingpercentage: {berekendPct:0.##}%");

            // Coffee voorbeelden
            var normaleKoffie = new Coffee();
            var odinKoffie = new OdinCoffee();

            Console.WriteLine(normaleKoffie.ToString());
            Console.WriteLine(odinKoffie.ToString());

            // Gebruik aanbiedingchecker om prijs-voorwaarden te valideren
            var maxPrijs = 5.00m;
            Console.WriteLine($"Is Odin koffie ≤ €{maxPrijs:0.00}? " +
                              Aanbiedingchecker.IsPrijsOnderMax(odinKoffie.GetPrice(), maxPrijs));

            // Voorbeeld van invoervalidatie (vang validation exception)
            try
            {
                Aanbiedingchecker.BerekenAanbiedingsPrijs(-1m, 10m);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Validatiefout (voorbeeld): " + ex.Message);
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Onverwachte fout: " + ex);
            return 1;
        }
    }
}