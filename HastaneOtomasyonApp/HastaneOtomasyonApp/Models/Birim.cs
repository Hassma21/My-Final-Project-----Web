using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonApp.Models
{
    public class Birim
    {
        [Key]
        public int BirimID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Birim Adı")
            , StringLength(100, MinimumLength = 1, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string BirimAdı { get; set; }
    }
}
