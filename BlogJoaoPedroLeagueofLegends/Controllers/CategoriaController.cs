using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.DoMain.Services;
using BlogJoaoPedroLeagueofLegends.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BlogJoaoPedroLeagueofLegends.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaServices categoriaServices;
        private readonly IPostsServices postsServices;
        public CategoriaController(ICategoriaServices categoriaServices, IPostsServices postsServices)
        {
            this.categoriaServices = categoriaServices;
            this.postsServices = postsServices;
        }
        public async Task<IActionResult> Categorias(int? id)
        {
            var categorias = await categoriaServices.BuscaPorTudo();
            var categotiaTRUE = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(categorias);
            if (id == null)
            {
                var buscaPost = categorias.FirstOrDefault();
                if (buscaPost != null)
                {
                    var post = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostsViewModel>>(buscaPost.Posts);
                    ViewBag.PostList = post;
                }
            }
            else
            {
                var buscaPost = await categoriaServices.BuscaPorId(Convert.ToInt32(id));
                var post = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostsViewModel>>(buscaPost.Posts);

                ViewBag.PostList = post;
            }
            return View(categotiaTRUE);
        }
    }
}