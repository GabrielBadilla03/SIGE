CREATE TABLE [dbo].[AsistenciasMaterias] (
    [CodAsistenciaMateria] INT IDENTITY (1, 1) NOT NULL,
    [MatPorDiaHorario]     INT NOT NULL,
    [AsistenciaEstudiante] INT NOT NULL,
    [Asistio]              BIT NOT NULL,
    CONSTRAINT [PK_AsistenciasMaterias] PRIMARY KEY CLUSTERED ([CodAsistenciaMateria] ASC),
    CONSTRAINT [FK_AsistenciasMaterias_AsistenciasEstudiantes_AsistenciaEstudiante] FOREIGN KEY ([AsistenciaEstudiante]) REFERENCES [dbo].[AsistenciasEstudiantes] ([CodAsistenciaEstudiante]) ON DELETE CASCADE,
    CONSTRAINT [FK_AsistenciasMaterias_MatsPorDiaHorario_MatPorDiaHorario] FOREIGN KEY ([MatPorDiaHorario]) REFERENCES [dbo].[MatsPorDiaHorario] ([CodMatPorDiaHorario]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AsistenciasMaterias_MatPorDiaHorario]
    ON [dbo].[AsistenciasMaterias]([MatPorDiaHorario] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AsistenciasMaterias_AsistenciaEstudiante]
    ON [dbo].[AsistenciasMaterias]([AsistenciaEstudiante] ASC);

