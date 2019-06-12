using System;
using System.Collections.Generic;
using System.Text;

namespace BlogJoaoPedroLeagueofLegends.DoMain.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string descricao { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}
