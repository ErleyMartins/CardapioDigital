using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigitalWebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bebidas",
                columns: table => new
                {
                    BEB_ID1 = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BEB_NOME1 = table.Column<string>(type: "TEXT", nullable: false),
                    BEB_DESC1 = table.Column<string>(type: "TEXT", nullable: true),
                    BEB_TIPO1 = table.Column<string>(type: "TEXT", nullable: false),
                    BEB_UM1 = table.Column<string>(type: "TEXT", nullable: false),
                    BEB_VALOR1 = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebidas", x => x.BEB_ID1);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PIZ_ID1 = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PIZ_NOME1 = table.Column<string>(type: "TEXT", nullable: false),
                    PIZ_DESC1 = table.Column<string>(type: "TEXT", nullable: false),
                    PIZ_MEDIA1 = table.Column<decimal>(type: "TEXT", nullable: false),
                    PIZ_GRANDE1 = table.Column<decimal>(type: "TEXT", nullable: false),
                    PIZ_TREM1 = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PIZ_ID1);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    USR_ID1 = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    USR_LOGIN1 = table.Column<string>(type: "TEXT", nullable: false),
                    USR_PASSWORD1 = table.Column<byte[]>(type: "BLOB", nullable: false),
                    USR_NAME1 = table.Column<string>(type: "TEXT", nullable: false),
                    USR_LOCKED1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.USR_ID1);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "USR_ID1", "USR_LOCKED1", "USR_LOGIN1", "USR_NAME1", "USR_PASSWORD1" },
                values: new object[] { 1, 0, "admin", "Administrador", new byte[] { 117, 184, 44, 12, 158, 182, 198, 193, 190, 180, 84, 208, 65, 23, 229, 95 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bebidas");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
