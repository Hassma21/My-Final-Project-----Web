using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonApp.Models
{
    public class Hasta
    {
        [Key]
        public int HastaID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Adı ve soyadı"), StringLength(50, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string HastaTamAdı { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Mobil No"), StringLength(10, MinimumLength = 10, ErrorMessage = "{0} {1} karakter olmalı.")]
        public string MobilNO { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Tc Kimlik No"), StringLength(11, MinimumLength = 11, ErrorMessage = "{0} {1} karakter olmalı.")]
        public string TCNO { get; set; }
    }
}
