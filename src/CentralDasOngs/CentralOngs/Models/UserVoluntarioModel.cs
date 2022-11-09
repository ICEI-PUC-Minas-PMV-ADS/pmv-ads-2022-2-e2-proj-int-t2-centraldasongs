using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralOngs.Models
{
    [Table("UserVoluntario")]
    public class UserVoluntarioModel : UserModel
    {
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "É necessário informar o CPF!")]
        [RegularExpression(@"^\d{3}\d{3}\d{3}\d{2}$", ErrorMessage = "Numero de cpf invalido! Informar apenas numeros")]
        public long Cpf { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "É necessário informar a data de nascimento!")]
        public DateTime DateBirthDay { get; set; }

        [Display(Name = "Idade")]
        [NotMapped]
        public int Age { get => (int)Math.Floor((DateTime.Now - DateBirthDay).TotalDays / 365.25); }
    }
}

