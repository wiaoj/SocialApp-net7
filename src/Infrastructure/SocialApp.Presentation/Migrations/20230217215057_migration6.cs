using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_Profiles_followers_id",
                schema: "socialApp",
                table: "ProfileProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_Profiles_profile_id",
                schema: "socialApp",
                table: "ProfileProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileProfile",
                schema: "socialApp",
                table: "ProfileProfile");

            migrationBuilder.RenameTable(
                name: "ProfileProfile",
                schema: "socialApp",
                newName: "ProfileRelationships",
                newSchema: "socialApp");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileProfile_profile_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                newName: "IX_ProfileRelationships_profile_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileRelationships",
                schema: "socialApp",
                table: "ProfileRelationships",
                columns: new[] { "followers_id", "profile_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileRelationships_Profiles_followers_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                column: "followers_id",
                principalSchema: "socialApp",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileRelationships_Profiles_profile_id",
                schema: "socialApp",
                table: "ProfileRelationships",
                column: "profile_id",
                principalSchema: "socialApp",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileRelationships_Profiles_followers_id",
                schema: "socialApp",
                table: "ProfileRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileRelationships_Profiles_profile_id",
                schema: "socialApp",
                table: "ProfileRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileRelationships",
                schema: "socialApp",
                table: "ProfileRelationships");

            migrationBuilder.RenameTable(
                name: "ProfileRelationships",
                schema: "socialApp",
                newName: "ProfileProfile",
                newSchema: "socialApp");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileRelationships_profile_id",
                schema: "socialApp",
                table: "ProfileProfile",
                newName: "IX_ProfileProfile_profile_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileProfile",
                schema: "socialApp",
                table: "ProfileProfile",
                columns: new[] { "followers_id", "profile_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_Profiles_followers_id",
                schema: "socialApp",
                table: "ProfileProfile",
                column: "followers_id",
                principalSchema: "socialApp",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_Profiles_profile_id",
                schema: "socialApp",
                table: "ProfileProfile",
                column: "profile_id",
                principalSchema: "socialApp",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
