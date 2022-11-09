using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralOngs.Models
{
    [Table("Banks")]
    public class BankModel
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }

        public virtual IList<BankAccountModel> BankAccount { get; set; }
    }
}

