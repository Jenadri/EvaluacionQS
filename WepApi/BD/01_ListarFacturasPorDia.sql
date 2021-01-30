USE [EvaluacionQS_BD]
GO
CREATE PROCEDURE SP_GetFacturasByDay
AS
BEGIN
	Select F.*,
		DATENAME(DW, Fecha) as Dia,
		SUM(DF.PrecioUnitario) Importe,
		CONCAT(C.Nombres, ' ', C.Apellidos) NombreCliente,
		CONCAT(V.Nombres, ' ', V.Apellidos) NombreVendedor
	from Factura F with(nolock)
		inner join DetalleFactura DF with(nolock) on F.FacturaId = DF.FacturaId
		inner join Cliente C with(nolock) on C.ClienteId = F.ClienteId
		inner join Vendedor V with(nolock) on V.VendedorId = F.VendedorId
	group by F.FacturaId, F.Serie, F.Codigo, F.VendedorId, F.ClienteId, F.Fecha, F.Moneda, C.Nombres, C.Apellidos, V.Nombres, V.Apellidos
	order by F.Fecha, Importe asc
END