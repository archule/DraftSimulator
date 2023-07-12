

using System.ComponentModel.DataAnnotations;
using madden.Models;

namespace madden.Dtos
{
    public class RoomCreateDto
    {
    
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Code { get; set; }
    [Required]
    public string? Team { get; set; }
    [Required]
    public int? TimerDuration { get; set; }  

    }
}