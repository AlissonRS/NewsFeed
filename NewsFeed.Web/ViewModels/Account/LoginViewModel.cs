﻿using System.ComponentModel.DataAnnotations;

namespace NewsFeed.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
