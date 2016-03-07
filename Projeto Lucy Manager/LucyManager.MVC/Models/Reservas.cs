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
        public Guid LocalId { get; set; }

        [Required]
        [Display(Name = "Solicitante")]
        public Guid UserId { get; set; }

        [Required]
        [Display(Name = "Evento")]
        public Guid EventoId { get; set; }
    }
}