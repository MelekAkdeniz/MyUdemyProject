using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Setting
{
    public class UserEditViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$",
         ErrorMessage = "Şifre en az 6 karakter olmalı, 1 büyük harf, 1 küçük harf ve 1 rakam içermelidir.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string? ConfirmPassword { get; set; }
    }
}
