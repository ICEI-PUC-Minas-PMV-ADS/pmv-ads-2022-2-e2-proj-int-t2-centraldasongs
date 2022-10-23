using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace CentralDasOngs.Models
{
    [Table("UsuariosVoluntarios")]
    public class UsuarioVoluntario : Usuario
    {
        [Key]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "É necessário informar o CPF!")]
        [RegularExpression(@"^\d{3}\d{3}\d{3}\d{2}$", ErrorMessage = "numero de cpf invalido! informar apenas numeros")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Cpf_Id { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "É necessário informar a data de nascimento!")]
        public DateTime DataNascimento { get; set; } = DateTime.Now;

        [NotMapped]
        public int Idade
        {
            get => (int)Math.Floor((DateTime.Now - DataNascimento).TotalDays / 365.25);
        }
    }
}
