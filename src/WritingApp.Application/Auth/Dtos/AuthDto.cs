﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingApp.Domain.Entities;

namespace WritingApp.Application.Auth.Dtos
{
    public class AuthDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string? Fullname { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }
        public string? Nationality { get; set; } = "";
        public string? Gender { get; set; } = "";
    }
}
