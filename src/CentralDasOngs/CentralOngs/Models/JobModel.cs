using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralOngs.Models
{
    [Table("Jobs")]
    public class JobModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "É necessario informar o nome")]
        public string Name { get; set; }

        [Display(Name = "Numero de vagas")]
        [Required(ErrorMessage = "É necessario informar o numero de vagas")]
        public int  NumberOfVacancies { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage ="É necessario adicionar uma descrição")]
        public string Description { get; set; }

        [Display(Name ="Tipo")]
        [Required(ErrorMessage ="É orbigatorio informar o tipo da vaga")]
        public JobType JobType { get; set; }

        public int UserOngId { get; set; }
        public UserOngModel? UserOng { get; set; }


    }
}
