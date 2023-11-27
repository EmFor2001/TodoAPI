using System.ComponentModel.DataAnnotations;

namespace TodoAPI.DTO
{
    public class ToDoUpdateDto
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
    }
}
