using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Assignment_19___MVC___shahd_mostafa.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="First Name is required")]
        [StringLength(50,ErrorMessage ="First Name must be less than 50 characters")]
        public string FirstName {  get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name must be less than 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50, ErrorMessage = "User Name must be less than 50 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="InvalidEmailAddress")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }
    }
}
