using System.ComponentModel.DataAnnotations;
using madden.Models;

namespace madden.Dtos
{
    public class RoomReadDto
    {
    public string? Name { get; set; }
    public string Code { get; set; }
    public Dictionary<ApplicationUser, Team> Mapping { get; set; }

    public int TimerDuration { get; set; }  

    }
}