using System.ComponentModel.DataAnnotations;

namespace register_caborno.Models.Dtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string ConfirmPassword { get; set; } 


    }
}
