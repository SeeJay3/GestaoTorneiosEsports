using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoTorneiosEsports.Models
{
    public class EquipeTorneioViewModel
    {
        public int EquipeId { get; set; }

        [Display(Name = "Equipe")]
        public string EquipeNome { get; set; }

        [Display(Name = "Tag")]
        public string EquipeTag { get; set; }

        [Display(Name = "Torneio")]
        public string TorneioNome { get; set; }

        [Display(Name = "Jogo")]
        public string Jogo { get; set; }

        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Pontuação")]
        public int Pontuacao { get; set; }
    }
}