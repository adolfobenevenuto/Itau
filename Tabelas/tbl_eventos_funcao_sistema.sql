USE [crp06]
GO

/****** Object:  Table [dbo].[tbl_eventos_funcao_sistema]    Script Date: 08/04/2022 06:43:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_eventos_funcao_sistema](
	[id_fnc] [int] IDENTITY(1,1) NOT NULL,
	[contexto] [int] NULL,
	[classe] [varchar](30) NOT NULL,
	[operacao] [varchar](30) NOT NULL,
	[nome] [varchar](50) NULL,
	[descricao] [varchar](255) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[id_fnc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


