using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_webApi.Migrations
{
    public partial class addCascadingdropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryMst",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMst", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StateMst",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stateName = table.Column<int>(type: "int", nullable: false),
                    CountryMstid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMst", x => x.id);
                    table.ForeignKey(
                        name: "FK_StateMst_CountryMst_CountryMstid",
                        column: x => x.CountryMstid,
                        principalTable: "CountryMst",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StateMst_CountryMstid",
                table: "StateMst",
                column: "CountryMstid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateMst");

            migrationBuilder.DropTable(
                name: "CountryMst");
        }
    }
}
