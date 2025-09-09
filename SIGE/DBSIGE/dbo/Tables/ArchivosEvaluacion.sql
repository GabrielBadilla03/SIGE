CREATE TABLE [dbo].[ArchivosEvaluacion] (
    [CodArchivosEvaluacion] INT            IDENTITY (1, 1) NOT NULL,
    [Profesor]              NVARCHAR (450) NOT NULL,
    [Evaluacion]            INT            NOT NULL,
    [Grado]                 NVARCHAR (20)  NOT NULL,
    [RutaRelativa]          NVARCHAR (500) NOT NULL,
    [NombreOriginal]        NVARCHAR (255) NOT NULL,
    [ContentType]           NVARCHAR (128) NOT NULL,
    [TamanoBytes]           BIGINT         NOT NULL,
    CONSTRAINT [PK_ArchivosEvaluacion] PRIMARY KEY CLUSTERED ([CodArchivosEvaluacion] ASC),
    CONSTRAINT [FK_ArchivosEvaluacion_AspNetUsers_Profesor] FOREIGN KEY ([Profesor]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArchivosEvaluacion_Evaluaciones_Evaluacion] FOREIGN KEY ([Evaluacion]) REFERENCES [dbo].[Evaluaciones] ([CodEvaluacion]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ArchivosEvaluacion_Profesor]
    ON [dbo].[ArchivosEvaluacion]([Profesor] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ArchivosEvaluacion_Evaluacion]
    ON [dbo].[ArchivosEvaluacion]([Evaluacion] ASC);

