CREATE TABLE [dbo].[Materias] (
    [CodMateria] INT           IDENTITY (1, 1) NOT NULL,
    [NomMateria] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Materias] PRIMARY KEY CLUSTERED ([CodMateria] ASC)
);

