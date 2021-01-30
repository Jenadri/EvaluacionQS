USE [EvaluacionQS_BD]
GO
CREATE PROCEDURE SP_InsertDetalleFactura
	@FacturaId int,
	@ProductoId int,
	@Cantidad int,
	@PrecioUnitario decimal(18,5)
AS
BEGIN TRY
	DECLARE @DetalleFacturaId as INT

	INSERT INTO DetalleFactura
			   (FacturaId
			   ,ProductoId
			   ,Cantidad
			   ,PrecioUnitario)
		 VALUES
			   (@FacturaId
			   ,@ProductoId
			   ,@Cantidad
			   ,@PrecioUnitario)

	SET @DetalleFacturaId = SCOPE_IDENTITY()
	
	SELECT 'OK' AS 'STATUS', @DetalleFacturaId AS 'DetalleFacturaId', '' as MENSAJE
END TRY
BEGIN CATCH
	SELECT 'NOK' AS 'STATUS', 0 as 'ID', ERROR_MESSAGE() as MENSAJE 
END CATCH