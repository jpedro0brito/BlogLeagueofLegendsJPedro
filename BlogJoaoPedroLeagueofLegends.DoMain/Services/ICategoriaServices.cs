using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.DoMain.Services
{
    public interface ICategoriaServices: IServicesBase<Categoria>
    {
        Task<Categoria> BuscaPorId(int id);
        Task<IEnumerable<Categoria>> BuscaPorTudo();
    }

}
