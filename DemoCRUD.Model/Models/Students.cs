﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCRUD.Model.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? Phone { get; set; }

        // Foreign keys
        public int GenderId { get; set; }
        public int StateId { get; set; }

        // Navigation properties
        public Gender Gender { get; set; }
        public State State { get; set; }
    }
}
