﻿using OrderFood.Common.Enums;
using OrderFood.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFood.Common.DTOs.Auth
{
    public class UserDto
    {

        
        public Guid UserId { get; set; }
        public string FullName { get; set; }


        public string Username { get; set; }


        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Avatar { get; set; }

        public Gender? Gender { get; set; }

        public string? token { get; set; }

    }
}
