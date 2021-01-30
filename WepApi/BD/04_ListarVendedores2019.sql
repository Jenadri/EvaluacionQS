USE [EvaluacionQS_BD]
GO

CREATE PROCEDURE SP_GetVendedor2019
AS
BEGIN
	Select * from Vendedor with(nolock)
	Where DATENAME(YEAR, FechaIngreso) = 2019
END