using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektHotele.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }
    }

    public class UserMetadata
    {
        [Display(Name = "Imię")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wymagane")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wymagane")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wymagane")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Display(Name = "Data Urodzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Hasło")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Wymagane")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 znakow")]
        public string Password { get; set; }

        [Display(Name = "Potwierdz hasło")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "hasła się nie zgadzają")]
        public string ConfirmPassword { get; set; }

    }
}