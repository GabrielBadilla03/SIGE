CREATE TABLE [dbo].[Asistencias] (
    [CodAsistencia]   INT  IDENTITY (1, 1) NOT NULL,
    [Grupo]           INT  NOT NULL,
    [FechaAsistencia] DATE NOT NULL,
    [DiaSemana]       INT  NOT NULL,
    CONSTRAINT [PK_Asistencias] PRIMARY KEY CLUSTERED ([CodAsistencia] ASC),
    CONSTRAINT [FK_Asistencias_DiasSemana_DiaSemana] FOREIGN KEY ([DiaSemana]) REFERENCES [dbo].[DiasSemana] ([CodDiaSemana]) ON DELETE CASCADE,
    CONSTRAINT [FK_Asistencias_Grupos_Grupo] FOREIGN KEY ([Grupo]) REFERENCES [dbo].[Grupos] ([CodGrupo])
);


GO
CREATE NONCLUSTERED INDEX [IX_Asistencias_Grupo]
    ON [dbo].[Asistencias]([Grupo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Asistencias_DiaSemana]
    ON [dbo].[Asistencias]([DiaSemana] ASC);

