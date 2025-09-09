CREATE TABLE [dbo].[Grupos] (
    [CodGrupo]        INT            IDENTITY (1, 1) NOT NULL,
    [Seccion]         NVARCHAR (5)   NOT NULL,
    [Grado]           NVARCHAR (20)  NOT NULL,
    [CapacidadMaxima] INT            NOT NULL,
    [AñoLectivo]      INT            NOT NULL,
    [Estado]          BIT            NOT NULL,
    [Aula]            INT            NOT NULL,
    [Profesor]        NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_Grupos] PRIMARY KEY CLUSTERED ([CodGrupo] ASC),
    CONSTRAINT [FK_Grupos_AspNetUsers_Profesor] FOREIGN KEY ([Profesor]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Grupos_Aulas_Aula] FOREIGN KEY ([Aula]) REFERENCES [dbo].[Aulas] ([CodAula])
);


GO
CREATE NONCLUSTERED INDEX [IX_Grupos_Profesor]
    ON [dbo].[Grupos]([Profesor] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Grupos_Aula]
    ON [dbo].[Grupos]([Aula] ASC);

