using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace register_caborno.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string TypeUser { get; set; }
        [JsonIgnore]
        public ICollection<Activity> Activities { get; set; }  // Relacionamento inverso

        public string Role { get; set; } = "User"; 

    }
}
