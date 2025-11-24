using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mecario_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefonoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccionCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Piezas",
                columns: table => new
                {
                    idPieza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePieza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoriaPieza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionPieza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioUnidad = table.Column<double>(type: "float", nullable: false),
                    stockActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piezas", x => x.idPieza);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefonoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccionUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    idVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroChasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.idVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesServicios",
                columns: table => new
                {
                    idOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diagnosticoInicial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costoInicial = table.Column<double>(type: "float", nullable: false),
                    idVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesServicios", x => x.idOrden);
                    table.ForeignKey(
                        name: "FK_OrdenesServicios_Vehiculos_idVehiculo",
                        column: x => x.idVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "idVehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    idCaso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    horasTrabajadas = table.Column<double>(type: "float", nullable: false),
                    totalCaso = table.Column<double>(type: "float", nullable: false),
                    idOrdenServicio = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.idCaso);
                    table.ForeignKey(
                        name: "FK_Casos_OrdenesServicios_idOrdenServicio",
                        column: x => x.idOrdenServicio,
                        principalTable: "OrdenesServicios",
                        principalColumn: "idOrden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casos_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallesCasos",
                columns: table => new
                {
                    idDetalleCaso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tareaRealizada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCaso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCasos", x => x.idDetalleCaso);
                    table.ForeignKey(
                        name: "FK_DetallesCasos_Casos_idCaso",
                        column: x => x.idCaso,
                        principalTable: "Casos",
                        principalColumn: "idCaso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesPiezas",
                columns: table => new
                {
                    idCaso = table.Column<int>(type: "int", nullable: false),
                    idPieza = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precioUnitario = table.Column<double>(type: "float", nullable: false),
                    subtotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesPiezas", x => new { x.idCaso, x.idPieza });
                    table.ForeignKey(
                        name: "FK_DetallesPiezas_Casos_idCaso",
                        column: x => x.idCaso,
                        principalTable: "Casos",
                        principalColumn: "idCaso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesPiezas_Piezas_idPieza",
                        column: x => x.idPieza,
                        principalTable: "Piezas",
                        principalColumn: "idPieza",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casos_idOrdenServicio",
                table: "Casos",
                column: "idOrdenServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_idUsuario",
                table: "Casos",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCasos_idCaso",
                table: "DetallesCasos",
                column: "idCaso");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPiezas_idPieza",
                table: "DetallesPiezas",
                column: "idPieza");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicios_idVehiculo",
                table: "OrdenesServicios",
                column: "idVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_idCliente",
                table: "Vehiculos",
                column: "idCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesCasos");

            migrationBuilder.DropTable(
                name: "DetallesPiezas");

            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "Piezas");

            migrationBuilder.DropTable(
                name: "OrdenesServicios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
