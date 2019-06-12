using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.DoMain.Services;
using BlogJoaoPedroLeagueofLegends.Infra.Services;
using BlogJoaoPedroLeagueofLegends.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogJoaoPedroLeagueofLegends.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsServices postsServices;
        private readonly ICategoriaServices categoriaServices;

        public PostsController(IPostsServices postsServices, ICategoriaServices categoriaServices)
        {
            this.postsServices = postsServices;
            this.categoriaServices = categoriaServices;
        }
        public async Task<IActionResult> Post(int id)
        {
            var buscaPost = await postsServices.BuscaPorId(id);
            var post = Mapper.Map<Posts, PostsViewModel>(buscaPost);

            ViewBag.CategoriaList = await categoriaServices.BuscaPorId(buscaPost.Categoria.CategoriaId);
            return View(post);
        }

        public IActionResult Listar()
        {
            var posts = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostsViewModel>>(postsServices.BuscaPorTudo());
            return View(posts);
        }
        public async Task<IActionResult> Novo()
        {
            var buscaCategoria = await categoriaServices.BuscaPorTudo();
            ViewBag.CategoriaList = new SelectList(buscaCategoria, "CategoriaId", "descricao");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Novo(Posts posts,int CategoriaList)
        {
            if (ModelState.IsValid)
            {
                var item = ViewBag.CategoriaList;
                posts.Categoria = await categoriaServices.BuscaPorId(Convert.ToInt32(CategoriaList));
                postsServices.Salvar(posts);
                return RedirectToAction("Listar");
            }
            else
                return View(posts);
        }
    }
}