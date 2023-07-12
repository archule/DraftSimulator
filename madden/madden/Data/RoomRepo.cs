using System.Collections.Generic;
using madden.Models;
using madden.Dtos;
using madden.Services;
using Microsoft.AspNetCore.Identity;

namespace madden.Data
{
    public class RoomRepo 
    {
        private readonly PlayerDbContext _context;

        public RoomRepo(PlayerDbContext context)
        {
            _context = context;
        }

        public void CreateRoom(RoomCreateDto RoomDto, IdentityUser User)
        {
            Room newRoom = new Room(RoomDto, User);

            _context.Rooms.Add(newRoom);
            _context.SaveChanges();


        }
    

        

        public IEnumerable<Room> GetAllRooms()
        
        {

            var players = _context.Rooms.ToList();


            return players;
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}