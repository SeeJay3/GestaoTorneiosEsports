using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace GestaoTorneiosEsports.Models
{
    public class Torneio
    {
        [Key]
        public int TorneioId { get; set; }

        [Required(ErrorMessage = "O nome do torneio é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome do Torneio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O jogo é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome do jogo deve ter no máximo 50 caracteres")]
        [Display(Name = "Jogo")]
        public string Jogo { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de término é obrigatória")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Término")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O valor do prêmio é obrigatório")]
        [DataType(DataType.Currency)]
        [Display(Name = "Prêmio Total")]
        public decimal PremioTotal { get; set; }

        [StringLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        

        // Relacionamento: Um torneio tem várias equipes
       
        [ValidateNever]
        public virtual ICollection<Equipe> Equipes { get; set; }

    }
}