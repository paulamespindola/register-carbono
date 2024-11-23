using System.ComponentModel.DataAnnotations;

namespace register_caborno.Models.Dtos
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
