using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralDasOngs.Models
{
    [Table("DadosBancarios")]
    public class DadoBancario
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Numero da conta")] 
        public string NumeroConta { get; set; }
        
        [Required]
        [Display(Name = "Agência")]
        public int Agencia { get; set; }

        [Required]
        [Display(Name = "Operação")] 
        public int Operacao { get; set; }
        
        [ForeignKey("Codigo")]
        [Display(Name = "Banco")]
        public Banco Banco { get; set; }
        [Required]
        [Display(Name = "Banco")]
        public int Codigo { get; set; }


        [ForeignKey("UsuarioOngCnpj")]
        public UsuarioOng UsuarioOng { get; set; }
        public string UsuarioOngCnpj { get; set; }
    }
}
