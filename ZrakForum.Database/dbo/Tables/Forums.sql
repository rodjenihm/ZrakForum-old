﻿CREATE TABLE [dbo].[Forums]
(
	[Id]			INT NOT NULL IDENTITY,
	[CreatedAt]		DATETIME2(7)  NOT NULL DEFAULT GETDATE(),
	[Name]			NVARCHAR(255) NOT NULL,
	[Description]	NVARCHAR(MAX),
	CONSTRAINT [PK_Forums] PRIMARY KEY ([Id] ASC) 
)
