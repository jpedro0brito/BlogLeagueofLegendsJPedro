using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.ViewModel
{
    public class CategoriaViewModel
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        [Display(Name = "Nome da Categoria")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "Lista de categoria")]
        public IEnumerable<Posts> Posts { get; set; }
    }
}
