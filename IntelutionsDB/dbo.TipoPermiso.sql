USE [IntelutionsDB]
GO

/****** Objeto: Table [dbo].[TipoPermiso] Fecha del script: 25/10/2020 7:13:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoPermiso] (
    [Id]          INT  IDENTITY (1, 1) NOT NULL,
    [Descripcion] TEXT NULL
);


