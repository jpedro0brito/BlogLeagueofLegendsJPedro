using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.DoMain.Interfaces;
using BlogJoaoPedroLeagueofLegends.DoMain.Services;
using BlogJoaoPedroLeagueofLegends.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.Infra.Services
{
    public class PostsServices : ServicesBase<Posts>, IPostsServices
    {
        private readonly IPostsRepository postsRepository;
        public PostsServices(IPostsRepository postsRepository) : base(postsRepository)
        {
            this.postsRepository = postsRepository;
        }
        public Task<Posts> BuscaPorId(int id)
        {
            return postsRepository.GetById(id);
        }

        public IEnumerable<Posts> BuscaPorTudo()
        {
            return postsRepository.GetByAll();
        }
    }
}
