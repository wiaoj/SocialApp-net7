using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfileRelationships_followers_id",
                schema: "socialApp",
                table: "ProfileRelationships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileRelationships",
                schema: "socialApp",
                table: "ProfileRelationships",
                columns: new[] { "followers_id", "profile_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileRelationships",
                schema: "socialApp",
                table: "ProfileRelationships");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileRelationships_followers_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                column: "followers_id");
        }
    }
}
