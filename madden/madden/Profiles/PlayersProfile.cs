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
            CreateMap<Team, TeamReadDto>();
 
            CreateMap<Room, RoomReadDto>();;

             CreateMap<RoomCreateDto, Room>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Mapping, opt => opt.MapFrom(src => src.Mapping));

        }


    }
}