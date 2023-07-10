using System.Diagnostics;
namespace madden.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Dictionary<ApplicationUser, Team> Mapping { get; set; }
    public int CurrentPick { get; set; }
    public int TimerDuration { get; set; }   
}
