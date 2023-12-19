using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FPT_BOOKSHOP.Models.DTO
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [StringLength(30)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
    }
}