using OrderFood.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderFood.Common.DTOs
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "FullName không được để trống.")]
        public string FullName { get; set; } = "";


        [Required(ErrorMessage = "Username không được để trống.")]
        public string Username { get; set; } = "";


        [Required(ErrorMessage = "Password không được để trống.")]
        public string PasswordHash { get; set; } = "";


        [Required(ErrorMessage = "Email không được để trống.")] 
        public string Email { get; set; } = "";

        [Phone(ErrorMessage = "PhoneNumber không đúng định dạng.")]
        public string PhoneNumber { get; set; } = "";

        public string? Address { get; set; }

        public Gender? Gender { get; set; }
    }
}
