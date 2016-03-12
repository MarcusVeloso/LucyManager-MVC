using System;
using System.ComponentModel.DataAnnotations;

namespace LucyManager.MVC.Models
{
    public class Reservas
    {
        [Key]
        public int ReservaId { get; set; }

        [Required]
        [Display(Name = "Data e hora inicial")]
        public DateTime DataInicialReserva { get; set; }

        [Required]
        [Display(Name = "Data e hora final")]
        public DateTime DataFinalReserva { get; set; }

        [Required]
        [Display(Name = "Local")]
        public int LocalId { get; set; }

        [Required]
        [Display(Name = "Solicitante")]
        public Guid UserId { get; set; }

        [Required]
        [Display(Name = "Evento")]
        public int EventoId { get; set; }

        public virtual Locais Local { get; set; }
        public virtual Eventos Evento { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}