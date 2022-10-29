using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralDasOngs.Models
{
    [Table("Address")]
    public class AddressModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "É necessário informar a cidade!")]
        public string City { get; set; }
        
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "É necessário informar o bairro!")]
        public string District { get; set; }
        
        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "É necessário informar o Logadouro!")]
        public string Street { get; set; }
        
        [Display(Name = "Numero")]
        [Required(ErrorMessage = "É necessário informar o numero do endereço!")]
        public int Number { get; set; }
        
        [Display(Name = "Complemento")]
        public string Complement { get; set; }

        public UserModel User { get; set; }
        public int UserId { get; set; }

        public virtual StateModel State { get; set; }
        [Display(Name ="Estado")]
        public string StateId { get; set; }
    }
}
