CREATE TABLE [dbo].[HorasMaterias] (
    [CodHorasMateria] INT      IDENTITY (1, 1) NOT NULL,
    [HoraInicio]      TIME (7) NOT NULL,
    [HoraFin]         TIME (7) NOT NULL,
    CONSTRAINT [PK_HorasMaterias] PRIMARY KEY CLUSTERED ([CodHorasMateria] ASC)
);

