USE [EvaluacionQS_BD]
GO

CREATE PROCEDURE SP_GetProductos
AS
BEGIN
	Select * from Producto with(nolock)
END