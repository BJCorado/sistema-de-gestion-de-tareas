using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestiondetareas.Migrations
{
    public partial class AgregarUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),  // Cambiado para MariaDB
                    Titulo = table.Column<string>(type: "varchar(255)", nullable: false),  // Cambiado de nvarchar(max) a varchar(255)
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: false),  // Cambiado de nvarchar(max) a varchar(255)
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),  // Cambiado de datetime2 a datetime
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    Estado = table.Column<string>(type: "varchar(255)", nullable: false)  // Cambiado de nvarchar(max) a varchar(255)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");
        }
    }
}
