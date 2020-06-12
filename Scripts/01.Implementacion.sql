CREATE TABLE [dbo].[AuditoriaWS](
	[AuditoriaWSId] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](20) NULL,
	[FechaHora] [datetime] NULL,
	[TipoDoc] [varchar](10) NULL,
	[NroDoc] [float] NULL,
	[Respuesta] [varchar](100) NULL,
 CONSTRAINT [PK_AuditoriaWS] PRIMARY KEY CLUSTERED 
(
	[AuditoriaWSId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Test](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[Test]([Fecha]) VALUES('18000101')
GO

CREATE FUNCTION [dbo].[TipoDoc] (@TipoDoc TINYINT)
RETURNS VARCHAR(4)
AS
BEGIN
	DECLARE @Ret AS VARCHAR(4)
	SET @Ret = '...'

	IF @TipoDoc = 1
		SET @Ret = 'LE'
	
	IF @TipoDoc = 2
		SET @Ret = 'LC'

	IF @TipoDoc = 3
		SET @Ret = 'CI'

	IF @TipoDoc = 4
		SET @Ret = 'Pas.'

	IF @TipoDoc = 5
		SET @Ret = 'DNI'

	IF @TipoDoc = 6
		SET @Ret = 'E/T'

	RETURN @Ret
END

GO

CREATE FUNCTION [dbo].[Cobertura] (@Correlativo FLOAT)
RETURNS VARCHAR(25)
AS
BEGIN
	DECLARE @Cobertura AS VARCHAR(25)
	
	SELECT @Cobertura = CASE Condicion WHEN 'Si' THEN 'CON Acceso a Cobertura' WHEN 'Ap' THEN 'CON Acceso a Cobertura' WHEN 'No' THEN 'SIN Acceso a Cobertura' END 
	FROM AfiBeneficiariosOspep WHERE CORRELATIVO = @Correlativo
	
	RETURN @Cobertura
END

GO










