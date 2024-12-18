using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Categoria_CategoriId",
                table: "Tarea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameColumn(
                name: "CategoriId",
                table: "Tarea",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarea_CategoriId",
                table: "Tarea",
                newName: "IX_Tarea_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Categoria",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "CategoriaId");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "CategoriID", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("429e610a-0a26-4790-9de3-58be1f6c0802"), new Guid("00000000-0000-0000-0000-000000000000"), null, "Actividades Personales", 50 },
                    { new Guid("429e610a-0a26-4790-9de3-58be1f6c0828"), new Guid("00000000-0000-0000-0000-000000000000"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "Autor", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("429e610a-0a26-4790-9de3-58be1f6c0844"), "Maycol", new Guid("429e610a-0a26-4790-9de3-58be1f6c0802"), null, new DateTime(2024, 12, 18, 14, 19, 51, 594, DateTimeKind.Local).AddTicks(1900), 2, "Salir con amigos" },
                    { new Guid("429e610a-0a26-4790-9de3-58be1f6c08b7"), "Maycol", new Guid("429e610a-0a26-4790-9de3-58be1f6c0828"), null, new DateTime(2024, 12, 18, 14, 19, 51, 594, DateTimeKind.Local).AddTicks(1887), 1, "Revisar pago servicios publicos" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Categoria_CategoriaId",
                table: "Tarea",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Categoria_CategoriaId",
                table: "Tarea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c0844"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c08b7"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c0802"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c0828"));

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Categoria");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Tarea",
                newName: "CategoriId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                newName: "IX_Tarea_CategoriId");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "CategoriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Categoria_CategoriId",
                table: "Tarea",
                column: "CategoriId",
                principalTable: "Categoria",
                principalColumn: "CategoriID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
