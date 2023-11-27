using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Entities
{
    public class ToDo
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }

        public string tittle { get; set; }
        public string description { get; set; }
    }
}
