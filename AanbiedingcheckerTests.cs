using System;
using Xunit;

public class AanbiedingcheckerTests
{
    [Fact]
    public void IsAanbiedingGeldig_HuidigeDatumBinnenRange_ReturnsTrue()
    {
        // Arrange
        var start = new DateTime(2025, 1, 1);
        var end = new DateTime(2025, 12, 31);
        var now = new DateTime(2025, 6, 1);

        // Act
        var result = Aanbiedingchecker.IsAanbiedingGeldig(start, end, now);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAanbiedingGeldig_HuidigeDatumVoorStart_ReturnsFalse()
    {
        var start = new DateTime(2025, 6, 2);
        var end = new DateTime(2025, 6, 30);
        var now = new DateTime(2025, 6, 1);

        var result = Aanbiedingchecker.IsAanbiedingGeldig(start, end, now);

        Assert.False(result);
    }

    [Fact]
    public void IsAanbiedingGeldig_HuidigeDatumNaEind_ReturnsFalse()
    {
        var start = new DateTime(2025, 1, 1);
        var end = new DateTime(2025, 5, 31);
        var now = new DateTime(2025, 6, 1);

        var result = Aanbiedingchecker.IsAanbiedingGeldig(start, end, now);

        Assert.False(result);
    }

    [Theory]
    [InlineData(100.00, 25.00, 75.00)]
    [InlineData(199.99, 10.00, 179.991)]
    public void BerekenAanbiedingsPrijs_ValidInputs_ReturnsExpected(decimal origineel, decimal korting, decimal expected)
    {
        var result = Aanbiedingchecker.BerekenAanbiedingsPrijs(origineel, korting);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void BerekenAanbiedingsPrijsRounded_RoundsCorrectly()
    {
        var origineel = 10.555m;
        var korting = 0m;

        var rounded = Aanbiedingchecker.BerekenAanbiedingsPrijsRounded(origineel, korting, 2);

        Assert.Equal(10.56m, rounded);
    }

    [Fact]
    public void BerekenKortingPercentage_ValidInputs_ReturnsExpected()
    {
        var origineel = 200m;
        var aanbieding = 150m;

        var percent = Aanbiedingchecker.BerekenKortingPercentage(origineel, aanbieding);

        Assert.Equal(25m, percent);
    }

    [Fact]
    public void BerekenKortingPercentage_OrigineelZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            Aanbiedingchecker.BerekenKortingPercentage(0m, 10m));
    }

    [Theory]
    [InlineData(50m, 100m, true)]
    [InlineData(150m, 100m, false)]
    public void IsPrijsOnderMax_Various(decimal prijs, decimal maximaal, bool expected)
    {
        var result = Aanbiedingchecker.IsPrijsOnderMax(prijs, maximaal);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void BerekenAanbiedingsPrijs_NegatievePrijs_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Aanbiedingchecker.BerekenAanbiedingsPrijs(-1m, 10m));
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(150)]
    public void BerekenAanbiedingsPrijs_OngeldigKorting_ThrowsArgumentOutOfRangeException(decimal korting)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Aanbiedingchecker.BerekenAanbiedingsPrijs(100m, korting));
    }
}
```// filepath: c:\Users\seege\Downloads\repoTrend\trendwatchgroep\AanbiedingcheckerTests.cs
using System;
using Xunit;

public class AanbiedingcheckerTests
{
    [Fact]
    public void IsAanbiedingGeldig_HuidigeDatumBinnenRange_ReturnsTrue()
    {
        // Arrange
        var start = new DateTime(2025, 1, 1);
        var end = new DateTime(2025, 12, 31);
        var now = new DateTime(2025, 6, 1);

        // Act
        var result = Aanbiedingchecker.IsAanbiedingGeldig(start, end, now);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAanbiedingGeldig_HuidigeDatumVoorStart_ReturnsFalse()
    {
        var start = new DateTime(2025, 6, 2);
        var end = new DateTime(2025, 6, 30);
        var now = new DateTime(2025, 6, 1);

        var result = Aanbiedingchecker.IsAanbiedingGeldig(start, end, now);

        Assert.False(result);
    }

    [Fact]
    public void IsAanbiedingGeldig_HuidigeDatumNaEind_ReturnsFalse()
    {
        var start = new DateTime(2025, 1, 1);
        var end = new DateTime(2025, 5, 31);
        var now = new DateTime(2025, 6, 1);

        var result = Aanbiedingchecker.IsAanbiedingGeldig(start, end, now);

        Assert.False(result);
    }

    [Theory]
    [InlineData(100.00, 25.00, 75.00)]
    [InlineData(199.99, 10.00, 179.991)]
    public void BerekenAanbiedingsPrijs_ValidInputs_ReturnsExpected(decimal origineel, decimal korting, decimal expected)
    {
        var result = Aanbiedingchecker.BerekenAanbiedingsPrijs(origineel, korting);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void BerekenAanbiedingsPrijsRounded_RoundsCorrectly()
    {
        var origineel = 10.555m;
        var korting = 0m;

        var rounded = Aanbiedingchecker.BerekenAanbiedingsPrijsRounded(origineel, korting, 2);

        Assert.Equal(10.56m, rounded);
    }

    [Fact]
    public void BerekenKortingPercentage_ValidInputs_ReturnsExpected()
    {
        var origineel = 200m;
        var aanbieding = 150m;

        var percent = Aanbiedingchecker.BerekenKortingPercentage(origineel, aanbieding);

        Assert.Equal(25m, percent);
    }

    [Fact]
    public void BerekenKortingPercentage_OrigineelZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            Aanbiedingchecker.BerekenKortingPercentage(0m, 10m));
    }

    [Theory]
    [InlineData(50m, 100m, true)]
    [InlineData(150m, 100m, false)]
    public void IsPrijsOnderMax_Various(decimal prijs, decimal maximaal, bool expected)
    {
        var result = Aanbiedingchecker.IsPrijsOnderMax(prijs, maximaal);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void BerekenAanbiedingsPrijs_NegatievePrijs_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Aanbiedingchecker.BerekenAanbiedingsPrijs(-1m, 10m));
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(150)]
    public void BerekenAanbiedingsPrijs_OngeldigKorting_ThrowsArgumentOutOfRangeException(decimal korting)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Aanbiedingchecker.BerekenAanbiedingsPrijs(100m, korting));
    }
}