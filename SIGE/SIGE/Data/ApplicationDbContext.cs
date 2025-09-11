using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIGE.Models;

namespace SIGE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // === Entidades de dominio ===
        public DbSet<ArchivoEvaluacion> ArchivosEvaluacion { get; set; } = default!;
        public DbSet<Asignacion> Asignaciones { get; set; } = default!;
        public DbSet<Asistencia> Asistencias { get; set; } = default!;
        public DbSet<AsistenciaEstudiante> AsistenciasEstudiantes { get; set; } = default!;
        public DbSet<AsistenciaMateria> AsistenciasMaterias { get; set; } = default!;
        public DbSet<Aula> Aulas { get; set; } = default!;
        public DbSet<Calificacion> Calificaciones { get; set; } = default!;
        public DbSet<DiaHorario> DiasHorarios { get; set; } = default!;
        public DbSet<DiaSemana> DiasSemana { get; set; } = default!;
        public DbSet<Estudiante> Estudiantes { get; set; } = default!;
        public DbSet<Evaluacion> Evaluaciones { get; set; } = default!;
        public DbSet<Grupo> Grupos { get; set; } = default!;
        public DbSet<HorarioTiempoLibre> HorariosTiemposLibres { get; set; } = default!;
        public DbSet<HorasMateria> HorasMaterias { get; set; } = default!;
        public DbSet<Materia> Materias { get; set; } = default!;
        public DbSet<MateriaProfesor> MateriasProfesores { get; set; } = default!;
        public DbSet<MatPorDiaHorario> MatsPorDiaHorario { get; set; } = default!;
        public DbSet<Periodo> Periodos { get; set; } = default!;
        public DbSet<PeriodoEvaluacion> PeriodosEvaluaciones { get; set; } = default!;
        public DbSet<TiempoLibre> TiemposLibres { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índices únicos (recomendado para evitar duplicados manuales)
            modelBuilder.Entity<DiaSemana>()
                .HasIndex(d => d.Nombre)
                .IsUnique();

            modelBuilder.Entity<DiaSemana>()
                .HasIndex(d => d.Nomenclatura)
                .IsUnique();

            // Seed de días de la semana (solo una vez via migración)
            modelBuilder.Entity<DiaSemana>().HasData(
                new DiaSemana { CodDiaSemana = 1, Nombre = "Lunes", Nomenclatura = "L" },
                new DiaSemana { CodDiaSemana = 2, Nombre = "Martes", Nomenclatura = "K" },
                new DiaSemana { CodDiaSemana = 3, Nombre = "Miércoles", Nomenclatura = "M" },
                new DiaSemana { CodDiaSemana = 4, Nombre = "Jueves", Nomenclatura = "J" },
                new DiaSemana { CodDiaSemana = 5, Nombre = "Viernes", Nomenclatura = "V" },
                new DiaSemana { CodDiaSemana = 6, Nombre = "Sábado", Nomenclatura = "S" },
                new DiaSemana { CodDiaSemana = 7, Nombre = "Domingo", Nomenclatura = "D" }
            );

            // 1) NO borrar Grupos cuando se borra Aula (bloquea el borrado si hay Grupos)
            modelBuilder.Entity<Grupo>()
                .HasOne(g => g.AulaFK)
                .WithMany()
                .HasForeignKey(g => g.Aula)
                .OnDelete(DeleteBehavior.Restrict);

            // 2) NO borrar MatsPorDiaHorario cuando se borra DiasHorarios
            modelBuilder.Entity<MatPorDiaHorario>()
                .HasOne(m => m.DiasHorarioFK)
                .WithMany()
                .HasForeignKey(m => m.DiasHorario)
                .OnDelete(DeleteBehavior.Restrict);

            // 3) NO borrar MatsPorDiaHorario cuando se borra Aula
            modelBuilder.Entity<MatPorDiaHorario>()
                .HasOne(m => m.AulaFK)
                .WithMany()
                .HasForeignKey(m => m.Aula)
                .OnDelete(DeleteBehavior.Restrict);

            // 4) NO borrar MatsPorDiaHorario cuando se borra HorasMateria
            modelBuilder.Entity<MatPorDiaHorario>()
                .HasOne(m => m.HorasMateriaFK)
                .WithMany()
                .HasForeignKey(m => m.HorasMateria)
                .OnDelete(DeleteBehavior.Restrict);

            // 5) NO borrar MatsPorDiaHorario cuando se borra MateriasProfesores
            modelBuilder.Entity<MatPorDiaHorario>()
                .HasOne(m => m.MateriaProfesorFK)
                .WithMany()
                .HasForeignKey(m => m.MateriaProfesor)
                .OnDelete(DeleteBehavior.Restrict);

            // 1) Asistencia -> Grupo : RESTRICT (bloquea borrado de Grupo si hay asistencias)
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.GrupoFk)
                .WithMany()
                .HasForeignKey(a => a.Grupo)
                .OnDelete(DeleteBehavior.Restrict);

            // 2) Estudiante -> Grupo : RESTRICT (bloquea borrado de Grupo si hay estudiantes)
            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.GrupoFk)
                .WithMany()
                .HasForeignKey(e => e.Grupo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
