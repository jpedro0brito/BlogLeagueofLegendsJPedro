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
                    buscaPost.Posts.Where(p => p.PreviaTexto.Length > 200).ToList().ForEach(p => p.PreviaTexto = p.PreviaTexto.Substring(0, 200) + " ....");
                    var post = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostsViewModel>>(buscaPost.Posts);
                    ViewBag.PostList = post;
                }
            }
            else
            {
                var buscaPost = await categoriaServices.BuscaPorId(Convert.ToInt32(id));
                buscaPost.Posts.Where(p => p.PreviaTexto.Length > 200).ToList().ForEach(p => p.PreviaTexto = p.PreviaTexto.Substring(0, 200) + " ....");
                var post = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostsViewModel>>(buscaPost.Posts);

                ViewBag.PostList = post;
            }
            return View(categotiaTRUE);
        }
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var categoria = await categoriaServices.BuscaPorTudo();
            var categoriaView = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(categoria);
            return View(categoriaView);
        }
        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Novo(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaServices.Salvar(categoria);
                return RedirectToAction(nameof(Listar));
            }
            else
                return View(categoria);
        }
        [HttpGet]
        public async Task<IActionResult> Alterar(int id)
        {
            var categoria = await categoriaServices.BuscaPorId(id);
            var categoriaView = Mapper.Map<Categoria, CategoriaViewModel>(categoria);
            return View(categoriaView);
        }
        [HttpPost]
        public IActionResult Alterar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaServices.Alterar(categoria);
                return RedirectToAction(nameof(Listar));
            }
            return View(categoria);
        }
        [HttpGet]
        public async Task<IActionResult> Excluir(int id)
        {
            var categoria = await categoriaServices.BuscaPorId(id);
            var categoriaView = Mapper.Map<Categoria, CategoriaViewModel>(categoria);
            return View(categoriaView);
        }
        [HttpPost]
        public IActionResult Excluir(Categoria categoria)
        {
            categoriaServices.Excluir(categoria);
            return RedirectToAction(nameof(Listar));
        }
    }
}