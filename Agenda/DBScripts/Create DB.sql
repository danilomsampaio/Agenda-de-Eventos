USE [AgendaProvaEvolua]
GO
/****** Object:  Table [dbo].[agdCategoriaEvento]    Script Date: 27/11/2017 17:18:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agdCategoriaEvento](
	[agdCategoriaEventoID] [int] IDENTITY(1,1) NOT NULL,
	[aceNome] [varchar](50) NOT NULL,
	[aceCor] [varchar](20) NULL,
 CONSTRAINT [agdCategoriaEvento_PK] PRIMARY KEY CLUSTERED 
(
	[agdCategoriaEventoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[agdContato]    Script Date: 27/11/2017 17:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agdContato](
	[agdContatoID] [int] IDENTITY(1,1) NOT NULL,
	[agdUsuarioID] [int] NULL,
	[actNome] [varchar](100) NOT NULL,
	[actSexo] [bit] NOT NULL,
	[actTelefone] [varchar](20) NULL,
	[actDataNascimento] [date] NOT NULL,
	[actEndereco] [varchar](120) NULL,
	[actFoto] [varchar](200) NULL,
	[actEmail] [varchar](254) NULL,
 CONSTRAINT [agdContato_PK] PRIMARY KEY CLUSTERED 
(
	[agdContatoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [agdContato_Email] UNIQUE NONCLUSTERED 
(
	[actEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[agdEvento]    Script Date: 27/11/2017 17:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agdEvento](
	[agdEventoID] [int] IDENTITY(1,1) NOT NULL,
	[agdContatoID] [int] NOT NULL,
	[aevNome] [varchar](100) NOT NULL,
	[aevFoto] [varchar](200) NULL,
	[aevDataHora] [datetime] NOT NULL,
	[aevLocal] [varchar](200) NOT NULL,
	[aevDescricao] [varchar](1000) NOT NULL,
	[agdCategoriaEventoID] [int] NOT NULL,
 CONSTRAINT [agdEvento_PK] PRIMARY KEY CLUSTERED 
(
	[agdEventoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[agdUsuario]    Script Date: 27/11/2017 17:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agdUsuario](
	[agdUsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[ausEmail] [varchar](254) NOT NULL,
	[ausSenha] [varchar](12) NOT NULL,
 CONSTRAINT [agdUsuario_PK] PRIMARY KEY CLUSTERED 
(
	[agdUsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ausEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[agdContato]  WITH CHECK ADD  CONSTRAINT [agdContato_agdUsuario_FK] FOREIGN KEY([agdUsuarioID])
REFERENCES [dbo].[agdUsuario] ([agdUsuarioID])
GO
ALTER TABLE [dbo].[agdContato] CHECK CONSTRAINT [agdContato_agdUsuario_FK]
GO
ALTER TABLE [dbo].[agdEvento]  WITH CHECK ADD  CONSTRAINT [agdEvento_agdCategoriaEvento_FK] FOREIGN KEY([agdCategoriaEventoID])
REFERENCES [dbo].[agdCategoriaEvento] ([agdCategoriaEventoID])
GO
ALTER TABLE [dbo].[agdEvento] CHECK CONSTRAINT [agdEvento_agdCategoriaEvento_FK]
GO
ALTER TABLE [dbo].[agdEvento]  WITH CHECK ADD  CONSTRAINT [agdEvento_agdContato_FK] FOREIGN KEY([agdContatoID])
REFERENCES [dbo].[agdContato] ([agdContatoID])
GO
ALTER TABLE [dbo].[agdEvento] CHECK CONSTRAINT [agdEvento_agdContato_FK]
GO
/****** Object:  StoredProcedure [dbo].[sp_insereUsuario]    Script Date: 27/11/2017 17:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insereUsuario] @contatoID INT, 
								@email VARCHAR(254),
								@senha VARCHAR(12)
AS

BEGIN 
	INSERT INTO agdUsuario (ausEmail, ausSenha)
	VALUES (@email, @senha)

	DECLARE @usuarioID INT = 0
	
	SELECT @usuarioID = SCOPE_IDENTITY()

	IF(@usuarioID <> 0)
	BEGIN
		UPDATE agdContato 
		SET agdUsuarioID = @usuarioID
		WHERE agdContatoID = @contatoID
	END

END
			
GO
