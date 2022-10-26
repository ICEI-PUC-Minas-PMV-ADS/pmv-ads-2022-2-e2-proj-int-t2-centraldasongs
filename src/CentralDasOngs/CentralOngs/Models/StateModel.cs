using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralOngs.Models
{
    [Table("UFs")]
    public class StateModel
    {
        [Key]
        public string Id { get; set; }

        public string UF { get; set; }
    }
}