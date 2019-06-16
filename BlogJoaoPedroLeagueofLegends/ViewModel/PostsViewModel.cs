using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogJoaoPedroLeagueofLegends.ViewModel
{
    public class PostsViewModel
    {
        [Key]
        public int PostId { get; set; }
        [Required(ErrorMessage = "Digite um Titulo Valido")]
        [Display(Name = "Titulo")]
        [Range(10, 100, ErrorMessage = "A Quatidade devera ser entre 10 e 100")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Digite um Sub Titulo")]
        [Display(Name = "Sub Titulo")]
        [Range(10, 100, ErrorMessage = "A Quatidade devera ser entre 10 e 100")]
        public string SubTitulo { get; set; }
        [Required(ErrorMessage = "Digite um texto.")]
        [Range(10, 500, ErrorMessage = "A Quatidade devera ser entre 10 e 500")]
        [Display(Name = "Digite uma Previa do Texto")]
        public string PreviaTexto { get; set; }
        [Required(ErrorMessage ="Digite um texto.")]
        [Display(Name = "Digite um Texto")]
        public string Post { get; set; }
        [Required(ErrorMessage = "Selecione um Imagem via URL")]
        [Display(Name = "Imagem do Icone do Post")]
        public string ImgPost { get; set; }
        [Required(ErrorMessage = "Selecione um Item")]
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
    }
}
