using System.ComponentModel.DataAnnotations;

namespace WebApplicationDolgozat.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Firstname { get; set; } 

        [Required]
        public string Lastname { get; set; } 

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
