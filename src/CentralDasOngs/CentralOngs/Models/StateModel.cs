using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralOngs.Models
{
    [Table("UF")]
    public class StateModel
    {
        [Key]
        public string UF { get; set; }
    }
}