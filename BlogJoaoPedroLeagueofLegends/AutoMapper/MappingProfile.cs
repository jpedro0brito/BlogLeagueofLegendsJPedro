using AutoMapper;
using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Posts, PostsViewModel>();
            CreateMap<PostsViewModel, Posts>();
        }
    }
}
