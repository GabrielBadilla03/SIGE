using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGE.Data.Migrations
{
    /// <inheritdoc />
    public partial class TodasLasTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    CodAula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomAula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.CodAula);
                });

            migrationBuilder.CreateTable(
                name: "DiasSemana",
                columns: table => new
                {
                    CodDiaSemana = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Nomenclatura = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasSemana", x => x.CodDiaSemana);
                });

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    CodEvaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.CodEvaluacion);
                });

            migrationBuilder.CreateTable(
                name: "HorasMaterias",
                columns: table => new
                {
                    CodHorasMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasMaterias", x => x.CodHorasMateria);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    CodMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMateria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.CodMateria);
                });

            migrationBuilder.CreateTable(
                name: "Periodos",
                columns: table => new
                {
                    CodPeriodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.CodPeriodo);
                });

            migrationBuilder.CreateTable(
                name: "TiemposLibres",
                columns: table => new
                {
                    CodTiempoLibre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiemposLibres", x => x.CodTiempoLibre);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    CodGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seccion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Grado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CapacidadMaxima = table.Column<int>(type: "int", nullable: false),
                    AñoLectivo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Aula = table.Column<int>(type: "int", nullable: false),
                    Profesor = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.CodGrupo);
                    table.ForeignKey(
                        name: "FK_Grupos_AspNetUsers_Profesor",
                        column: x => x.Profesor,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grupos_Aulas_Aula",
                        column: x => x.Aula,
                        principalTable: "Aulas",
                        principalColumn: "CodAula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosEvaluacion",
                columns: table => new
                {
                    CodArchivosEvaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profesor = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Evaluacion = table.Column<int>(type: "int", nullable: false),
                    Grado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RutaRelativa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NombreOriginal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TamanoBytes = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosEvaluacion", x => x.CodArchivosEvaluacion);
                    table.ForeignKey(
                        name: "FK_ArchivosEvaluacion_AspNetUsers_Profesor",
                        column: x => x.Profesor,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchivosEvaluacion_Evaluaciones_Evaluacion",
                        column: x => x.Evaluacion,
                        principalTable: "Evaluaciones",
                        principalColumn: "CodEvaluacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriasProfesores",
                columns: table => new
                {
                    CodMateriaProfesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Materia = table.Column<int>(type: "int", nullable: false),
                    Profesor = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Aula = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasProfesores", x => x.CodMateriaProfesor);
                    table.ForeignKey(
                        name: "FK_MateriasProfesores_AspNetUsers_Profesor",
                        column: x => x.Profesor,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriasProfesores_Aulas_Aula",
                        column: x => x.Aula,
                        principalTable: "Aulas",
                        principalColumn: "CodAula");
                    table.ForeignKey(
                        name: "FK_MateriasProfesores_Materias_Materia",
                        column: x => x.Materia,
                        principalTable: "Materias",
                        principalColumn: "CodMateria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeriodosEvaluaciones",
                columns: table => new
                {
                    CodPeriodoEvaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evaluacion = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosEvaluaciones", x => x.CodPeriodoEvaluacion);
                    table.ForeignKey(
                        name: "FK_PeriodosEvaluaciones_Evaluaciones_Evaluacion",
                        column: x => x.Evaluacion,
                        principalTable: "Evaluaciones",
                        principalColumn: "CodEvaluacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeriodosEvaluaciones_Periodos_Periodo",
                        column: x => x.Periodo,
                        principalTable: "Periodos",
                        principalColumn: "CodPeriodo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    CodAsistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<int>(type: "int", nullable: false),
                    FechaAsistencia = table.Column<DateTime>(type: "date", nullable: false),
                    DiaSemana = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.CodAsistencia);
                    table.ForeignKey(
                        name: "FK_Asistencias_DiasSemana_DiaSemana",
                        column: x => x.DiaSemana,
                        principalTable: "DiasSemana",
                        principalColumn: "CodDiaSemana",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_Grupos_Grupo",
                        column: x => x.Grupo,
                        principalTable: "Grupos",
                        principalColumn: "CodGrupo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiasHorarios",
                columns: table => new
                {
                    CodDiaHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurnoEscolar = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    Grupo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasHorarios", x => x.CodDiaHorario);
                    table.ForeignKey(
                        name: "FK_DiasHorarios_DiasSemana_DiaSemana",
                        column: x => x.DiaSemana,
                        principalTable: "DiasSemana",
                        principalColumn: "CodDiaSemana",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiasHorarios_Grupos_Grupo",
                        column: x => x.Grupo,
                        principalTable: "Grupos",
                        principalColumn: "CodGrupo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    CodEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Grado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Grupo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.CodEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Grupos_Grupo",
                        column: x => x.Grupo,
                        principalTable: "Grupos",
                        principalColumn: "CodGrupo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    CodAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodoEvaluacion = table.Column<int>(type: "int", nullable: false),
                    Materia = table.Column<int>(type: "int", nullable: false),
                    Grupo = table.Column<int>(type: "int", nullable: false),
                    ArchivoEvaluacion = table.Column<int>(type: "int", nullable: true),
                    NumeroEvaluacion = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaConclusion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.CodAsignacion);
                    table.ForeignKey(
                        name: "FK_Asignaciones_ArchivosEvaluacion_ArchivoEvaluacion",
                        column: x => x.ArchivoEvaluacion,
                        principalTable: "ArchivosEvaluacion",
                        principalColumn: "CodArchivosEvaluacion");
                    table.ForeignKey(
                        name: "FK_Asignaciones_Grupos_Grupo",
                        column: x => x.Grupo,
                        principalTable: "Grupos",
                        principalColumn: "CodGrupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Materias_Materia",
                        column: x => x.Materia,
                        principalTable: "Materias",
                        principalColumn: "CodMateria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignaciones_PeriodosEvaluaciones_PeriodoEvaluacion",
                        column: x => x.PeriodoEvaluacion,
                        principalTable: "PeriodosEvaluaciones",
                        principalColumn: "CodPeriodoEvaluacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorariosTiemposLibres",
                columns: table => new
                {
                    CodHorarioTiempoLibre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaHorario = table.Column<int>(type: "int", nullable: false),
                    TiempoLibre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosTiemposLibres", x => x.CodHorarioTiempoLibre);
                    table.ForeignKey(
                        name: "FK_HorariosTiemposLibres_DiasHorarios_DiaHorario",
                        column: x => x.DiaHorario,
                        principalTable: "DiasHorarios",
                        principalColumn: "CodDiaHorario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorariosTiemposLibres_TiemposLibres_TiempoLibre",
                        column: x => x.TiempoLibre,
                        principalTable: "TiemposLibres",
                        principalColumn: "CodTiempoLibre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatsPorDiaHorario",
                columns: table => new
                {
                    CodMatPorDiaHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MateriaProfesor = table.Column<int>(type: "int", nullable: false),
                    DiasHorario = table.Column<int>(type: "int", nullable: false),
                    HorasMateria = table.Column<int>(type: "int", nullable: false),
                    Aula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatsPorDiaHorario", x => x.CodMatPorDiaHorario);
                    table.ForeignKey(
                        name: "FK_MatsPorDiaHorario_Aulas_Aula",
                        column: x => x.Aula,
                        principalTable: "Aulas",
                        principalColumn: "CodAula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatsPorDiaHorario_DiasHorarios_DiasHorario",
                        column: x => x.DiasHorario,
                        principalTable: "DiasHorarios",
                        principalColumn: "CodDiaHorario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatsPorDiaHorario_HorasMaterias_HorasMateria",
                        column: x => x.HorasMateria,
                        principalTable: "HorasMaterias",
                        principalColumn: "CodHorasMateria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatsPorDiaHorario_MateriasProfesores_MateriaProfesor",
                        column: x => x.MateriaProfesor,
                        principalTable: "MateriasProfesores",
                        principalColumn: "CodMateriaProfesor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AsistenciasEstudiantes",
                columns: table => new
                {
                    CodAsistenciaEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asistencia = table.Column<int>(type: "int", nullable: false),
                    Estudiante = table.Column<int>(type: "int", nullable: false),
                    Asistio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistenciasEstudiantes", x => x.CodAsistenciaEstudiante);
                    table.ForeignKey(
                        name: "FK_AsistenciasEstudiantes_Asistencias_Asistencia",
                        column: x => x.Asistencia,
                        principalTable: "Asistencias",
                        principalColumn: "CodAsistencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsistenciasEstudiantes_Estudiantes_Estudiante",
                        column: x => x.Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "CodEstudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    CodCalificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asignacion = table.Column<int>(type: "int", nullable: false),
                    Estudiante = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    FechaCalificacion = table.Column<DateTime>(type: "date", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.CodCalificacion);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Asignaciones_Asignacion",
                        column: x => x.Asignacion,
                        principalTable: "Asignaciones",
                        principalColumn: "CodAsignacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Estudiantes_Estudiante",
                        column: x => x.Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "CodEstudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsistenciasMaterias",
                columns: table => new
                {
                    CodAsistenciaMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatPorDiaHorario = table.Column<int>(type: "int", nullable: false),
                    AsistenciaEstudiante = table.Column<int>(type: "int", nullable: false),
                    Asistio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistenciasMaterias", x => x.CodAsistenciaMateria);
                    table.ForeignKey(
                        name: "FK_AsistenciasMaterias_AsistenciasEstudiantes_AsistenciaEstudiante",
                        column: x => x.AsistenciaEstudiante,
                        principalTable: "AsistenciasEstudiantes",
                        principalColumn: "CodAsistenciaEstudiante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsistenciasMaterias_MatsPorDiaHorario_MatPorDiaHorario",
                        column: x => x.MatPorDiaHorario,
                        principalTable: "MatsPorDiaHorario",
                        principalColumn: "CodMatPorDiaHorario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosEvaluacion_Evaluacion",
                table: "ArchivosEvaluacion",
                column: "Evaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosEvaluacion_Profesor",
                table: "ArchivosEvaluacion",
                column: "Profesor");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_ArchivoEvaluacion",
                table: "Asignaciones",
                column: "ArchivoEvaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_Grupo",
                table: "Asignaciones",
                column: "Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_Materia",
                table: "Asignaciones",
                column: "Materia");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_PeriodoEvaluacion",
                table: "Asignaciones",
                column: "PeriodoEvaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_DiaSemana",
                table: "Asistencias",
                column: "DiaSemana");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_Grupo",
                table: "Asistencias",
                column: "Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciasEstudiantes_Asistencia",
                table: "AsistenciasEstudiantes",
                column: "Asistencia");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciasEstudiantes_Estudiante",
                table: "AsistenciasEstudiantes",
                column: "Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciasMaterias_AsistenciaEstudiante",
                table: "AsistenciasMaterias",
                column: "AsistenciaEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciasMaterias_MatPorDiaHorario",
                table: "AsistenciasMaterias",
                column: "MatPorDiaHorario");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_Asignacion",
                table: "Calificaciones",
                column: "Asignacion");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_Estudiante",
                table: "Calificaciones",
                column: "Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_DiasHorarios_DiaSemana",
                table: "DiasHorarios",
                column: "DiaSemana");

            migrationBuilder.CreateIndex(
                name: "IX_DiasHorarios_Grupo",
                table: "DiasHorarios",
                column: "Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_Grupo",
                table: "Estudiantes",
                column: "Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_Aula",
                table: "Grupos",
                column: "Aula");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_Profesor",
                table: "Grupos",
                column: "Profesor");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosTiemposLibres_DiaHorario",
                table: "HorariosTiemposLibres",
                column: "DiaHorario");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosTiemposLibres_TiempoLibre",
                table: "HorariosTiemposLibres",
                column: "TiempoLibre");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasProfesores_Aula",
                table: "MateriasProfesores",
                column: "Aula");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasProfesores_Materia",
                table: "MateriasProfesores",
                column: "Materia");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasProfesores_Profesor",
                table: "MateriasProfesores",
                column: "Profesor");

            migrationBuilder.CreateIndex(
                name: "IX_MatsPorDiaHorario_Aula",
                table: "MatsPorDiaHorario",
                column: "Aula");

            migrationBuilder.CreateIndex(
                name: "IX_MatsPorDiaHorario_DiasHorario",
                table: "MatsPorDiaHorario",
                column: "DiasHorario");

            migrationBuilder.CreateIndex(
                name: "IX_MatsPorDiaHorario_HorasMateria",
                table: "MatsPorDiaHorario",
                column: "HorasMateria");

            migrationBuilder.CreateIndex(
                name: "IX_MatsPorDiaHorario_MateriaProfesor",
                table: "MatsPorDiaHorario",
                column: "MateriaProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosEvaluaciones_Evaluacion",
                table: "PeriodosEvaluaciones",
                column: "Evaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosEvaluaciones_Periodo",
                table: "PeriodosEvaluaciones",
                column: "Periodo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsistenciasMaterias");

            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "HorariosTiemposLibres");

            migrationBuilder.DropTable(
                name: "AsistenciasEstudiantes");

            migrationBuilder.DropTable(
                name: "MatsPorDiaHorario");

            migrationBuilder.DropTable(
                name: "Asignaciones");

            migrationBuilder.DropTable(
                name: "TiemposLibres");

            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "DiasHorarios");

            migrationBuilder.DropTable(
                name: "HorasMaterias");

            migrationBuilder.DropTable(
                name: "MateriasProfesores");

            migrationBuilder.DropTable(
                name: "ArchivosEvaluacion");

            migrationBuilder.DropTable(
                name: "PeriodosEvaluaciones");

            migrationBuilder.DropTable(
                name: "DiasSemana");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Periodos");

            migrationBuilder.DropTable(
                name: "Aulas");
        }
    }
}
