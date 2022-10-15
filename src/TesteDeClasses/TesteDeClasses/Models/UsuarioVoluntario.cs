using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDeClasses.Models
{
    [Table("Usuarios_voluntarios")]
    public class UsuarioVoluntario : Usuario
    {
        [Key]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "É necessário informar o CPF!")]
        [RegularExpression(@"^\d{3}\d{3}\d{3}\d{2}$", ErrorMessage = "Numero de CPF invalido! Informar apenas numeros")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CpfId { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "É necessário informar a data de nascimento!")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; } 

        [NotMapped]
        public int Idade
        {
            get => (int)Math.Floor((DateTime.Now - DataNascimento).TotalDays / 365.25);
        }
    }
}


