using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Core5._0_Blog.Models
{
    public class UserSignUpViewModel
    {
        public IFormFile UserImage { get; set; }
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }

        //[Required(ErrorMessage ="Kayıt olabilmek için gizlilik sözleşmesini kabul etmeniz gerekiyor!")]
        public bool IsAcceptedTheContract { get; set; }
    }
}
