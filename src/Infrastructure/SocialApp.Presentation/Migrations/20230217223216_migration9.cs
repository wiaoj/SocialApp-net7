using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "socialApp",
                table: "Profiles",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_Id",
                schema: "socialApp",
                table: "Profiles",
                newName: "IX_Profiles_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                schema: "socialApp",
                table: "Profiles",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_id",
                schema: "socialApp",
                table: "Profiles",
                newName: "IX_Profiles_Id");
        }
    }
}
