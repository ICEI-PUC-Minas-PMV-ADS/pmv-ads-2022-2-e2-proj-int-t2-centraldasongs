using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralOngs.Models
{
    [Table("UFs")]
    public class StateModel
    {
        [Key]
        public string Name { get; set; }
        public virtual IList<AddressModel> Address { get; set; }
    }
}