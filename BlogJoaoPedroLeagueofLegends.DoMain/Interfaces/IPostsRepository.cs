using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.DoMain.Interfaces
{
    public interface IPostsRepository: IRepositoryBase<Posts>
    {
        Task<Posts> GetById(int id);
        IEnumerable<Posts> GetByAll();
    }
}
