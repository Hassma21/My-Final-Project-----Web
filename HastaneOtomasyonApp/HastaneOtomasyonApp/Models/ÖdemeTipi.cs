using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonApp.Models
{
    public class ÖdemeTipi
    {
        [Key]
        public int ÖdemeTipiID { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Ödeme Tipi "), StringLength(30, MinimumLength = 1, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string ÖdemeTipiAdı { get; set; }
    }
}
