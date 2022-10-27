using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDasOngs.Models
{
    [Table("UFs")]
    public class StateModel
    {
        [Key]
        public string UF { get; set; }
        public virtual IList<AddressModel> Address { get; set; }
    }
}
