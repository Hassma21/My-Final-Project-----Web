using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonApp.Models
{
    public class Muayene
    {
        [Key]
        public int MuayeneID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Birim adı"), Range(1, 100, ErrorMessage = "{0} seçilmeli.")]
        public int BirimID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Hasta adı"), Range(1, 100, ErrorMessage = "{0} seçilmeli.")]
        public int HastaID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Doktor adı"), Range(1, 100, ErrorMessage = "{0} seçilmeli.")]
        public int DoktorID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Hasta Geçmişi"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string HastaGeçmişi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Hasta Teşhisi"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string HastaTeşhis { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Hasta Tedavisi"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string HastaTedavi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Yazılan ilaçlar"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string Yazılanİlaçlar { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Ödeme tipi"), Range(1, 100, ErrorMessage = "{0} seçilmeli.")]
        public int ÖdemeTipiID { get; set; }



        public Birim Birim { get; set; }

        public Hasta Hasta { get; set; }

        public Doktor Doktor { get; set; }

        public ÖdemeTipi ÖdemeTipi { get; set; }
    }
}
