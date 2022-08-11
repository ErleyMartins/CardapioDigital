using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigital.Data.Migrations
{
    public partial class correcaoCategoriaPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BORDA",
                columns: table => new
                {
                    BORDA_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BORDA_NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BORDA", x => x.BORDA_ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIA_BEBIDA",
                columns: table => new
                {
                    CAT_BEB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAT_BEB_DESCRICAO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA_BEBIDA", x => x.CAT_BEB_ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIA_PIZZA",
                columns: table => new
                {
                    CAT_PIZ_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAT_PIZ_DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA_PIZZA", x => x.CAT_PIZ_ID);
                });

            migrationBuilder.CreateTable(
                name: "TAMANHO",
                columns: table => new
                {
                    TAM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAM_DESCRICAO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAMANHO", x => x.TAM_ID);
                });

            migrationBuilder.CreateTable(
                name: "TIPO",
                columns: table => new
                {
                    TIPO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPO_DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO", x => x.TIPO_ID);
                });

            migrationBuilder.CreateTable(
                name: "BEBIDAS",
                columns: table => new
                {
                    BEB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BEB_NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BEB_DESCRICAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CAT_BEB_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEBIDAS", x => x.BEB_ID);
                    table.ForeignKey(
                        name: "FK_BEBIDAS_CATEGORIA_BEBIDA_CAT_BEB_ID",
                        column: x => x.CAT_BEB_ID,
                        principalTable: "CATEGORIA_BEBIDA",
                        principalColumn: "CAT_BEB_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PIZZA",
                columns: table => new
                {
                    PIZ_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAT_PIZ_ID = table.Column<int>(type: "int", nullable: false),
                    TIPO_ID = table.Column<int>(type: "int", nullable: false),
                    PIZ_NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PIZ_DESCRICAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIZZA", x => x.PIZ_ID);
                    table.ForeignKey(
                        name: "FK_PIZZA_CATEGORIA_PIZZA_CAT_PIZ_ID",
                        column: x => x.CAT_PIZ_ID,
                        principalTable: "CATEGORIA_PIZZA",
                        principalColumn: "CAT_PIZ_ID");
                    table.ForeignKey(
                        name: "FK_PIZZA_TIPO_TIPO_ID",
                        column: x => x.TIPO_ID,
                        principalTable: "TIPO",
                        principalColumn: "TIPO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRECO_PIZZA",
                columns: table => new
                {
                    PRECO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRECO_VALOR = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TAM_ID = table.Column<int>(type: "int", nullable: false),
                    PIZZA_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRECO_PIZZA", x => x.PRECO_ID);
                    table.ForeignKey(
                        name: "FK_PRECO_PIZZA_PIZZA_PIZZA_ID",
                        column: x => x.PIZZA_ID,
                        principalTable: "PIZZA",
                        principalColumn: "PIZ_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRECO_PIZZA_TAMANHO_TAM_ID",
                        column: x => x.TAM_ID,
                        principalTable: "TAMANHO",
                        principalColumn: "TAM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TAMANHO_PIZZA",
                columns: table => new
                {
                    PIZ_ID = table.Column<int>(type: "int", nullable: false),
                    TAM_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAMANHO_PIZZA", x => new { x.PIZ_ID, x.TAM_ID });
                    table.ForeignKey(
                        name: "FK_TAMANHO_PIZZA_PIZZA_PIZ_ID",
                        column: x => x.PIZ_ID,
                        principalTable: "PIZZA",
                        principalColumn: "PIZ_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAMANHO_PIZZA_TAMANHO_TAM_ID",
                        column: x => x.TAM_ID,
                        principalTable: "TAMANHO",
                        principalColumn: "TAM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BEBIDAS_CAT_BEB_ID",
                table: "BEBIDAS",
                column: "CAT_BEB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PIZZA_CAT_PIZ_ID",
                table: "PIZZA",
                column: "CAT_PIZ_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PIZZA_TIPO_ID",
                table: "PIZZA",
                column: "TIPO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRECO_PIZZA_PIZZA_ID",
                table: "PRECO_PIZZA",
                column: "PIZZA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRECO_PIZZA_TAM_ID",
                table: "PRECO_PIZZA",
                column: "TAM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TAMANHO_PIZZA_TAM_ID",
                table: "TAMANHO_PIZZA",
                column: "TAM_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BEBIDAS");

            migrationBuilder.DropTable(
                name: "BORDA");

            migrationBuilder.DropTable(
                name: "PRECO_PIZZA");

            migrationBuilder.DropTable(
                name: "TAMANHO_PIZZA");

            migrationBuilder.DropTable(
                name: "CATEGORIA_BEBIDA");

            migrationBuilder.DropTable(
                name: "PIZZA");

            migrationBuilder.DropTable(
                name: "TAMANHO");

            migrationBuilder.DropTable(
                name: "CATEGORIA_PIZZA");

            migrationBuilder.DropTable(
                name: "TIPO");
        }
    }
}
