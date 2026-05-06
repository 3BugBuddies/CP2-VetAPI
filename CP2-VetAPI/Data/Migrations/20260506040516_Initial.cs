using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP2_VetApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    id_pet = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_pet = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    raca_pet = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    idade_pet = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.id_pet);
                });

            migrationBuilder.CreateTable(
                name: "tb_tutor",
                columns: table => new
                {
                    id_tutor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_tutor = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    em_tutor = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    tl_tutor = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tutor", x => x.id_tutor);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "tb_tutor");
        }
    }
}
