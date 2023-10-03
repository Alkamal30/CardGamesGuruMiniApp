using AutoMapper;
using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;

namespace Infrastructure.CardGamesGuruMiniApp.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameBson, Game>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.NameIndex,
                    opt => opt.MapFrom(src => $"{src.NameIndex}")
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}")
                )
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => $"{src.CreatedDate}")
                )
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => $"{src.UpdatedDate}")
                )
                .ForMember(
                    dest => dest.Endpoint,
                    opt => opt.MapFrom(src => $"{src.Endpoint}")
                )
                .ForMember(
                    dest => dest.GameType,
                    opt => opt.MapFrom(src => $"{src.GameType}")
                );

            CreateMap<Game, GameBson>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.NameIndex,
                    opt => opt.MapFrom(src => $"{src.NameIndex}")
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => $"{src.Description}")
                )
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => $"{src.CreatedDate}")
                )
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => $"{src.UpdatedDate}")
                )
                .ForMember(
                    dest => dest.Endpoint,
                    opt => opt.MapFrom(src => $"{src.Endpoint}")
                )
                .ForMember(
                    dest => dest.GameType,
                    opt => opt.MapFrom(src => $"{src.GameType}")
                );
        }
    }
}