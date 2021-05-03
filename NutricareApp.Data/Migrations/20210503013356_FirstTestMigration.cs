using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutricareApp.Data.Migrations
{
    public partial class FirstTestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    password = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "nutritionist",
                columns: table => new
                {
                    nutritionist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    password = table.Column<string>(type: "char(60)", unicode: false, maxLength: 60, nullable: false),
                    firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cnp_number = table.Column<int>(type: "int", unicode: false, maxLength: 6, nullable: false),
                    created_at = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritionist", x => x.nutritionist_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "nutritionist");
        }
    }
}
