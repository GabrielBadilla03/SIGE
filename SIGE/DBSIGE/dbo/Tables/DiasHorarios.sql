CREATE TABLE [dbo].[DiasHorarios] (
    [CodDiaHorario] INT           IDENTITY (1, 1) NOT NULL,
    [TurnoEscolar]  NVARCHAR (20) NOT NULL,
    [HoraInicio]    TIME (7)      NOT NULL,
    [HoraFin]       TIME (7)      NOT NULL,
    [DiaSemana]     INT           NOT NULL,
    [Grupo]         INT           NOT NULL,
    CONSTRAINT [PK_DiasHorarios] PRIMARY KEY CLUSTERED ([CodDiaHorario] ASC),
    CONSTRAINT [FK_DiasHorarios_DiasSemana_DiaSemana] FOREIGN KEY ([DiaSemana]) REFERENCES [dbo].[DiasSemana] ([CodDiaSemana]) ON DELETE CASCADE,
    CONSTRAINT [FK_DiasHorarios_Grupos_Grupo] FOREIGN KEY ([Grupo]) REFERENCES [dbo].[Grupos] ([CodGrupo]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_DiasHorarios_Grupo]
    ON [dbo].[DiasHorarios]([Grupo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DiasHorarios_DiaSemana]
    ON [dbo].[DiasHorarios]([DiaSemana] ASC);

