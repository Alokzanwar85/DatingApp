using System.ComponentModel.DataAnnotations;

namespace ProfileApp.API.Dtos
{
    public class UserforRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        
        
    }
}