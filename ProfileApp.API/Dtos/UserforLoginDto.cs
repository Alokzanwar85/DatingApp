using System.ComponentModel.DataAnnotations;

namespace ProfileApp.API.Dtos
{
    public class UserforLoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}