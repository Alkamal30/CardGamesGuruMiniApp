using AutoMapper;
using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.TotModels;

namespace Infrastructure.CardGamesGuruMiniApp.Profiles
{
    public class TotProfile : Profile
    {
        public TotProfile()
        {
            CreateMap<TotBson, TotCard>()
                .ForMember(
                    dest => dest.CardId,
                    opt => opt.MapFrom(src => $"{src.CardId}")
                )
                .ForMember(
                    dest => dest.FirstQuestion,
                    opt => opt.MapFrom(src => $"{src.FirstQuestion}")
                )
                .ForMember(
                    dest => dest.SecondQuestion,
                    opt => opt.MapFrom(src => $"{src.SecondQuestion}")
                )
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => $"{src.CreatedDate}")
                )
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => $"{src.UpdatedDate}")
                );

            CreateMap<TotCard, TotBson>()
                .ForMember(
                    dest => dest.CardId,
                    opt => opt.MapFrom(src => $"{src.CardId}")
                )
                .ForMember(
                    dest => dest.FirstQuestion,
                    opt => opt.MapFrom(src => $"{src.FirstQuestion}")
                )
                .ForMember(
                    dest => dest.SecondQuestion,
                    opt => opt.MapFrom(src => $"{src.SecondQuestion}")
                )
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(src => $"{src.CreatedDate}")
                )
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => $"{src.UpdatedDate}")
                );
        }
    }
}