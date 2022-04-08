USE [crp06]
GO

/****** Object:  Table [dbo].[tbl_user_eventos_usuario]    Script Date: 08/04/2022 06:39:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_user_eventos_usuario](
	[id_usu] [int] IDENTITY(1,1) NOT NULL,
	[crp] [varchar](15) NULL,
	[cpf] [varchar](25) NOT NULL,
	[nome] [varchar](175) NOT NULL,
	[logon] [varchar](175) NOT NULL,
	[email] [varchar](175) NOT NULL,
	[senha] [varchar](15) NOT NULL,
	[cidade] [varchar](75) NOT NULL,
	[telefone] [varchar](15) NULL,
	[comercial] [varchar](15) NULL,
	[celular] [varchar](15) NULL,
	[instituicao] [varchar](150) NULL,
	[possui_neces] [varchar](5) NOT NULL,
	[baixa_visao] [varchar](5) NULL,
	[cegueira] [varchar](5) NULL,
	[surdez] [varchar](5) NULL,
	[defic_fisica] [varchar](5) NULL,
	[defic_intelectual] [varchar](5) NULL,
	[outra] [varchar](5) NULL,
	[outral_qual] [varchar](150) NULL,
	[neces_atend] [varchar](5) NULL,
	[braille] [varchar](5) NULL,
	[guia] [varchar](5) NULL,
	[libras] [varchar](5) NULL,
	[guia_inter] [varchar](5) NULL,
	[outro_meces] [varchar](5) NULL,
	[qual_atend] [varchar](150) NULL,
	[congresso] [varchar](250) NULL,
	[excluido] [bit] NOT NULL,
	[criador] [int] NOT NULL,
	[dt_criacao] [datetime] NOT NULL,
	[atualizador] [int] NOT NULL,
	[dt_atualizacao] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[id_usu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


