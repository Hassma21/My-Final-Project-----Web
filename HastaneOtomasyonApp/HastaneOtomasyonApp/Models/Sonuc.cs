using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonApp.Models
{
    public class Sonuc
    {
        [Key]
        public int SonucID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Sonuç"), StringLength(10, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string SonucAd { get; set; }
    }
}
