using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVeterinario.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoAzureSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_VETERINARIO_CRM_VETERINARIO",
                table: "TB_VETERINARIO");

            migrationBuilder.DropIndex(
                name: "IX_TB_VETERINARIO_EMAIL_VETERINARIO",
                table: "TB_VETERINARIO");

            migrationBuilder.AlterColumn<string>(
                name: "TELEFONE_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "STATUS_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "ATIVO",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOME_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ESPECIALIDADE_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CRM_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,0)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "ID_TUTOR",
                table: "TB_TUTOR",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,0)",
                oldPrecision: 10)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PESO_PET",
                table: "TB_PET",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "ID_TUTOR",
                table: "TB_PET",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,0)",
                oldPrecision: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "ID_PET",
                table: "TB_PET",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,0)",
                oldPrecision: 10)
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TELEFONE_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "STATUS_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "ATIVO");

            migrationBuilder.AlterColumn<string>(
                name: "NOME_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "ESPECIALIDADE_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CRM_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "ID_VETERINARIO",
                table: "TB_VETERINARIO",
                type: "decimal(10,0)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID_TUTOR",
                table: "TB_TUTOR",
                type: "decimal(10,0)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PESO_PET",
                table: "TB_PET",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID_TUTOR",
                table: "TB_PET",
                type: "decimal(10,0)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID_PET",
                table: "TB_PET",
                type: "decimal(10,0)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VETERINARIO_CRM_VETERINARIO",
                table: "TB_VETERINARIO",
                column: "CRM_VETERINARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_VETERINARIO_EMAIL_VETERINARIO",
                table: "TB_VETERINARIO",
                column: "EMAIL_VETERINARIO",
                unique: true,
                filter: "[EMAIL_VETERINARIO] IS NOT NULL");
        }
    }
}
