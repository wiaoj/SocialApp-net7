using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    FollowersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileProfile", x => new { x.FollowersId, x.FollowsId });
                    table.ForeignKey(
                        name: "FK_ProfileProfile_Profiles_FollowersId",
                        column: x => x.FollowersId,
                        principalSchema: "socialApp",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileProfile_Profiles_FollowsId",
                        column: x => x.FollowsId,
                        principalSchema: "socialApp",
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileProfile_FollowsId",
                schema: "socialApp",
                table: "ProfileProfile",
                column: "FollowsId");
        }
    }
}
