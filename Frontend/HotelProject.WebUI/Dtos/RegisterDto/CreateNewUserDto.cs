using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Ad Alanı Gereklidir.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Soyad Alanı Gereklidir.")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Şehir Alanı Gereklidir.")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Ülke Alanı Gereklidir.")]
        public string? Country { get; set; }
        [Required(ErrorMessage = "Cinsiyet Alanı Gereklidir.")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Alanı Gereklidir.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Mail Alanı Gereklidir.")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Gereklidir.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar Alanı Gereklidir.")]
        [Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor.")]
        public string? ConfirmPassword { get; set; }
    }
}
