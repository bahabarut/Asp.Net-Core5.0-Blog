using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Core5._0_Blog.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin!")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Girin!")]
        public string password { get; set; }
    }
}
