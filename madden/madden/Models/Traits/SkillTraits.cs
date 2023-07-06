namespace madden.Models;

public abstract class ISkillTraits : ISpecialTraits
{
    public int? Speed { get; set; }
    public int? Agility { get; set; }
    public int? Acceleration { get; set; }
    
}