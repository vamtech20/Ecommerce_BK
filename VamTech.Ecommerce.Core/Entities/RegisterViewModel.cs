using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VamTech.Ecommerce.Core.Entities
{
    public class RegisterViewModel
    {

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string MobilePhone { get; set; }

         public decimal? Document { get; set; }


        [StringLength(50, MinimumLength = 5)]
        public string HomePhone { get; set; }

    }
}
