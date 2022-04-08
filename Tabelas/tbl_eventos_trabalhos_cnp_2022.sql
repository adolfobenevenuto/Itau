USE [crp06]
GO

/****** Object:  Table [dbo].[tbl_eventos_trabalhos_cnp_2022]    Script Date: 08/04/2022 07:02:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_eventos_trabalhos_cnp_2022](
	[id_trab] [int] IDENTITY(1,1) NOT NULL,
	[id_usu] [int] NOT NULL,
	[evento] [varchar](255) NOT NULL,
	[regiao] [varchar](255) NOT NULL,
	[eixo] [varchar](255) NOT NULL,
	[ambito] [varchar](150) NULL,
	[palavra1] [varchar](150) NULL,
	[palavra2] [varchar](150) NULL,
	[palavra3] [varchar](150) NULL,
	[proposta] [varchar](4000) NOT NULL,
	[status] [varchar](25) NULL,
	[excluido] [bit] NOT NULL,
	[criador] [int] NULL,
	[dt_criacao] [datetime] NULL,
	[atualizador] [int] NULL,
	[dt_atualizacao] [datetime] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


