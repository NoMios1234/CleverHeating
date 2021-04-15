using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleverHeating.ViewModels
{
    public class UserInfoViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string UserSurname { get; set; }


        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
