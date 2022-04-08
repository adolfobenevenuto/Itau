USE [crp06]
GO

/****** Object:  Table [dbo].[tbl_eventos_perfil_acesso]    Script Date: 08/04/2022 06:43:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_eventos_perfil_acesso](
	[id_perf] [int] IDENTITY(1,1) NOT NULL,
	[contexto] [int] NULL,
	[nome] [varchar](200) NULL,
	[descricao] [varchar](200) NULL,
	[excluido] [bit] NOT NULL,
	[criador] [int] NOT NULL,
	[dt_criacao] [datetime] NOT NULL,
	[atualizador] [int] NOT NULL,
	[dt_atualizacao] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[id_perf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


