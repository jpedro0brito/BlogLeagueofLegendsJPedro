using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.DoMain.Interfaces
{
    public interface ICategoriaRepository: IRepositoryBase<Categoria>
    {
        Task<Categoria> GetById(int id);
        Task<IEnumerable<Categoria>> GetByAll();
    }
}
