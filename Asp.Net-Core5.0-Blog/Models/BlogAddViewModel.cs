using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Core5._0_Blog.Models
{
    public class BlogAddViewModel
    {
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        [MinLength(5, ErrorMessage = "5 Karakterden Fazla Giriş Yapınız!")]
        [MaxLength(50, ErrorMessage = "50 Karakterden Az Giriş Yapınız!")]
        public string title { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        public int catId { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        [MinLength(20, ErrorMessage = "Lütfen 20 Karakterden Fazla Giriş Yapınız!\"")]
        public string content { get; set; }

        public IFormFile imageFile { get; set; }
    }
}
