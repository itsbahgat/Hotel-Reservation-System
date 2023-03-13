using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.username);
                });

            migrationBuilder.Sql("INSERT INTO Logins Values ('admin', 'admin')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.Sql("DELETE MyNewTable WHERE username= 'admin'");
        }
    }
}
