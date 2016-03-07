using System;
using System.ComponentModel.DataAnnotations;

namespace LucyManager.MVC.Models
{
    public class Equipamentos
    {
        [Key]
        public int EquipamentoId { get; set; }

        [Required]
        [Display(Name = "Patrimônio")]
        public string Patrimonio { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data de aquisição")]
        public DateTime DataAquisicao { get; set; }

        [Required]
        [Display(Name = "Última manutenção")]
        public DateTime DataManutencao { get; set; }

        [Required]
        [Display(Name = "Data próxima manutenção")]
        public DateTime DataProximaManutencao { get; set; }

        [Required]
        [Display(Name = "Local de origem")]
        public Guid LocalOrigemId { get; set; }

        [Required]
        [Display(Name = "Reservado para")]
        public Guid LocalDestinoId { get; set; }
                
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}