namespace madden.Models;

public abstract class IPowerTraits : ISpecialTraits
{
    public int? Strength { get; set; }
    public int? Toughness { get; set; }
    public int? Power { get; set; }
}