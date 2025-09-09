CREATE TABLE [dbo].[Asignaciones] (
    [CodAsignacion]     INT  IDENTITY (1, 1) NOT NULL,
    [PeriodoEvaluacion] INT  NOT NULL,
    [Materia]           INT  NOT NULL,
    [Grupo]             INT  NOT NULL,
    [ArchivoEvaluacion] INT  NULL,
    [NumeroEvaluacion]  INT  NOT NULL,
    [FechaAsignacion]   DATE NOT NULL,
    [FechaConclusion]   DATE NOT NULL,
    CONSTRAINT [PK_Asignaciones] PRIMARY KEY CLUSTERED ([CodAsignacion] ASC),
    CONSTRAINT [FK_Asignaciones_ArchivosEvaluacion_ArchivoEvaluacion] FOREIGN KEY ([ArchivoEvaluacion]) REFERENCES [dbo].[ArchivosEvaluacion] ([CodArchivosEvaluacion]),
    CONSTRAINT [FK_Asignaciones_Grupos_Grupo] FOREIGN KEY ([Grupo]) REFERENCES [dbo].[Grupos] ([CodGrupo]) ON DELETE CASCADE,
    CONSTRAINT [FK_Asignaciones_Materias_Materia] FOREIGN KEY ([Materia]) REFERENCES [dbo].[Materias] ([CodMateria]) ON DELETE CASCADE,
    CONSTRAINT [FK_Asignaciones_PeriodosEvaluaciones_PeriodoEvaluacion] FOREIGN KEY ([PeriodoEvaluacion]) REFERENCES [dbo].[PeriodosEvaluaciones] ([CodPeriodoEvaluacion]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Asignaciones_PeriodoEvaluacion]
    ON [dbo].[Asignaciones]([PeriodoEvaluacion] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Asignaciones_Materia]
    ON [dbo].[Asignaciones]([Materia] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Asignaciones_Grupo]
    ON [dbo].[Asignaciones]([Grupo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Asignaciones_ArchivoEvaluacion]
    ON [dbo].[Asignaciones]([ArchivoEvaluacion] ASC);

