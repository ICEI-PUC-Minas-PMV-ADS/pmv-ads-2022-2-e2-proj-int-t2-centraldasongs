using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDasOngs.Models
{
    [Table("ufs")]
    public class UnidadeFederativa
    {
        [Key]
        [DataType("char(2)")]
        [Column("uf")]
        public string Uf { get; set; }

        public ICollection<Endereco> Id { get; set; }

    }
}
