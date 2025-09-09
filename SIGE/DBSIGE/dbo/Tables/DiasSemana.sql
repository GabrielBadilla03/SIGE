CREATE TABLE [dbo].[DiasSemana] (
    [CodDiaSemana] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]       NVARCHAR (15) NOT NULL,
    [Nomenclatura] NVARCHAR (5)  NOT NULL,
    CONSTRAINT [PK_DiasSemana] PRIMARY KEY CLUSTERED ([CodDiaSemana] ASC)
);

