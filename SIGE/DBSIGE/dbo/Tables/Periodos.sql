CREATE TABLE [dbo].[Periodos] (
    [CodPeriodo]  INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (20) NOT NULL,
    [FechaInicio] DATE          NOT NULL,
    [FechaFin]    DATE          NOT NULL,
    CONSTRAINT [PK_Periodos] PRIMARY KEY CLUSTERED ([CodPeriodo] ASC)
);

