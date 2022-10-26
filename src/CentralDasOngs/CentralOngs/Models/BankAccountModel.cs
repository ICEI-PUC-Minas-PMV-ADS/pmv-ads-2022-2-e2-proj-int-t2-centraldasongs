using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralOngs.Models
{
    [Table("bank_account")]
    public class BankAccountModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[Display(Name = "Numero da conta")]
        public string AccountNumber { get; set; }

        [Required]
        //[Display(Name = "Agência")]
        public int Branch { get; set; }

        [Required]
        //[Display(Name = "Operação")]
        public int AccountType { get; set; }

        //[Display(Name = "Banco")]
        [ForeignKey("BankId")]
        public virtual BankModel Bank { get; set; }

        [Required]
        [Display(Name = "Banco")]
        public int BankId { get; set; }

    }
}

