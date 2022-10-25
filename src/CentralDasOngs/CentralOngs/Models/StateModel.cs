using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralOngs.Models
{
    [Table("ufs")]
    public class StateModel
    {
        [Key]
        public string Uf { get; set; }

        public virtual IList<AddressModel> Id { get; set; }
    }
}

