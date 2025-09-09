CREATE TABLE [dbo].[MatsPorDiaHorario] (
    [CodMatPorDiaHorario] INT IDENTITY (1, 1) NOT NULL,
    [MateriaProfesor]     INT NOT NULL,
    [DiasHorario]         INT NOT NULL,
    [HorasMateria]        INT NOT NULL,
    [Aula]                INT NOT NULL,
    CONSTRAINT [PK_MatsPorDiaHorario] PRIMARY KEY CLUSTERED ([CodMatPorDiaHorario] ASC),
    CONSTRAINT [FK_MatsPorDiaHorario_Aulas_Aula] FOREIGN KEY ([Aula]) REFERENCES [dbo].[Aulas] ([CodAula]),
    CONSTRAINT [FK_MatsPorDiaHorario_DiasHorarios_DiasHorario] FOREIGN KEY ([DiasHorario]) REFERENCES [dbo].[DiasHorarios] ([CodDiaHorario]),
    CONSTRAINT [FK_MatsPorDiaHorario_HorasMaterias_HorasMateria] FOREIGN KEY ([HorasMateria]) REFERENCES [dbo].[HorasMaterias] ([CodHorasMateria]),
    CONSTRAINT [FK_MatsPorDiaHorario_MateriasProfesores_MateriaProfesor] FOREIGN KEY ([MateriaProfesor]) REFERENCES [dbo].[MateriasProfesores] ([CodMateriaProfesor])
);


GO
CREATE NONCLUSTERED INDEX [IX_MatsPorDiaHorario_MateriaProfesor]
    ON [dbo].[MatsPorDiaHorario]([MateriaProfesor] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MatsPorDiaHorario_HorasMateria]
    ON [dbo].[MatsPorDiaHorario]([HorasMateria] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MatsPorDiaHorario_DiasHorario]
    ON [dbo].[MatsPorDiaHorario]([DiasHorario] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MatsPorDiaHorario_Aula]
    ON [dbo].[MatsPorDiaHorario]([Aula] ASC);

