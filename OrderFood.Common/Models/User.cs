﻿using OrderFood.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.Common.Models
{
    public class User : BaseModel
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        public string FullName { get; set; }


        public string Username { get; set; } 

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Avatar { get; set; }

        public Gender? Gender { get; set; } = Enums.Gender.Male;

        [NotMapped]
        public string? token { get; set; }

        [ForeignKey("Role")]
        public Guid? RoleId { get; set; }

        public Role Role { get; set; }

    }
}
