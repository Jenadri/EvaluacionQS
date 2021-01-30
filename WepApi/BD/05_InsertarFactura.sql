USE [EvaluacionQS_BD]
GO
CREATE PROCEDURE SP_InsertFactura
	@VendedorId int,
	@ClienteId int,
	@Fecha date,
	@Moneda char(3)
AS
BEGIN TRY
	DECLARE @intDato AS INT
	DECLARE @strSerie AS VARCHAR(50)
	DECLARE @strCodigo AS VARCHAR(5) = 'FACT'
	DECLARE @FacturaId as INT

	SET @strSerie=(Select MAX(Serie) from Factura)

	SET @intDato=CONVERT(INT,@strSerie)

	--Sumamos 1 al número
	SET @intDato=@intDato+1

	SET @strSerie=REPLICATE('0',3-LEN(LTRIM(RTRIM(CONVERT(VARCHAR,@intDato)))))+CONVERT(VARCHAR,@intDato)

	INSERT INTO Factura
			   (Serie
			   ,Codigo
			   ,VendedorId
			   ,ClienteId
			   ,Fecha
			   ,Moneda)
		 VALUES
			   (@strSerie
			   ,@strCodigo
			   ,@VendedorId
			   ,@ClienteId
			   ,@Fecha
			   ,@Moneda)

	SET @FacturaId = SCOPE_IDENTITY()
	
	SELECT 'OK' AS 'STATUS', @FacturaId AS 'FacturaId', '' as MENSAJE
END TRY
BEGIN CATCH
	SELECT 'NOK' AS 'STATUS', 0 as 'ID', ERROR_MESSAGE() as MENSAJE 
END CATCH