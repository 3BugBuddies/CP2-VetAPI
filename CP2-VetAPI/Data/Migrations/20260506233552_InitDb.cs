using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP2_VetApi.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PET",
                columns: table => new
                {
                    id_pet = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    rc_raca = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    es_especie = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    i_idade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PET", x => x.id_pet);
                });

            migrationBuilder.CreateTable(
                name: "TB_TUTOR",
                columns: table => new
                {
                    id_tutor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    em_email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    tl_telefone = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TUTOR", x => x.id_tutor);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PET");

            migrationBuilder.DropTable(
                name: "TB_TUTOR");
        }
    }
}
