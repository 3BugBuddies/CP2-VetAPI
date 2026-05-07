using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP2_VetApi.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseLengthPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tl_telefone",
                table: "TB_TUTOR",
                type: "NVARCHAR2(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(11)",
                oldMaxLength: 11);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tl_telefone",
                table: "TB_TUTOR",
                type: "NVARCHAR2(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(20)",
                oldMaxLength: 20);
        }
    }
}
