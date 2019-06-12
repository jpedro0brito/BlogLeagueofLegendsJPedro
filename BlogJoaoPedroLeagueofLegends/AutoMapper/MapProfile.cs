using AutoMapper;
using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Core
            CreateMap<Posts, PostsViewModel>().ReverseMap();
        }
    }
}
