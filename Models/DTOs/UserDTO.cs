using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.Models.DTOs
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
    }
}
