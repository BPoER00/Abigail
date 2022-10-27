using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAbigail.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado_Civil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado_Civil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etnia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etnia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cui = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero_Id = table.Column<int>(type: "int", nullable: false),
                    Estado_Civil_Id = table.Column<int>(type: "int", nullable: false),
                    Etnia_Id = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol_Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Inmueble",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Inmueble", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Reporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Reporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Vehiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cabeza_Famila",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Id = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabeza_Famila", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cabeza_Famila_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entrada_Salida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Id = table.Column<int>(type: "int", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada_Salida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrada_Salida_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Id = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propietario_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false),
                    Modulo_Id = table.Column<int>(type: "int", nullable: false),
                    Accion_Id = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    ModuloId = table.Column<int>(type: "int", nullable: true),
                    AccionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permiso_Accion_AccionId",
                        column: x => x.AccionId,
                        principalTable: "Accion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permiso_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permiso_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false),
                    Sal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inmueble",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_Inmueble = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sector_Id = table.Column<int>(type: "int", nullable: false),
                    Tipo_Inmueble_Id = table.Column<int>(type: "int", nullable: false),
                    Precio_Inmueble = table.Column<long>(type: "bigint", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    Tipo_InmuebleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmueble", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inmueble_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inmueble_Tipo_Inmueble_Tipo_InmuebleId",
                        column: x => x.Tipo_InmuebleId,
                        principalTable: "Tipo_Inmueble",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Id = table.Column<int>(type: "int", nullable: false),
                    Tipo_Reporte_Id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    Tipo_ReporteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reporte_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reporte_Tipo_Reporte_Tipo_ReporteId",
                        column: x => x.Tipo_ReporteId,
                        principalTable: "Tipo_Reporte",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca_Id = table.Column<int>(type: "int", nullable: false),
                    Color_Id = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo_VehiculoId = table.Column<int>(type: "int", nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehiculo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehiculo_Tipo_Vehiculo_Tipo_VehiculoId",
                        column: x => x.Tipo_VehiculoId,
                        principalTable: "Tipo_Vehiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Familia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Id = table.Column<int>(type: "int", nullable: false),
                    Cabeza_Familia_Id = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    Cabeza_FamiliaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Familia_Cabeza_Famila_Cabeza_FamiliaId",
                        column: x => x.Cabeza_FamiliaId,
                        principalTable: "Cabeza_Famila",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Familia_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factura_Id = table.Column<int>(type: "int", nullable: false),
                    Inmueble_Id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: true),
                    InmuebleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalle_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Detalle_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inmueble_Alquilados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persona_Id = table.Column<int>(type: "int", nullable: false),
                    Inmueble_Id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Alquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Fin_Alquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    InmuebleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmueble_Alquilados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inmueble_Alquilados_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inmueble_Alquilados_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prop_Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehiculo_Id = table.Column<int>(type: "int", nullable: false),
                    Persona_Id = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    Fecha_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_commit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: true),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prop_Vehiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prop_Vehiculo_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prop_Vehiculo_Vehiculo_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabeza_Famila_PersonaId",
                table: "Cabeza_Famila",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_FacturaId",
                table: "Detalle",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_InmuebleId",
                table: "Detalle",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_Salida_PersonaId",
                table: "Entrada_Salida",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_PersonaId",
                table: "Factura",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Familia_Cabeza_FamiliaId",
                table: "Familia",
                column: "Cabeza_FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Familia_PersonaId",
                table: "Familia",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_SectorId",
                table: "Inmueble",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_Tipo_InmuebleId",
                table: "Inmueble",
                column: "Tipo_InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_Alquilados_InmuebleId",
                table: "Inmueble_Alquilados",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_Alquilados_PersonaId",
                table: "Inmueble_Alquilados",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_AccionId",
                table: "Permiso",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_ModuloId",
                table: "Permiso",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_RolId",
                table: "Permiso",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Prop_Vehiculo_PersonaId",
                table: "Prop_Vehiculo",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prop_Vehiculo_VehiculoId",
                table: "Prop_Vehiculo",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Propietario_PersonaId",
                table: "Propietario",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_PersonaId",
                table: "Reporte",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reporte_Tipo_ReporteId",
                table: "Reporte",
                column: "Tipo_ReporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_ColorId",
                table: "Vehiculo",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_MarcaId",
                table: "Vehiculo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Tipo_VehiculoId",
                table: "Vehiculo",
                column: "Tipo_VehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Entrada_Salida");

            migrationBuilder.DropTable(
                name: "Estado_Civil");

            migrationBuilder.DropTable(
                name: "Etnia");

            migrationBuilder.DropTable(
                name: "Familia");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Inmueble_Alquilados");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Prop_Vehiculo");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Reporte");

            migrationBuilder.DropTable(
                name: "Rol_Persona");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Cabeza_Famila");

            migrationBuilder.DropTable(
                name: "Inmueble");

            migrationBuilder.DropTable(
                name: "Accion");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Tipo_Reporte");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "Tipo_Inmueble");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Tipo_Vehiculo");
        }
    }
}
