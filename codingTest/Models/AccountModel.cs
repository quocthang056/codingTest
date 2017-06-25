using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codingTest.Models
{
    public class DateValidation : ValidationAttribute
    {
        public DateValidation() : base(){}
        public override bool IsValid(object value)
        {
            return false;
        }
    }
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please enter first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter email.")]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Email is invalid.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Date Of Birth")]
        [DateValidation(ErrorMessage = "Please enter birth date.")]
        public DateTime? BirthDate { get; set; }
    }
}