

using System.ComponentModel.DataAnnotations;
using madden.Models;

namespace madden.Dtos
{
    public class RoomCreateDto
    {
    public string? Name { get; set; }
    public string Code { get; set; }
    public string? team { get; set; }
    Dictionary<ApplicationUser, Team> Mapping { get; set; }
    public int TimerDuration { get; set; }  

    }
}