using HastaneOtomasyonApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyonApp.Data
{
    public class HastaneOtomasyonDBContext : DbContext
    {
        public HastaneOtomasyonDBContext(DbContextOptions<HastaneOtomasyonDBContext> options) : base(options) { }

        public DbSet<Hasta> Hasta { get; set; }

        public DbSet<Birim> Birim { get; set; }

        public DbSet<Doktor> Doktor { get; set; }

        public DbSet<ÖdemeTipi> ÖdemeTipi { get; set; }

        public DbSet<Muayene> Muayene { get; set; }

        public DbSet<Sonuc> Sonuc { get; set; }

        public DbSet<Laboratuvar> Laboratuvar { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Birim>().HasData(
                                               new Birim { BirimID = 1, BirimAdı = "Acil Servis" },
                                               new Birim { BirimID = 2, BirimAdı = "Ağız ve Diş Sağlığı" },
                                               new Birim { BirimID = 3, BirimAdı = "Beslenme Ve Diyatetik" },
                                               new Birim { BirimID = 4, BirimAdı = "Nöroşirurji" },
                                               new Birim { BirimID = 5, BirimAdı = "Çocuk Sağlığı ve Hastalıkları" },
                                               new Birim { BirimID = 6, BirimAdı = "Dahiliye" },
                                               new Birim { BirimID = 7, BirimAdı = "Dermatoloji" },
                                               new Birim { BirimID = 8, BirimAdı = "Estetik ve Plastik Cerrahi" },
                                               new Birim { BirimID = 9, BirimAdı = "Fizik Tedavi ve Rehabilitasyon" },
                                               new Birim { BirimID = 10, BirimAdı = "Genel Cerrahi" },
                                               new Birim { BirimID = 11, BirimAdı = "Göğüs Hastaıkları" },
                                               new Birim { BirimID = 12, BirimAdı = "Kadın Hastalıkları ve Doğum" },
                                               new Birim { BirimID = 13, BirimAdı = "Kulak Burun Boğaz Hastalıkları" },
                                               new Birim { BirimID = 14, BirimAdı = "Kalp ve Damar Cerrahisi" },
                                               new Birim { BirimID = 15, BirimAdı = "Ortopedi" }
                                              );
            modelBuilder.Entity<ÖdemeTipi>().HasData(
                                              new ÖdemeTipi { ÖdemeTipiID = 1, ÖdemeTipiAdı = "Peşin Ödeme" },
                                              new ÖdemeTipi { ÖdemeTipiID = 2, ÖdemeTipiAdı = "Kredi Kartı İle" },
                                              new ÖdemeTipi { ÖdemeTipiID = 3, ÖdemeTipiAdı = "SGK" },
                                              new ÖdemeTipi { ÖdemeTipiID = 4, ÖdemeTipiAdı = "Özel Sigorta" }
                                             );

            modelBuilder.Entity<Doktor>().HasData(
                                    new Doktor { DoktorID = 1, DoktorTamAdı = "Emre Tümer", MobilNO = "0000000000", TCNO = "11111111111"},
                                    new Doktor { DoktorID = 2, DoktorTamAdı = "Levent Atahanlı",  MobilNO = "0000000000", TCNO = "11111111111" },
                                    new Doktor { DoktorID = 3, DoktorTamAdı = "Suat Birtan", MobilNO = "0000000000", TCNO = "11111111111"},
                                    new Doktor { DoktorID = 4, DoktorTamAdı = "Ela Altındağ", MobilNO = "0000000000", TCNO = "11111111111" },
                                    new Doktor { DoktorID = 5, DoktorTamAdı = "Zeynep Öztürk", MobilNO = "0000000000", TCNO = "11111111111" },
                                    new Doktor { DoktorID = 6, DoktorTamAdı = "Haldun Göksun", MobilNO = "0000000000", TCNO = "11111111111" },
                                    new Doktor { DoktorID = 7, DoktorTamAdı = "Julide Aydın", MobilNO = "0000000000", TCNO = "11111111111"}
                                   );

            modelBuilder.Entity<Hasta>().HasData(
                                    new Hasta { HastaID = 1, HastaTamAdı = "Muhammed Yılmaz", MobilNO = "0000000000", TCNO = "11111111111"},
                                    new Hasta { HastaID = 2, HastaTamAdı = "Selda Bağcan",  MobilNO = "0000000000", TCNO = "11111111111" },
                                    new Hasta { HastaID = 3, HastaTamAdı = "Batuhan Çelik", MobilNO = "0000000000", TCNO = "11111111111"},
                                    new Hasta { HastaID = 4, HastaTamAdı = "Dursun Atagün",  MobilNO = "0000000000", TCNO = "11111111111"},
                                    new Hasta { HastaID = 5, HastaTamAdı = "Koray Avcı", MobilNO = "0000000000", TCNO = "11111111111"},
                                    new Hasta { HastaID = 6, HastaTamAdı = "Musa Eroğlu", MobilNO = "0000000000", TCNO = "11111111111"}
                                   );
        }
    }
}
