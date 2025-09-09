CREATE TABLE [dbo].[Calificaciones] (
    [CodCalificacion]   INT            IDENTITY (1, 1) NOT NULL,
    [Asignacion]        INT            NOT NULL,
    [Estudiante]        INT            NOT NULL,
    [Nota]              INT            NOT NULL,
    [FechaCalificacion] DATE           NOT NULL,
    [Observaciones]     NVARCHAR (250) NULL,
    CONSTRAINT [PK_Calificaciones] PRIMARY KEY CLUSTERED ([CodCalificacion] ASC),
    CONSTRAINT [FK_Calificaciones_Asignaciones_Asignacion] FOREIGN KEY ([Asignacion]) REFERENCES [dbo].[Asignaciones] ([CodAsignacion]) ON DELETE CASCADE,
    CONSTRAINT [FK_Calificaciones_Estudiantes_Estudiante] FOREIGN KEY ([Estudiante]) REFERENCES [dbo].[Estudiantes] ([CodEstudiante]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Calificaciones_Estudiante]
    ON [dbo].[Calificaciones]([Estudiante] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Calificaciones_Asignacion]
    ON [dbo].[Calificaciones]([Asignacion] ASC);

