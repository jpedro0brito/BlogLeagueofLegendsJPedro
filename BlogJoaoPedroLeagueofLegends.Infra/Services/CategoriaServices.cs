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
    public class CategoriaServices : ServicesBase<Categoria>, ICategoriaServices
    {
        private readonly ICategoriaRepository categoriaRepository;
        public CategoriaServices(ICategoriaRepository categoriaRepository) : base(categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public Task<Categoria> BuscaPorId(int id)
        {
            return categoriaRepository.GetById(id);
        }

        public Task<IEnumerable<Categoria>> BuscaPorTudo()
        {
            return categoriaRepository.GetByAll();
        }
    }
}
