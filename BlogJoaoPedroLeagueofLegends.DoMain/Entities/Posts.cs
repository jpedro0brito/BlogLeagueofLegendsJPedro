using System;
using System.Collections.Generic;
using System.Text;

namespace BlogJoaoPedroLeagueofLegends.DoMain.Entities
{
    public class Posts
    {
        public int PostId { get; set; }
        public string Post { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string PreviaTexto { get; set; }
        public string ImgPost { get; set; }
        public Categoria Categoria { get; set; }
    }
}
