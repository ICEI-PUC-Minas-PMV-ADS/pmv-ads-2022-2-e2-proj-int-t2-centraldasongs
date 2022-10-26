using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralOngs.Models
{
    [Table("user_voluntario")]
    public class UserVoluntarioModel : UserModel
    {
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "É necessário informar o CPF!")]
        public long Cpf { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "É necessário informar a data de nascimento!")]
        public DateTime DateBirthDay { get; set; }


        [NotMapped]
        public int Idade { get => (int)Math.Floor((DateTime.Now - DateBirthDay).TotalDays / 365.25); }
    }
}

