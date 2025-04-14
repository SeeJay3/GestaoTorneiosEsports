using System.ComponentModel.DataAnnotations;

namespace GestaoTorneiosEsports.Models
{
    public class EstatisticaTorneioViewModel
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

        [Display(Name = "Pontuação Máxima")]
        public int PontuacaoMaxima { get; set; }

        [Display(Name = "Pontuação Mínima")]
        public int PontuacaoMinima { get; set; }

        [Display(Name = "Prêmio Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PremioTotal { get; set; }
    }
}