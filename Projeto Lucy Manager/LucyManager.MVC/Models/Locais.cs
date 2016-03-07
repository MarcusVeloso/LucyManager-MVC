using System.ComponentModel.DataAnnotations;

namespace LucyManager.MVC.Models
{
    public class Locais
    {        
        [Key]
        public int LocalId { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
                
        [Display(Name = "Nome abreviado")]
        public string NomeAbreviado { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}