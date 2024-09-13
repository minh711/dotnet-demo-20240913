using AutoMapper;
using Demo13092024.Db.Models;
using Demo13092024.DTOs.PlayerInstrument;
using Demo13092024.DTOs.Players;

namespace Demo13092024.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreatePlayerRequest, Player>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nickname))
                .ForMember(dest => dest.Instruments, opt => opt.MapFrom(src => src.PlayerInstruments))
                .ForMember(dest => dest.JoinedDate, opt => opt.Ignore());

            CreateMap<CreatePlayerInstrumentRequest, PlayerInstrument>()
                 .ForMember(dest => dest.InstrumentTypeId, opt => opt.MapFrom(src => src.InstrumentTypeId))
                 .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.ModelName))
                 .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level));
        }
    }
}
