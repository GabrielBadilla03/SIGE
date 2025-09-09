CREATE TABLE [dbo].[PeriodosEvaluaciones] (
    [CodPeriodoEvaluacion] INT IDENTITY (1, 1) NOT NULL,
    [Evaluacion]           INT NOT NULL,
    [Periodo]              INT NOT NULL,
    CONSTRAINT [PK_PeriodosEvaluaciones] PRIMARY KEY CLUSTERED ([CodPeriodoEvaluacion] ASC),
    CONSTRAINT [FK_PeriodosEvaluaciones_Evaluaciones_Evaluacion] FOREIGN KEY ([Evaluacion]) REFERENCES [dbo].[Evaluaciones] ([CodEvaluacion]) ON DELETE CASCADE,
    CONSTRAINT [FK_PeriodosEvaluaciones_Periodos_Periodo] FOREIGN KEY ([Periodo]) REFERENCES [dbo].[Periodos] ([CodPeriodo]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PeriodosEvaluaciones_Periodo]
    ON [dbo].[PeriodosEvaluaciones]([Periodo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PeriodosEvaluaciones_Evaluacion]
    ON [dbo].[PeriodosEvaluaciones]([Evaluacion] ASC);

