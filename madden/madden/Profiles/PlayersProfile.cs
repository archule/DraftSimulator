using AutoMapper;
using madden.Dtos;
using madden.Models;

namespace madden.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerReadDto>();

        }
    }
}