USE [EvaluacionQS_BD]
GO

CREATE PROCEDURE SP_GetClientes_A_SinFacturas
AS
BEGIN
	Select 
		C.*
	from Cliente C with(nolock)
		left join Factura F with(nolock) on F.ClienteId = C.ClienteId
	Where C.Categoria = 'A' and F.ClienteId is NULL
END