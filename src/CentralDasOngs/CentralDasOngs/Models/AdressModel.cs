using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralDasOngs.Models
{
    [Table("adress")]
    public class AdressModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("State")]
        public StateModel StateModel { get; set; }
        public string State { get; set; }

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
        public int HouseNumber { get; set; }
        
        [Display(Name = "Complemento")]
        public string Complement { get; set; }

        [ForeignKey("UserVoluntarioId")]
        public UserVoluntarioModel UserVoluntarioModel { get; set; }
        public long? UserVoluntarioId { get; set; }

        [ForeignKey("UserOngId")]
        public UserOngModel UserOngModel { get; set; }
        public long? UserOngId { get; set; }

    }
}
