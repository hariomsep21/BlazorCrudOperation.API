
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCRUD.DTO.ModelDtos
{
   
    public class StudentsDto
    {



        public int Id { get; set; }

        [Required]
        public string? FullName { get; set; }


        [Required]
        [StringLength(20)]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string? UserEmail { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public int GenderId { get; set; }

        public int StateId { get; set; }

    }
}
