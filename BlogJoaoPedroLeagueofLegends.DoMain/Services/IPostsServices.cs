using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.DoMain.Services
{
    public interface IPostsServices: IServicesBase<Posts>
    {
        Task<Posts> BuscaPorId(int id);
        IEnumerable<Posts> BuscaPorTudo();
    }
}
