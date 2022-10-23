using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDasOngs.Models
{
    [Table("bancos")]
    public class Banco
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public ICollection<DadoBancario> Id { get; set; }
    }
}
