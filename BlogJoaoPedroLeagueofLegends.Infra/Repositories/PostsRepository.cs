using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.DoMain.Interfaces;
using BlogJoaoPedroLeagueofLegends.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.Infra.Repositories
{
    public class PostsRepository : RepositoryBase<Posts>, IPostsRepository
    {
        public PostsRepository(BlogContext context) : base(context)
        {
        }
        public IEnumerable<Posts> GetByAll()
        {
            return context.Posts.Include(p => p.Categoria);
        }

        public async Task<Posts> GetById(int id)
        {
            return await context.Posts.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.PostId == id);
        }
    }
}
