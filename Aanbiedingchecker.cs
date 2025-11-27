using System;

public static class Aanbiedingchecker {
    // Bestaande API blijft werken maar roept nu de pure overload aan
    public static bool IsAanbiedingGeldig(DateTime startDatum, DateTime eindDatum) {
        return IsAanbiedingGeldig(startDatum, eindDatum, DateTime.Now);
    }

    // Pure functie: deterministic resultaat afhankelijk van inputs
    public static bool IsAanbiedingGeldig(DateTime startDatum, DateTime eindDatum, DateTime huidigeDatum) {
        return huidigeDatum >= startDatum && huidigeDatum <= eindDatum;
    }

    // Bestaande berekening maar met invoervalidatie via pure helper
    public static decimal BerekenAanbiedingsPrijs(decimal originelePrijs, decimal kortingPercentage) {
        ValideerPrijs(originelePrijs);
        ValideerKortingPercentage(kortingPercentage);
        decimal kortingBedrag = (originelePrijs * kortingPercentage) / 100m;
        return originelePrijs - kortingBedrag;
    }

    // Handige variant die afrondt voor presentatie/vergelijking
    public static decimal BerekenAanbiedingsPrijsRounded(decimal originelePrijs, decimal kortingPercentage, int decimalen = 2) {
        var prijs = BerekenAanbiedingsPrijs(originelePrijs, kortingPercentage);
        return Math.Round(prijs, decimalen);
    }

    // Berekent het kortingpercentage gegeven originele en aanbiedingprijs (pure)
    public static decimal BerekenKortingPercentage(decimal originelePrijs, decimal aanbiedingPrijs) {
        ValideerPrijs(originelePrijs);
        ValideerPrijs(aanbiedingPrijs);
        if (originelePrijs == 0m) throw new ArgumentException("Originele prijs mag niet nul zijn.", nameof(originelePrijs));
        var verschil = originelePrijs - aanbiedingPrijs;
        return (verschil / originelePrijs) * 100m;
    }

    // Controleert of een prijs onder een maximale grens blijft (pure)
    public static bool IsPrijsOnderMax(decimal prijs, decimal maximaal) {
        ValideerPrijs(prijs);
        ValideerPrijs(maximaal);
        return prijs <= maximaal;
    }

    // Pure validators (gooien exceptions bij ongeldige inputs)
    public static void ValideerPrijs(decimal prijs) {
        if (prijs < 0m) throw new ArgumentOutOfRangeException(nameof(prijs), "Prijs moet >= 0 zijn.");
    }

    public static void ValideerKortingPercentage(decimal kortingPercentage) {
        if (kortingPercentage < 0m || kortingPercentage > 100m) {
            throw new ArgumentOutOfRangeException(nameof(kortingPercentage), "Korting percentage moet tussen 0 en 100 liggen.");
        }
    }
}