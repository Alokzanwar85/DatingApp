using System.ComponentModel.DataAnnotations;

namespace ProfileApp.API.Dtos
{
    public class UserforRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(5,MinimumLength=1,ErrorMessage="Please Provide Password")]
        public string Password { get; set; }
    }
}