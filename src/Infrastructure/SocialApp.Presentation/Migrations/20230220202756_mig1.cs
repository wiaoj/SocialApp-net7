using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "socialApp",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    profile_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Posts_Profiles_ProfileId1",
                        column: x => x.ProfileId1,
                        principalSchema: "socialApp",
                        principalTable: "Profiles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Posts_Profiles_profile_id",
                        column: x => x.profile_id,
                        principalSchema: "socialApp",
                        principalTable: "Profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_id",
                schema: "socialApp",
                table: "Posts",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_profile_id",
                schema: "socialApp",
                table: "Posts",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfileId1",
                schema: "socialApp",
                table: "Posts",
                column: "ProfileId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts",
                schema: "socialApp");
        }
    }
}
