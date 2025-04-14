using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoTorneiosEsports.Models
{
    public class Equipe
    {
        [Key]
        public int EquipeId { get; set; }

        [Required(ErrorMessage = "O nome da equipe é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome da Equipe")]
        public string Nome { get; set; }

        [StringLength(3, ErrorMessage = "A tag deve ter no máximo 3 caracteres")]
        [Display(Name = "Tag")]
        public string Tag { get; set; }

        [Required(ErrorMessage = "O número de jogadores é obrigatório")]
        [Range(1, 10, ErrorMessage = "O número de jogadores deve estar entre 1 e 10")]
        [Display(Name = "Número de Jogadores")]
        public int NumeroJogadores { get; set; }

        [StringLength(100, ErrorMessage = "O país deve ter no máximo 100 caracteres")]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Range(0, 100, ErrorMessage = "A pontuação deve estar entre 0 e 100")]
        [Display(Name = "Pontuação")]
        public int Pontuacao { get; set; }

        // Relacionamento: Uma equipe pertence a um torneio
        [ForeignKey("Torneio")]
        [Display(Name = "Torneio")]
        public int? TorneioId { get; set; }

        [Display(Name = "Torneio")]
        public Torneio? Torneio { get; set; }

    }
}