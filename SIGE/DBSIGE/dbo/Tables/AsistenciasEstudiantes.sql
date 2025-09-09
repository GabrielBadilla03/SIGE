CREATE TABLE [dbo].[AsistenciasEstudiantes] (
    [CodAsistenciaEstudiante] INT IDENTITY (1, 1) NOT NULL,
    [Asistencia]              INT NOT NULL,
    [Estudiante]              INT NOT NULL,
    [Asistio]                 BIT NOT NULL,
    CONSTRAINT [PK_AsistenciasEstudiantes] PRIMARY KEY CLUSTERED ([CodAsistenciaEstudiante] ASC),
    CONSTRAINT [FK_AsistenciasEstudiantes_Asistencias_Asistencia] FOREIGN KEY ([Asistencia]) REFERENCES [dbo].[Asistencias] ([CodAsistencia]) ON DELETE CASCADE,
    CONSTRAINT [FK_AsistenciasEstudiantes_Estudiantes_Estudiante] FOREIGN KEY ([Estudiante]) REFERENCES [dbo].[Estudiantes] ([CodEstudiante]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AsistenciasEstudiantes_Estudiante]
    ON [dbo].[AsistenciasEstudiantes]([Estudiante] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AsistenciasEstudiantes_Asistencia]
    ON [dbo].[AsistenciasEstudiantes]([Asistencia] ASC);

