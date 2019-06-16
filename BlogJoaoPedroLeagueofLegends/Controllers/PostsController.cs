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

            var categoria = await categoriaServices.BuscaPorId(buscaPost.Categoria.CategoriaId);
            categoria.Posts.Where(p => p.PreviaTexto.Length > 200).ToList().ForEach(p => p.PreviaTexto = p.PreviaTexto.Substring(0, 200) + " ....");
            ViewBag.PostsCategoria = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostsViewModel>>(categoria.Posts);
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
        [HttpGet]
        public async Task<IActionResult> Alterar(int id)
        {
            var buscaPost = await postsServices.BuscaPorId(id);
            var mapPost = Mapper.Map<Posts, PostsViewModel>(buscaPost);
            var buscaCategoria = await categoriaServices.BuscaPorTudo();
            ViewBag.CategoriaList = new SelectList(buscaCategoria, "CategoriaId", "descricao", buscaPost.Categoria.CategoriaId);
            return View(mapPost);
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(Posts posts, int CategoriaList)
        {
            if (ModelState.IsValid)
            {
                posts.Categoria = await categoriaServices.BuscaPorId(Convert.ToInt32(CategoriaList));
                postsServices.Alterar(posts);
                return RedirectToAction(nameof(Listar));
            }
            return View(posts);
        }
        [HttpGet]
        public async Task<IActionResult> Excluir(int id)
        {
            var buscaPost = await postsServices.BuscaPorId(id);
            var mapPost = Mapper.Map<Posts, PostsViewModel>(buscaPost);
            var buscaCategoria = await categoriaServices.BuscaPorTudo();
            ViewBag.CategoriaList = new SelectList(buscaCategoria, "CategoriaId", "descricao", buscaPost.Categoria.CategoriaId);
            return View(mapPost);
        }
        [HttpPost]
        public IActionResult Excluir(Posts posts)
        {
            postsServices.Excluir(posts);
            return RedirectToAction(nameof(Listar));
        }
    }
}