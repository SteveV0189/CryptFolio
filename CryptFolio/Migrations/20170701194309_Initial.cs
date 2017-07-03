using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CryptFolio.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CMC_Id = table.Column<string>(nullable: true),
                    Change_1Hr = table.Column<double>(nullable: true),
                    Change_24Hr = table.Column<double>(nullable: true),
                    Change_7D = table.Column<double>(nullable: true),
                    LastUpdated = table.Column<string>(nullable: true),
                    MarketCap = table.Column<double>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    ValueBTC = table.Column<double>(nullable: true),
                    ValueUSD = table.Column<double>(nullable: true),
                    Volume = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
