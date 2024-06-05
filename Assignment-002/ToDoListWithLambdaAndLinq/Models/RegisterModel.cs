﻿using System.ComponentModel.DataAnnotations;

namespace ToDoListWithLambdaAndLinq.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }
    }
}
