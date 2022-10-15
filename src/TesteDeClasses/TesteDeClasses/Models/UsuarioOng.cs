using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDeClasses.Models
{
    [Table("Usuarios_ong")]
    public class UsuarioOng : Usuario
    {
        [Key]
        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "É necessário informar o CNPJ!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^\d{2}\d{3}\d{3}\d{4}\d{2}$", ErrorMessage = "Numero de CNPJ invalido! Informar apenas numeros")]
        public string CnpjId { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

    }

}


