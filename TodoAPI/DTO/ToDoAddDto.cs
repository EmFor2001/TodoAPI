﻿
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.DTO
{
    public class ToDoAddDto
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }

    }
}
