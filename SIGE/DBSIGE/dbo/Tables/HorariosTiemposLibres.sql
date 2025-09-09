CREATE TABLE [dbo].[HorariosTiemposLibres] (
    [CodHorarioTiempoLibre] INT IDENTITY (1, 1) NOT NULL,
    [DiaHorario]            INT NOT NULL,
    [TiempoLibre]           INT NOT NULL,
    CONSTRAINT [PK_HorariosTiemposLibres] PRIMARY KEY CLUSTERED ([CodHorarioTiempoLibre] ASC),
    CONSTRAINT [FK_HorariosTiemposLibres_DiasHorarios_DiaHorario] FOREIGN KEY ([DiaHorario]) REFERENCES [dbo].[DiasHorarios] ([CodDiaHorario]) ON DELETE CASCADE,
    CONSTRAINT [FK_HorariosTiemposLibres_TiemposLibres_TiempoLibre] FOREIGN KEY ([TiempoLibre]) REFERENCES [dbo].[TiemposLibres] ([CodTiempoLibre]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_HorariosTiemposLibres_TiempoLibre]
    ON [dbo].[HorariosTiemposLibres]([TiempoLibre] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_HorariosTiemposLibres_DiaHorario]
    ON [dbo].[HorariosTiemposLibres]([DiaHorario] ASC);

