using BlogJoaoPedroLeagueofLegends.DoMain.Interfaces;
using BlogJoaoPedroLeagueofLegends.DoMain.Services;
using BlogJoaoPedroLeagueofLegends.Infra.Context;
using BlogJoaoPedroLeagueofLegends.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogJoaoPedroLeagueofLegends.Infra.Services
{
    public class ServicesBase<TEntity>:IDisposable, IServicesBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> repositoryBase;
        public ServicesBase(IRepositoryBase<TEntity> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }

        public void Alterar(TEntity obj)
        {
            repositoryBase.Update(obj);
        }

        public void Dispose()
        {
            repositoryBase.Dispose();
        }

        public void Excluir(TEntity obj)
        {
            repositoryBase.Delete(obj);
        }

        public void Salvar(TEntity obj)
        {
            repositoryBase.Insert(obj);
        }
    }
}
