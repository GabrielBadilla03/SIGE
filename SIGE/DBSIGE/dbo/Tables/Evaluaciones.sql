CREATE TABLE [dbo].[Evaluaciones] (
    [CodEvaluacion] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        NVARCHAR (20) NOT NULL,
    [Valor]         INT           NOT NULL,
    CONSTRAINT [PK_Evaluaciones] PRIMARY KEY CLUSTERED ([CodEvaluacion] ASC)
);

