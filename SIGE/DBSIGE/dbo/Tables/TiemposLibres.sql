CREATE TABLE [dbo].[TiemposLibres] (
    [CodTiempoLibre] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]         NVARCHAR (50) NOT NULL,
    [HoraInicio]     TIME (7)      NOT NULL,
    [HoraFin]        TIME (7)      NOT NULL,
    CONSTRAINT [PK_TiemposLibres] PRIMARY KEY CLUSTERED ([CodTiempoLibre] ASC)
);

