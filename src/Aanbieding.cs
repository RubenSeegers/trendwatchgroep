using System;

namespace Trendwatchgroep.Tasks
{
    // Pure domain class representing an Aanbieding (offer)
    public class Aanbieding
    {
        public Guid Id { get; }
        public string Naam { get; }
        public decimal OriginelePrijs { get; }
        public decimal AanbiedingsPrijs { get; }
        public DateTime StartDatum { get; }
        public DateTime EindDatum { get; }

        public Aanbieding(string naam, decimal originelePrijs, decimal aanbiedingPrijs, DateTime startDatum, DateTime eindDatum)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new ArgumentException("Naam is verplicht", nameof(naam));
            Aanbiedingchecker.ValideerPrijs(originelePrijs);
            Aanbiedingchecker.ValideerPrijs(aanbiedingPrijs);
            if (startDatum > eindDatum) throw new ArgumentException("Startdatum moet voor einddatum liggen");

            Id = Guid.NewGuid();
            Naam = naam.Trim();
            OriginelePrijs = originelePrijs;
            AanbiedingsPrijs = aanbiedingPrijs;
            StartDatum = startDatum;
            EindDatum = eindDatum;
        }

        // Deterministische check of aanbieding geldig is op een gegeven datum
        public bool IsGeldigOp(DateTime huidigeDatum) => Aanbiedingchecker.IsAanbiedingGeldig(StartDatum, EindDatum, huidigeDatum);

        // Huidige geldigheid (gebruik adapter to inject time if needed)
        public bool IsHuidig() => IsGeldigOp(DateTime.Now);

        // Berekent het kortingpercentage gebaseerd op originele prijs en aanbieding prijs
        public decimal KortingPercentage()
        {
            return Aanbiedingchecker.BerekenKortingPercentage(OriginelePrijs, AanbiedingsPrijs);
        }

        // Berekent de aanbieding prijs rounded voor presentatie
        public decimal AanbiedingsPrijsRounded(int decimalen = 2)
        {
            return Aanbiedingchecker.BerekenAanbiedingsPrijsRounded(OriginelePrijs, KortingPercentage(), decimalen);
        }
    }
}