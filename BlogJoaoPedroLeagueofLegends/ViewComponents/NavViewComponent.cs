using AutoMapper;
using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.DoMain.Services;
using BlogJoaoPedroLeagueofLegends.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.ViewComponents
{
    public class NavViewComponent : ViewComponent
    {
        private readonly ICategoriaServices categoriaServices;
        public NavViewComponent(ICategoriaServices categoriaServices)
        {
            this.categoriaServices = categoriaServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mapCategoria = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(await categoriaServices.BuscaPorTudo());
            return View(mapCategoria);
        }
    }
}
