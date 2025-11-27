using System;

public interface ICoffee
{
	string Name { get; }
	string Description { get; }
	decimal Price { get; }
	decimal GetPrice();
}

public class Coffee : ICoffee
{
	public string Name { get; protected set; }
	public string Description { get; protected set; }
	public decimal Price { get; protected set; }

	public Coffee(string name = "Standaard Koffie", string description = "Een simpele filterkoffie.", decimal price = 1.50m)
	{
		Name = name;
		Description = description;
		Price = price;
	}

	public virtual decimal GetPrice()
	{
		return Price;
	}

	public override string ToString()
	{
		return $"{Name}: {Description} (€{GetPrice():0.00})";
	}
}

public class OdinCoffee : Coffee
{
	// OdinCoffee is a special, premium blend inspired by mythic flavours.
	public bool HasSmokedBeans { get; }
	public decimal RitualFee { get; }

	public OdinCoffee(bool hasSmokedBeans = true, decimal ritualFee = 0.75m)
		: base(name: "Odin Koffie", description: "Een krachtige, gerookte en kruidige blend met aards karakter.", price: 2.75m)
	{
		HasSmokedBeans = hasSmokedBeans;
		RitualFee = ritualFee;
	}

	public override decimal GetPrice()
	{
		decimal total = Price;
		if (HasSmokedBeans) total += 0.25m; // small upcharge for smoked beans
		total += RitualFee; // special preparation
		return total;
	}
}