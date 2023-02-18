using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Profiles_ProfileId",
                schema: "socialApp",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfileId",
                schema: "socialApp",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                schema: "socialApp",
                table: "Profiles");

            migrationBuilder.CreateTable(
                name: "ProfileProfile",
                schema: "socialApp",
                columns: table => new
                {
                    followers_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    profile_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileProfile", x => new { x.followers_id, x.profile_id });
                    table.ForeignKey(
                        name: "FK_ProfileProfile_Profiles_followers_id",
                        column: x => x.followers_id,
                        principalSchema: "socialApp",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileProfile_Profiles_profile_id",
                        column: x => x.profile_id,
                        principalSchema: "socialApp",
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileProfile_profile_id",
                schema: "socialApp",
                table: "ProfileProfile",
                column: "profile_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileProfile",
                schema: "socialApp");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                schema: "socialApp",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileId",
                schema: "socialApp",
                table: "Profiles",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Profiles_ProfileId",
                schema: "socialApp",
                table: "Profiles",
                column: "ProfileId",
                principalSchema: "socialApp",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
