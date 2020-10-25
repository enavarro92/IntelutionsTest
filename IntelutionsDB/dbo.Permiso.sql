USE [IntelutionsDB]
GO

/****** Objeto: Table [dbo].[Permiso] Fecha del script: 25/10/2020 7:12:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Permiso] (
    [Id]                INT  IDENTITY (1, 1) NOT NULL,
    [NombreEmpleado]    TEXT NULL,
    [ApellidosEmpleado] TEXT NULL,
    [TipoPermiso]       INT  NULL,
    [FechaPermiso]      DATE NULL
);


