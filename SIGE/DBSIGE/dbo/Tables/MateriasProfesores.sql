CREATE TABLE [dbo].[MateriasProfesores] (
    [CodMateriaProfesor] INT            IDENTITY (1, 1) NOT NULL,
    [Materia]            INT            NOT NULL,
    [Profesor]           NVARCHAR (450) NOT NULL,
    [Aula]               INT            NULL,
    CONSTRAINT [PK_MateriasProfesores] PRIMARY KEY CLUSTERED ([CodMateriaProfesor] ASC),
    CONSTRAINT [FK_MateriasProfesores_AspNetUsers_Profesor] FOREIGN KEY ([Profesor]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MateriasProfesores_Aulas_Aula] FOREIGN KEY ([Aula]) REFERENCES [dbo].[Aulas] ([CodAula]),
    CONSTRAINT [FK_MateriasProfesores_Materias_Materia] FOREIGN KEY ([Materia]) REFERENCES [dbo].[Materias] ([CodMateria]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_MateriasProfesores_Profesor]
    ON [dbo].[MateriasProfesores]([Profesor] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MateriasProfesores_Materia]
    ON [dbo].[MateriasProfesores]([Materia] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MateriasProfesores_Aula]
    ON [dbo].[MateriasProfesores]([Aula] ASC);

