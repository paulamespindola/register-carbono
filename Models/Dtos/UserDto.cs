using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace register_caborno.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User";
        public List<ActivityDto> Activities { get; set; }

    }
}
