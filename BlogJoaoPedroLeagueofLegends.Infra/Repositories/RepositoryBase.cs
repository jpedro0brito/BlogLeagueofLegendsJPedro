using BlogJoaoPedroLeagueofLegends.DoMain.Interfaces;
using BlogJoaoPedroLeagueofLegends.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogJoaoPedroLeagueofLegends.Infra.Repositories
{
    public class RepositoryBase<TEntity>: IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly BlogContext context;

        public RepositoryBase(BlogContext context)
        {
            this.context = context;
        }

        public void Delete(TEntity obj)
        {
            context.Set<TEntity>().Remove(obj);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Insert(TEntity obj)
        {
            context.Set<TEntity>().Add(obj);
        }

        public void Update(TEntity obj)
        {
            context.Set<TEntity>().Update(obj);
        }
    }
}
