using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessOrderService.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessOrderLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderFrom = table.Column<string>(nullable: true),
                    OrderName = table.Column<string>(nullable: true),
                    OderDetails = table.Column<string>(nullable: true),
                    OrderQuantity = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessOrderLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessOrderLogs");
        }
    }
}
