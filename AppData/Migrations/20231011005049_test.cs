using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Gia = table.Column<int>(type: "int", nullable: false),
                    SLTon = table.Column<int>(type: "int", nullable: false),
                    NSX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThuongHieu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.MaSP);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sanPhams");
        }
    }
}
