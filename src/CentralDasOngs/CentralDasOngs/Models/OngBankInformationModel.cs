using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDasOngs.Models
{
    [Table("ong_bank_information")]
    public class OngBankInformationModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Numero da conta")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "Agência")]
        public int Agency { get; set; }

        [Required]
        [Display(Name = "Operação")]
        public int AccountType { get; set; }

        [ForeignKey("BankId")]
        [Display(Name = "Banco")]
        public BankModel Bank { get; set; }
        
        [Required]
        [Display(Name = "Banco")]
        public int BankId { get; set; }


        [ForeignKey("UserOngId")]
        public UserOngModel UserOng { get; set; }
        public long UserOngId { get; set; }

    }
}
