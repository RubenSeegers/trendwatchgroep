# Trendwatchgroep

Voorbeeld gebruik van de `Coffee` classes:

```csharp
// Maak een standaard koffie aan
var standaard = new Coffee();
Console.WriteLine(standaard); // Standaard Koffie: Een simpele filterkoffie. (€1.50)

// Maak een speciale Odin koffie aan
var odin = new OdinCoffee();
Console.WriteLine(odin); // Odin Koffie: Een krachtige, gerookte en kruidige blend met aards karakter. (€...)

// Je kunt ook de prijs opvragen
Console.WriteLine($"Odin prijs: €{odin.GetPrice():0.00}");
```

Voeg deze classes toe aan je project en gebruik ze waar nodig.
