using System.ComponentModel.DataAnnotations;

namespace academico.Models
{
    public class Projeto
    {
        [Key]
        public int ProjetoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [Display(Name = "Sigla")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "Sigla deve conter 2 letras maiúsculas.")]
        public string Sigla { get; set; } = string.Empty;

        [Required]
        [StringLength(4)]
        [Display(Name = "Ano")]
        public string Ano { get; set; } = DateTime.Now.Year.ToString();

        public enum Status
        {
            [Display(Name = "Em desenvolvimento")]
            EmDesenvolvimento = 1,

            [Display(Name = "Em condições de Defesa")]
            EmCondicoesDeDefesa = 2,

            [Display(Name = "Completo sem Implantar")]
            CompletoSemImplantar = 3,

            [Display(Name = "Implantado")]
            Implantado = 4
        }

        [Required]
        [Display(Name = "Status")]
        public Status StatusProjeto { get; set; } = Status.EmDesenvolvimento;
    }
}