using System.ComponentModel.DataAnnotations;

namespace register_caborno.Models.Dtos
{
    public class UserUpdateDto
    {
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

    }
}
