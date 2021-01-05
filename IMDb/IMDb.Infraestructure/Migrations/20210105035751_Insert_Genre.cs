using IMDb.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IMDb.Infraestructure.Migrations
{
    public partial class Insert_Genre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (Genre genre in Enum.GetValues(typeof(Genre)))
            {
                migrationBuilder
                    .Sql($"insert into dbo.Genre (Id, Name) values('{(byte)genre}', '{genre}')");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (Genre genre in Enum.GetValues(typeof(Genre)))
            {
                migrationBuilder
                    .Sql($"delete from dbo.Genre (Id, Name) values('{(byte)genre}', '{genre}')");
            }
        }
    }
}
