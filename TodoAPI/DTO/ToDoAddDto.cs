
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.DTO
{
    public class ToDoAddDto
    {
        [Required]
        public string tittle { get; set; }
        [Required]
        public string description { get; set; }

    }
}
