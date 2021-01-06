using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDb.Infraestructure.Migrations
{
    public partial class Rename_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_CastType_CastTypeId",
                table: "Actor");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actor_CastId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movie_MovieId",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                table: "Actor");

            migrationBuilder.RenameTable(
                name: "ActorMovie",
                newName: "CastOfMovie");

            migrationBuilder.RenameTable(
                name: "Actor",
                newName: "Cast");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MovieId",
                table: "CastOfMovie",
                newName: "IX_CastOfMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_CastId",
                table: "CastOfMovie",
                newName: "IX_CastOfMovie_CastId");

            migrationBuilder.RenameIndex(
                name: "IX_Actor_CastTypeId",
                table: "Cast",
                newName: "IX_Cast_CastTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CastOfMovie",
                table: "CastOfMovie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cast",
                table: "Cast",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_CastType_CastTypeId",
                table: "Cast",
                column: "CastTypeId",
                principalTable: "CastType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CastOfMovie_Cast_CastId",
                table: "CastOfMovie",
                column: "CastId",
                principalTable: "Cast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CastOfMovie_Movie_MovieId",
                table: "CastOfMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_CastType_CastTypeId",
                table: "Cast");

            migrationBuilder.DropForeignKey(
                name: "FK_CastOfMovie_Cast_CastId",
                table: "CastOfMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CastOfMovie_Movie_MovieId",
                table: "CastOfMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CastOfMovie",
                table: "CastOfMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cast",
                table: "Cast");

            migrationBuilder.RenameTable(
                name: "CastOfMovie",
                newName: "ActorMovie");

            migrationBuilder.RenameTable(
                name: "Cast",
                newName: "Actor");

            migrationBuilder.RenameIndex(
                name: "IX_CastOfMovie_MovieId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CastOfMovie_CastId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_CastId");

            migrationBuilder.RenameIndex(
                name: "IX_Cast_CastTypeId",
                table: "Actor",
                newName: "IX_Actor_CastTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                table: "Actor",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movie_MovieId",
                table: "ActorMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
