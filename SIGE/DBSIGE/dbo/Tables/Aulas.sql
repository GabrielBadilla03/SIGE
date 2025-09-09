CREATE TABLE [dbo].[Aulas] (
    [CodAula] INT           IDENTITY (1, 1) NOT NULL,
    [NomAula] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Aulas] PRIMARY KEY CLUSTERED ([CodAula] ASC)
);

