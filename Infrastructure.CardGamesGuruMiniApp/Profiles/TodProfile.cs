using AutoMapper;
using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.TodModels;

namespace Infrastructure.CardGamesGuruMiniApp.Profiles
{
    public class TodProfile : Profile
    {
        public TodProfile()
        {
            CreateMap<TodBson, TodCard>();
            CreateMap<TodCard, TodBson>();
        }
    }
}