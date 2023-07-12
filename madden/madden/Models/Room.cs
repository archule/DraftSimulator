using System.Diagnostics;
namespace madden.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using madden.Dtos;
using Microsoft.AspNetCore.Identity;

public class Room
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Dictionary<IdentityUser, string> Mapping { get; set; }
    public int CurrentPick { get; set; }
    public int? TimerDuration { get; set; } 

    public Room(RoomCreateDto dto, IdentityUser user)
    {
        Name = dto.Name;
        Code = dto.Code;
        Mapping = new Dictionary<IdentityUser, string>();
        Mapping[user] = dto.Team;
        CurrentPick = 0;
        TimerDuration = dto.TimerDuration;
    } 
        public Room()
    {
        // No need to add any code here, it can remain empty
    }

            

    }





