using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDasOngs.Models
{
    [Table("banks")]
    public class BankModel
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }

        public ICollection<OngBankInformationModel> Id { get; set; }

    }
}
