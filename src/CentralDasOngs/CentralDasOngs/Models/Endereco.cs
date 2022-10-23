using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CentralDasOngs.Models
{
    [Table("enderecos")]
    public class Endereco
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "É necessário informar o Logadouro!")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "É necessário informar o bairro!")]
        public string Bairro { get; set; }

        [Display(Name = "Numero")]
        [Required(ErrorMessage = "É necessário informar o numero do endereço!")]
        public int NumeroEndereco { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "É necessário informar a cidade!")]
        public string Cidade { get; set; }

        [ForeignKey("UsuarioVoluntarioCpf")]
        public UsuarioVoluntario UsuarioVoluntario { get; set; }
        public string UsuarioVoluntarioCpf { get; set; }

        [ForeignKey("UsuarioOngCnpj")]
        public UsuarioOng UsuarioOng { get; set; }
        public string UsuarioOngCnpj { get; set; }

        [ForeignKey("Uf")]
        public UnidadeFederativa UnidadeFederativa { get; set; } 
        public string Uf { get; set; }
        
    }
}
