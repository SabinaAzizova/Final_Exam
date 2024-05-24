using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilet_12.Models
{
    public class Portfolio
    {

        public int Id { get; set; }
        [StringLength(100)]
        public  string  Name { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string? PhotoUrl { get; set; }

        [NotMapped]
        public IFormFile ImgFile { get; set; }
        public string ImgUrl { get; internal set; }
    }
}
