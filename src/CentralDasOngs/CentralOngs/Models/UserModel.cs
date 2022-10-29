using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CentralOngs.Models
{
    public abstract class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário informar o nome!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "É necessário informar o nome!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email não é valido")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "É necessário informar o nome!")]
        public string Password { get; set; }

        //[DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "É necessário informar o contato!")]
        //[RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Numero de contato invalido!")]
        public string Contact { get; set; }
        public UserType UserType { get; set; }

        [Required]
        public AddressModel Address { get; set; }
    }
}

