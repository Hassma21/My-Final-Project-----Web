using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonApp.Models
{
    public class Laboratuvar
    {
        [Key]
        public int LaboratuvarID { get; set; }

        public int SonucID { get; set; }

        public int HastaID { get; set; }

        public Sonuc Sonuc { get; set; }
        public Hasta Hasta { get; set; }
    }
}
