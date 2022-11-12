using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralOngs.Models
{
    [Table("BankAccount")]
    public class BankAccountModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Numero da conta")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "Agência")]
        public int Branch { get; set; }

        [Required]
        [Display(Name = "Operação")]
        public int AccountType { get; set; }

        
        public virtual BankModel? Bank { get; set; }

        [Display(Name = "Instituição Bancária")]
        public int BankId { get; set; }

        public UserOngModel? UserOng { get; set; }
        public int UserOngId { get; set; }

    }
}

