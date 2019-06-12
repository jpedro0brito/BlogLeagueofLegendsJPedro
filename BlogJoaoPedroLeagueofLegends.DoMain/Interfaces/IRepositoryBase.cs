using System;
using System.Collections.Generic;
using System.Text;

namespace BlogJoaoPedroLeagueofLegends.DoMain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity: class 
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);

        void Dispose();
    }
}
