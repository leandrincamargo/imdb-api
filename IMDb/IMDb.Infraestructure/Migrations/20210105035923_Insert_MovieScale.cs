using IMDb.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IMDb.Infraestructure.Migrations
{
    public partial class Insert_MovieScale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (MovieScale movieScale in Enum.GetValues(typeof(MovieScale)))
            {
                migrationBuilder
                    .Sql($"insert into dbo.MovieScale (Id, Name) values('{(byte)movieScale}', '{movieScale}')");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (MovieScale movieScale in Enum.GetValues(typeof(MovieScale)))
            {
                migrationBuilder
                    .Sql($"delete from dbo.MovieScale (Id, Name) values('{(byte)movieScale}', '{movieScale}')");
            }

        }
    }
}
