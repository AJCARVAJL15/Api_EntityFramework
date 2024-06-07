using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InicialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("53f5f62b-088e-43c4-b866-bc14dd34e5d0"), null, "Actividades pendientes", 20 },
                    { new Guid("7542bf1c-fc5e-4ad4-b11b-35db66b4a707"), null, "Actividades realizadas", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("e6bfaa3b-05a3-4fe6-8936-fbbb1f72f54d"), new Guid("7542bf1c-fc5e-4ad4-b11b-35db66b4a707"), null, new DateTime(2024, 6, 5, 9, 9, 18, 433, DateTimeKind.Local).AddTicks(3397), 1, "Estudiar nuevos temas" },
                    { new Guid("f50539e8-c941-4a7b-9869-a179c728e590"), new Guid("53f5f62b-088e-43c4-b866-bc14dd34e5d0"), null, new DateTime(2024, 6, 5, 9, 9, 18, 433, DateTimeKind.Local).AddTicks(3378), 1, "Pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("e6bfaa3b-05a3-4fe6-8936-fbbb1f72f54d"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f50539e8-c941-4a7b-9869-a179c728e590"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("53f5f62b-088e-43c4-b866-bc14dd34e5d0"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("7542bf1c-fc5e-4ad4-b11b-35db66b4a707"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
