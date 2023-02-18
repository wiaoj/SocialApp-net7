using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
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

            migrationBuilder.RenameColumn(
                name: "followers_id",
                schema: "socialApp",
                table: "ProfileProfile",
                newName: "FollowersId");

            migrationBuilder.RenameColumn(
                name: "profile_id",
                schema: "socialApp",
                table: "ProfileProfile",
                newName: "FollowsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileProfile_profile_id",
                schema: "socialApp",
                table: "ProfileProfile",
                newName: "IX_ProfileProfile_FollowsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowersId",
                schema: "socialApp",
                table: "ProfileProfile",
                column: "FollowersId",
                principalSchema: "socialApp",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowsId",
                schema: "socialApp",
                table: "ProfileProfile",
                column: "FollowsId",
                principalSchema: "socialApp",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowersId",
                schema: "socialApp",
                table: "ProfileProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowsId",
                schema: "socialApp",
                table: "ProfileProfile");

            migrationBuilder.RenameColumn(
                name: "FollowersId",
                schema: "socialApp",
                table: "ProfileProfile",
                newName: "followers_id");

            migrationBuilder.RenameColumn(
                name: "FollowsId",
                schema: "socialApp",
                table: "ProfileProfile",
                newName: "profile_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileProfile_FollowsId",
                schema: "socialApp",
                table: "ProfileProfile",
                newName: "IX_ProfileProfile_profile_id");

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
