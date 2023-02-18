using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileRelationships_Profiles_profile_id",
                schema: "socialApp",
                table: "ProfileRelationships");

            migrationBuilder.RenameColumn(
                name: "profile_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                newName: "follows_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileRelationships_profile_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                newName: "IX_ProfileRelationships_follows_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileRelationships_Profiles_follows_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                column: "follows_id",
                principalSchema: "socialApp",
                principalTable: "Profiles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileRelationships_Profiles_follows_id",
                schema: "socialApp",
                table: "ProfileRelationships");

            migrationBuilder.RenameColumn(
                name: "follows_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                newName: "profile_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileRelationships_follows_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                newName: "IX_ProfileRelationships_profile_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileRelationships_Profiles_profile_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                column: "profile_id",
                principalSchema: "socialApp",
                principalTable: "Profiles",
                principalColumn: "id");
        }
    }
}
