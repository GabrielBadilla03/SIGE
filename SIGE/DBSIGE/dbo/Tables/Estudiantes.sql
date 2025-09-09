CREATE TABLE [dbo].[Estudiantes] (
    [CodEstudiante] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        NVARCHAR (25) NOT NULL,
    [Apellido1]     NVARCHAR (25) NOT NULL,
    [Apellido2]     NVARCHAR (25) NULL,
    [Cedula]        NVARCHAR (25) NOT NULL,
    [Grado]         NVARCHAR (20) NOT NULL,
    [Grupo]         INT           NOT NULL,
    CONSTRAINT [PK_Estudiantes] PRIMARY KEY CLUSTERED ([CodEstudiante] ASC),
    CONSTRAINT [FK_Estudiantes_Grupos_Grupo] FOREIGN KEY ([Grupo]) REFERENCES [dbo].[Grupos] ([CodGrupo])
);


GO
CREATE NONCLUSTERED INDEX [IX_Estudiantes_Grupo]
    ON [dbo].[Estudiantes]([Grupo] ASC);

