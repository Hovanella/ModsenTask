#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace ModsenTask.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Roles",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

        migrationBuilder.CreateTable(
            "Speakers",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Speakers", x => x.Id); });

        migrationBuilder.CreateTable(
            "Users",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: false),
                Password = table.Column<string>("nvarchar(max)", nullable: false),
                RoleId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
                table.ForeignKey(
                    "FK_Users_Roles_RoleId",
                    x => x.RoleId,
                    "Roles",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "Events",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: false),
                Description = table.Column<string>("nvarchar(max)", nullable: false),
                OrganizerId = table.Column<Guid>("uniqueidentifier", nullable: false),
                SpeakerId = table.Column<Guid>("uniqueidentifier", nullable: false),
                Date = table.Column<DateTime>("datetime2", nullable: false),
                Location = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Events", x => x.Id);
                table.ForeignKey(
                    "FK_Events_Speakers_SpeakerId",
                    x => x.SpeakerId,
                    "Speakers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_Events_Users_OrganizerId",
                    x => x.OrganizerId,
                    "Users",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_Events_OrganizerId",
            "Events",
            "OrganizerId");

        migrationBuilder.CreateIndex(
            "IX_Events_SpeakerId",
            "Events",
            "SpeakerId");

        migrationBuilder.CreateIndex(
            "IX_Users_RoleId",
            "Users",
            "RoleId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "Events");

        migrationBuilder.DropTable(
            "Speakers");

        migrationBuilder.DropTable(
            "Users");

        migrationBuilder.DropTable(
            "Roles");
    }
}