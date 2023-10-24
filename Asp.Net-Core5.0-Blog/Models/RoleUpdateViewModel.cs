using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Core5._0_Blog.Models
{
    public class RoleUpdateViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public string name { get; set; }
    }
}
