using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Core5._0_Blog.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen Rol Adı Giriniz!")]
        public string name { get; set; }
    }
}
