using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralOngs.Models
{
    [Table("Address")]
    public class AddressModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário informar a cidade!")]
        public string City { get; set; }

        [Required(ErrorMessage = "É necessário informar o bairro!")]
        public string District { get; set; }

        [Required(ErrorMessage = "É necessário informar o Logadouro!")]
        public string Street { get; set; }

        [Required(ErrorMessage = "É necessário informar o numero do endereço!")]
        public int Number { get; set; }

        public string Complement { get; set; }

        public UserModel? User { get; set; }
        public int UserId { get; set; }

        public virtual StateModel? State { get; set; }
        public string StateName { get; set; }
    }
}

