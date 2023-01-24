using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee_webApi.Migrations
{
    public partial class cityAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityMst",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateMstid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMst", x => x.id);
                    table.ForeignKey(
                        name: "FK_CityMst_StateMst_StateMstid",
                        column: x => x.StateMstid,
                        principalTable: "StateMst",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityMst_StateMstid",
                table: "CityMst",
                column: "StateMstid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityMst");
        }
    }
}
