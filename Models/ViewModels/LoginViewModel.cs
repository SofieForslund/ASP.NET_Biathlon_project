using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Lösenord")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Användarnamn")]
        public string Email { get; set; }
    }
}
