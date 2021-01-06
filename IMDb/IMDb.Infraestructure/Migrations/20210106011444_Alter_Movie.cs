using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDb.Infraestructure.Migrations
{
    public partial class Alter_Movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actor_ActorId",
                table: "ActorMovie");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "ActorMovie",
                newName: "CastId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_ActorId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_CastId");

            migrationBuilder.AddColumn<byte>(
                name: "CastTypeId",
                table: "Actor",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "CastType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actor_CastTypeId",
                table: "Actor",
                column: "CastTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_CastType_CastTypeId",
                table: "Actor",
                column: "CastTypeId",
                principalTable: "CastType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actor_CastId",
                table: "ActorMovie",
                column: "CastId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_CastType_CastTypeId",
                table: "Actor");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actor_CastId",
                table: "ActorMovie");

            migrationBuilder.DropTable(
                name: "CastType");

            migrationBuilder.DropIndex(
                name: "IX_Actor_CastTypeId",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "CastTypeId",
                table: "Actor");

            migrationBuilder.RenameColumn(
                name: "CastId",
                table: "ActorMovie",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_CastId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_ActorId");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actor_ActorId",
                table: "ActorMovie",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
