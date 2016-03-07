using System;
using System.ComponentModel.DataAnnotations;

namespace LucyManager.MVC.Models
{
    public class Eventos
    {
        [Key]
        public int EventoId { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}