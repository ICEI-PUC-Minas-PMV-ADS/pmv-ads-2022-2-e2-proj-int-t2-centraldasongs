using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TesteDeClasses.Models
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

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "É necessário informar o estado!")]
        public Estado Estado { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "É necessário informar a cidade!")]
        public string Cidade { get; set; }

        [Display(Name = "Logadouro")]
        [Required(ErrorMessage = "É necessário informar o Logadouro!")]
        public string Logadouro { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "É necessário informar o bairro!")]
        public string Bairro { get; set; }

        [Display(Name = "Numero")]
        [Required(ErrorMessage = "É necessário informar o numero do endereço!")]
        public int NumeroEndereco { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }
        public Tipo Tipo { get; set; }
        
    }
    public enum Tipo
    {
        Voluntario,
        Ong
    }
    public enum Estado
    {
        AC,
        AL,
        AP,
        AM,
        BA,
        CE,
        DF,
        ES,
        GO,
        MA,
        MT,
        MS,
        MG,
        PA,
        PB,
        PR,
        PE,
        PI,
        RJ,
        RN,
        RS,
        RO,
        RR,
        SC,
        SP,
        SE,
        TP
    }
}
