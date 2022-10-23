using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralDasOngs.Models
{
    public abstract class Usuario 
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "É necessário informar o nome!")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "É necessário informar o nome!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email não é valido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "É necessário informar o nome!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Contato")]
        [Required(ErrorMessage = "É necessário informar o contato!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Numero de contato invalido!")]
        public string Contato { get; set; }

        public Tipo Tipo { get; set; }
    }
    public enum Tipo
    {
        Voluntario,
        Ong
    }
}

