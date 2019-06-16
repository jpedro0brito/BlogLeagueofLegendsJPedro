using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogJoaoPedroLeagueofLegends.Models;
using BlogJoaoPedroLeagueofLegends.DoMain.Services;
using AutoMapper;
using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.ViewModel;

namespace BlogJoaoPedroLeagueofLegends.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostsServices postsSevices;
        public HomeController(IPostsServices postsSevices)
        {
            this.postsSevices = postsSevices;
        }
        public IActionResult Index()
        {
            var posts = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostsViewModel>>(postsSevices.BuscaPorTudo());
            posts.Where(p => p.PreviaTexto.Length > 200).ToList().ForEach(p => p.PreviaTexto = p.PreviaTexto.Substring(0, 200) + " ....");
            return View(posts);
        }

        public IActionResult Contatos()
        {
            var posts = Mapper.Map<IEnumerable<Posts>, IEnumerable<PostsViewModel>>(postsSevices.BuscaPorTudo());
            posts.Where(p => p.PreviaTexto.Length > 200).ToList().ForEach(p => p.PreviaTexto = p.PreviaTexto.Substring(0, 200) + " ....");
            return View(posts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
