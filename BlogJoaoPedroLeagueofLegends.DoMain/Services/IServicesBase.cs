using System;
using System.Collections.Generic;
using System.Text;

namespace BlogJoaoPedroLeagueofLegends.DoMain.Services
{
    public interface IServicesBase<TEntity> where TEntity: class
    {
        void Salvar(TEntity obj);
        void Alterar(TEntity obj);
        void Excluir(TEntity obj);
        void Dispose();
    }
}
