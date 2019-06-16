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
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(BlogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Categoria>> GetByAll()
        {
            return await context.Categorias.Include(p => p.Posts).ToListAsync();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await context.Categorias.Include(p => p.Posts).FirstOrDefaultAsync(p => p.CategoriaId == id);
        }
    }
}
