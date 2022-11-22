using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralOngs.Models
{
    [Table("Vacancies")]
    public class VacancyModel
    {
        [Key]
        [Required]
        public int Id { get; set;}

        [Display(Name = "Escreva um pouco sobre você")]
        public string? UserVoluntarioAbout { get; set; }

        public virtual JobModel Job { get; set; }
        public virtual UserVoluntarioModel UserVoluntario { get; set; }
        public int JobId { get; set; }
        public int UserVoluntarioId{ get; set; }
    }
}
