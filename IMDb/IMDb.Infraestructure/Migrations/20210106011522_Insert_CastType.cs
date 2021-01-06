using IMDb.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IMDb.Infraestructure.Migrations
{
    public partial class Insert_CastType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (CastType castType in Enum.GetValues(typeof(CastType)))
            {
                migrationBuilder
                    .Sql($"insert into dbo.CastType (Id, Name) values('{(byte)castType}', '{castType}')");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (CastType castType in Enum.GetValues(typeof(CastType)))
            {
                migrationBuilder
                    .Sql($"delete from dbo.CastType (Id, Name) values('{(byte)castType}', '{castType}')");
            }
        }
    }
}
