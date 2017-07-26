IF OBJECT_ID ('dbo.Chamada') IS NOT NULL
	DROP TABLE dbo.Chamada
GO

IF OBJECT_ID ('dbo.TelefoneContato') IS NOT NULL
	DROP TABLE dbo.TelefoneContato
GO

IF OBJECT_ID ('dbo.Contato') IS NOT NULL
	DROP TABLE dbo.Contato
GO

IF OBJECT_ID ('dbo.Grupo') IS NOT NULL
	DROP TABLE dbo.Grupo
GO

---- Grupo
CREATE TABLE dbo.Grupo
	(
	GrupoId   INT IDENTITY NOT NULL,
	Nome VARCHAR (128) NULL,
	PRIMARY KEY (GrupoId),

	UNIQUE (Nome)
	)
GO

---- Contato
CREATE TABLE dbo.Contato
	(
	ContatoId       INT IDENTITY NOT NULL,
	GrupoId INT NULL,
	Nome     VARCHAR (128) NULL,
	
	PRIMARY KEY (ContatoId),
	CONSTRAINT FK_Contato_Grupo FOREIGN KEY (GrupoId) REFERENCES dbo.Grupo (GrupoId),

	UNIQUE (GrupoId, Nome)
	)
GO

---- Telefone 
CREATE TABLE dbo.TelefoneContato
	(
	TelefoneContatoId         INT IDENTITY NOT NULL,
	ContatoId INT NOT NULL,
	Telefone   VARCHAR (32) NOT NULL,
	
	PRIMARY KEY (TelefoneContatoId),
	CONSTRAINT FK_TelefoneContato_Contato FOREIGN KEY (ContatoId) REFERENCES dbo.Contato (ContatoId),

	UNIQUE (Telefone)
	)
GO


---- CHAMADA
CREATE TABLE dbo.Chamada
	(
	ChamadaId                  INT IDENTITY NOT NULL,
	TelefoneContatoId INT NOT NULL,
	DataHora           DATETIME NOT NULL,
	DuracaoSegundos             INT NULL,
	PRIMARY KEY (ChamadaId),
	CONSTRAINT FK_Chamada_TelefoneContato FOREIGN KEY (TelefoneContatoId) REFERENCES dbo.TelefoneContato (TelefoneContatoId)
	)
GO



