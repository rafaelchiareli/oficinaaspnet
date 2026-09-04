using System.ComponentModel.DataAnnotations;

namespace ClinicaASPNet.Models
{
    public class Profissional
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O Campo Nome é obrigatório")]
        [MaxLength(100, ErrorMessage ="O Campo não pode passar de 100 caracteres")]
        [MinLength(5, ErrorMessage = "O Campo deve ter no minimo 5 caracteres")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Informe o cpf com 11 dígitos")]
        public string CPF { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Campo DataNascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O Campo CRM é obrigatório")]
        public string CRM { get; set; } = string.Empty;
        [Required(ErrorMessage = "O Campo Sexo é obrigatório")]
        public string Sexo { get; set; } = string.Empty;


    }
}
