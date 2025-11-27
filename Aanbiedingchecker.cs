public static class Aanbiedingchecker {
    public static bool IsAanbiedingGeldig(DateTime startDatum, DateTime eindDatum) {
        DateTime huidigeDatum = DateTime.Now;
        return huidigeDatum >= startDatum && huidigeDatum <= eindDatum;
    }

    public static decimal BerekenAanbiedingsPrijs(decimal originelePrijs, decimal kortingPercentage) {
        if (kortingPercentage < 0 || kortingPercentage > 100) {
            throw new ArgumentOutOfRangeException("kortingPercentage", "Korting percentage moet tussen 0 en 100 liggen.");
        }
        decimal kortingBedrag = (originelePrijs * kortingPercentage) / 100;
        return originelePrijs - kortingBedrag;
    }

    
}