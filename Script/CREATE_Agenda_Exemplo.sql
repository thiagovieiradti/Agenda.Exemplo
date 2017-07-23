---- Grupo
IF OBJECT_ID ('dbo.Grupo') IS NOT NULL
	DROP TABLE dbo.Grupo
GO

CREATE TABLE dbo.Grupo
	(
	Id   INT IDENTITY NOT NULL,
	Nome VARCHAR (128) NULL,
	PRIMARY KEY (Id)
	)
GO

---- Contato
IF OBJECT_ID ('dbo.Contato') IS NOT NULL
	DROP TABLE dbo.Contato
GO

CREATE TABLE dbo.Contato
	(
	Id       INT IDENTITY NOT NULL,
	GrupoId INT NULL,
	Nome     VARCHAR (128) NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_Contato_Grupo FOREIGN KEY (GrupoId) REFERENCES dbo.Grupo (Id)
	)
GO


---- Telefone 
IF OBJECT_ID ('dbo.TelefoneContato') IS NOT NULL
	DROP TABLE dbo.TelefoneContato
GO

CREATE TABLE dbo.TelefoneContato
	(
	Id         INT IDENTITY NOT NULL,
	ContatoId INT NOT NULL,
	Telefone   VARCHAR (32) NOT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_TelefoneContato_Contato FOREIGN KEY (ContatoId) REFERENCES dbo.Contato (Id)
	)
GO


---- CHAMADA
IF OBJECT_ID ('dbo.Chamada') IS NOT NULL
	DROP TABLE dbo.Chamada
GO

CREATE TABLE dbo.Chamada
	(
	Id                  INT IDENTITY NOT NULL,
	TelefoneContatoId INT NOT NULL,
	DataHora           DATETIME NOT NULL,
	DuracaoSegundos             INT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_Chamada_TelefoneContato FOREIGN KEY (TelefoneContatoId) REFERENCES dbo.TelefoneContato (Id)
	)
GO



