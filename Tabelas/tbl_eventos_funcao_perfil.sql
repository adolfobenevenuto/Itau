USE [crp06]
GO

/****** Object:  Table [dbo].[tbl_eventos_funcao_perfil]    Script Date: 08/04/2022 06:43:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_eventos_funcao_perfil](
	[id_fnc] [int] NOT NULL,
	[id_perf] [int] NOT NULL,
	[somente_criador] [bit] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[id_fnc] ASC,
	[id_perf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbl_eventos_funcao_perfil]  WITH CHECK ADD FOREIGN KEY([id_fnc])
REFERENCES [dbo].[tbl_eventos_funcao_sistema] ([id_fnc])
GO

ALTER TABLE [dbo].[tbl_eventos_funcao_perfil]  WITH CHECK ADD FOREIGN KEY([id_perf])
REFERENCES [dbo].[tbl_eventos_perfil_acesso] ([id_perf])
GO


