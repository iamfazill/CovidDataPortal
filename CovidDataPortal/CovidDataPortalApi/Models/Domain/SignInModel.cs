﻿using System.ComponentModel.DataAnnotations;

namespace CovidDataPortalApi.Models.Domain
{
    public class SignInModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
