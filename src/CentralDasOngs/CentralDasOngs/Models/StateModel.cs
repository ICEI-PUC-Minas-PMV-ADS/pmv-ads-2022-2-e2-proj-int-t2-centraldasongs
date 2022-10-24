using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDasOngs.Models
{
    [Table("ufs")]
    public class StateModel
    {
        [Key]
        public string Uf { get; set; }

        public virtual IList<AdressModel> Id { get; set; }
    }
}
