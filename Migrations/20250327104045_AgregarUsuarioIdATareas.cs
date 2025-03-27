using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestiondetareas.Migrations
{
    /// <inheritdoc />
    public partial class AgregarUsuarioIdATareas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Agregar la columna UsuarioId en la tabla Tareas
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Tareas",
                nullable: false,
                defaultValue: 0);

            // Crear la clave foránea entre Tareas y Usuarios
            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Usuarios_UsuarioId",
                table: "Tareas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
                // Eliminar la clave foránea y la columna si se revierte la migración
                migrationBuilder.DropForeignKey(
                    name: "FK_Tareas_Usuarios_UsuarioId",
                    table: "Tareas");

                migrationBuilder.DropColumn(
                    name: "UsuarioId",
                    table: "Tareas");
            

        }
    }
}
