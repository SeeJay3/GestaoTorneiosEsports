using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoTorneiosEsports.Models
{
    public class TorneioFiltradoViewModel
    {
        public int TorneioId { get; set; }

        [Display(Name = "Torneio")]
        public string TorneioNome { get; set; }

        [Display(Name = "Jogo")]
        public string Jogo { get; set; }

        [Display(Name = "Equipes")]
        public int QuantidadeEquipes { get; set; }

        [Display(Name = "Pontuação Média")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double PontuacaoMedia { get; set; }

        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de Término")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Display(Name = "Prêmio Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PremioTotal { get; set; }
    }
}