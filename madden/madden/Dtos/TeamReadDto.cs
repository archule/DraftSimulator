using System.ComponentModel.DataAnnotations;

namespace madden.Dtos
{
    public class TeamReadDto
    {

    public string? Name { get; set; }
    public List<int>? teamPicks { get; set;}

    }
}