using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneOtomasyonApp.Migrations
{
    public partial class bir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birim",
                columns: table => new
                {
                    BirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdı = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birim", x => x.BirimID);
                });

            migrationBuilder.CreateTable(
                name: "Doktor",
                columns: table => new
                {
                    DoktorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorTamAdı = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobilNO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TCNO = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktor", x => x.DoktorID);
                });

            migrationBuilder.CreateTable(
                name: "Hasta",
                columns: table => new
                {
                    HastaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaTamAdı = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobilNO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TCNO = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hasta", x => x.HastaID);
                });

            migrationBuilder.CreateTable(
                name: "ÖdemeTipi",
                columns: table => new
                {
                    ÖdemeTipiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÖdemeTipiAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ÖdemeTipi", x => x.ÖdemeTipiID);
                });

            migrationBuilder.CreateTable(
                name: "Sonuc",
                columns: table => new
                {
                    SonucID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SonucAd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sonuc", x => x.SonucID);
                });

            migrationBuilder.CreateTable(
                name: "Muayene",
                columns: table => new
                {
                    MuayeneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimID = table.Column<int>(type: "int", nullable: false),
                    HastaID = table.Column<int>(type: "int", nullable: false),
                    DoktorID = table.Column<int>(type: "int", nullable: false),
                    HastaGeçmişi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HastaTeşhis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HastaTedavi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Yazılanİlaçlar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ÖdemeTipiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muayene", x => x.MuayeneID);
                    table.ForeignKey(
                        name: "FK_Muayene_Birim_BirimID",
                        column: x => x.BirimID,
                        principalTable: "Birim",
                        principalColumn: "BirimID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Muayene_Doktor_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktor",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Muayene_Hasta_HastaID",
                        column: x => x.HastaID,
                        principalTable: "Hasta",
                        principalColumn: "HastaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Muayene_ÖdemeTipi_ÖdemeTipiID",
                        column: x => x.ÖdemeTipiID,
                        principalTable: "ÖdemeTipi",
                        principalColumn: "ÖdemeTipiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laboratuvar",
                columns: table => new
                {
                    LaboratuvarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SonucID = table.Column<int>(type: "int", nullable: false),
                    HastaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratuvar", x => x.LaboratuvarID);
                    table.ForeignKey(
                        name: "FK_Laboratuvar_Hasta_HastaID",
                        column: x => x.HastaID,
                        principalTable: "Hasta",
                        principalColumn: "HastaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Laboratuvar_Sonuc_SonucID",
                        column: x => x.SonucID,
                        principalTable: "Sonuc",
                        principalColumn: "SonucID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Birim",
                columns: new[] { "BirimID", "BirimAdı" },
                values: new object[,]
                {
                    { 1, "Acil Servis" },
                    { 2, "Ağız ve Diş Sağlığı" },
                    { 3, "Beslenme Ve Diyatetik" },
                    { 4, "Nöroşirurji" },
                    { 5, "Çocuk Sağlığı ve Hastalıkları" },
                    { 6, "Dahiliye" },
                    { 7, "Dermatoloji" },
                    { 8, "Estetik ve Plastik Cerrahi" },
                    { 9, "Fizik Tedavi ve Rehabilitasyon" },
                    { 10, "Genel Cerrahi" },
                    { 11, "Göğüs Hastaıkları" },
                    { 12, "Kadın Hastalıkları ve Doğum" },
                    { 13, "Kulak Burun Boğaz Hastalıkları" },
                    { 14, "Kalp ve Damar Cerrahisi" },
                    { 15, "Ortopedi" }
                });

            migrationBuilder.InsertData(
                table: "Doktor",
                columns: new[] { "DoktorID", "DoktorTamAdı", "MobilNO", "TCNO" },
                values: new object[,]
                {
                    { 1, "Emre Tümer", "0000000000", "11111111111" },
                    { 2, "Levent Atahanlı", "0000000000", "11111111111" },
                    { 3, "Suat Birtan", "0000000000", "11111111111" },
                    { 4, "Ela Altındağ", "0000000000", "11111111111" },
                    { 5, "Zeynep Öztürk", "0000000000", "11111111111" },
                    { 6, "Haldun Göksun", "0000000000", "11111111111" },
                    { 7, "Julide Aydın", "0000000000", "11111111111" }
                });

            migrationBuilder.InsertData(
                table: "Hasta",
                columns: new[] { "HastaID", "HastaTamAdı", "MobilNO", "TCNO" },
                values: new object[,]
                {
                    { 1, "Muhammed Yılmaz", "0000000000", "11111111111" },
                    { 2, "Selda Bağcan", "0000000000", "11111111111" },
                    { 3, "Batuhan Çelik", "0000000000", "11111111111" },
                    { 4, "Dursun Atagün", "0000000000", "11111111111" },
                    { 5, "Koray Avcı", "0000000000", "11111111111" },
                    { 6, "Musa Eroğlu", "0000000000", "11111111111" }
                });

            migrationBuilder.InsertData(
                table: "ÖdemeTipi",
                columns: new[] { "ÖdemeTipiID", "ÖdemeTipiAdı" },
                values: new object[,]
                {
                    { 1, "Peşin Ödeme" },
                    { 2, "Kredi Kartı İle" },
                    { 3, "SGK" },
                    { 4, "Özel Sigorta" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laboratuvar_HastaID",
                table: "Laboratuvar",
                column: "HastaID");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratuvar_SonucID",
                table: "Laboratuvar",
                column: "SonucID");

            migrationBuilder.CreateIndex(
                name: "IX_Muayene_BirimID",
                table: "Muayene",
                column: "BirimID");

            migrationBuilder.CreateIndex(
                name: "IX_Muayene_DoktorID",
                table: "Muayene",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Muayene_HastaID",
                table: "Muayene",
                column: "HastaID");

            migrationBuilder.CreateIndex(
                name: "IX_Muayene_ÖdemeTipiID",
                table: "Muayene",
                column: "ÖdemeTipiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laboratuvar");

            migrationBuilder.DropTable(
                name: "Muayene");

            migrationBuilder.DropTable(
                name: "Sonuc");

            migrationBuilder.DropTable(
                name: "Birim");

            migrationBuilder.DropTable(
                name: "Doktor");

            migrationBuilder.DropTable(
                name: "Hasta");

            migrationBuilder.DropTable(
                name: "ÖdemeTipi");
        }
    }
}
