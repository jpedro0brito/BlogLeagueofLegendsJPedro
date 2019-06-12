using AutoMapper;
using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Posts, PostsViewModel>();
                cfg.CreateMap<Categoria, CategoriaViewModel>();
            });
            config.CreateMapper();
        }
    }
}
