using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiathlonSuccess.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Password", ErrorMessage = "Lösenorden matchar inte varandra.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Remote ("IbuIdTaken", "Account", HttpMethod ="Post", ErrorMessage ="Valt IbuId är inte giltigt!")]
        [Display(Name = "Skriv in ditt IBU Id")]
        public string ChosenAthleteIbuID { get; set; }

        public RegisterViewModel()
        {

        }
    }
}
