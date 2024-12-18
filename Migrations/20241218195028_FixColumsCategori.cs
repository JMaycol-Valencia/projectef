using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class FixColumsCategori : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Categoria_CategoriaId",
                table: "Tarea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

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
                newName: "CategoriID");

            migrationBuilder.RenameIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                newName: "IX_Tarea_CategoriID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "CategoriID");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriID", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("429e610a-0a26-4790-9de3-58be1f6c0802"), null, "Actividades Personales", 50 },
                    { new Guid("429e610a-0a26-4790-9de3-58be1f6c0828"), null, "Actividades Pendientes", 20 }
                });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c0844"),
                column: "FechaCreacion",
                value: new DateTime(2024, 12, 18, 15, 50, 28, 321, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c08b7"),
                column: "FechaCreacion",
                value: new DateTime(2024, 12, 18, 15, 50, 28, 321, DateTimeKind.Local).AddTicks(5372));

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Categoria_CategoriID",
                table: "Tarea",
                column: "CategoriID",
                principalTable: "Categoria",
                principalColumn: "CategoriID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Categoria_CategoriID",
                table: "Tarea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriID",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c0802"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriID",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c0828"));

            migrationBuilder.RenameColumn(
                name: "CategoriID",
                table: "Tarea",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarea_CategoriID",
                table: "Tarea",
                newName: "IX_Tarea_CategoriaId");

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

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c0844"),
                column: "FechaCreacion",
                value: new DateTime(2024, 12, 18, 14, 19, 51, 594, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("429e610a-0a26-4790-9de3-58be1f6c08b7"),
                column: "FechaCreacion",
                value: new DateTime(2024, 12, 18, 14, 19, 51, 594, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Categoria_CategoriaId",
                table: "Tarea",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
