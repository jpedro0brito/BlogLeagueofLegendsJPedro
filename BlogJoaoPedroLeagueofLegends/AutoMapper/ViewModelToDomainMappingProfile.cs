using AutoMapper;
using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostsViewModel, Posts>();
                cfg.CreateMap<CategoriaViewModel, Categoria>();
            });
            config.CreateMapper();
        }
    }
}
