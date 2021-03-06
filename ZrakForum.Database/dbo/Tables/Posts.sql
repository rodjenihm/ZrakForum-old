﻿CREATE TABLE [dbo].[Posts]
(
	[Id]         INT			NOT NULL IDENTITY,
	[CreatedAt]  DATETIME2(7)   NOT NULL DEFAULT GETDATE(),
	[Content]	 NVARCHAR(MAX)  NOT NULL,
	[AuthorId]   INT			NOT NULL DEFAULT 1,
	[ThreadId]   INT			NOT NULL,
	CONSTRAINT [PK_Posts] PRIMARY KEY ([Id] ASC),
	CONSTRAINT [FK_Posts_Accounts] FOREIGN KEY ([AuthorId]) REFERENCES [Accounts](Id) ON DELETE SET DEFAULT,
	CONSTRAINT [FK_Posts_Threads] FOREIGN KEY ([ThreadId]) REFERENCES [Threads](Id) ON DELETE CASCADE
)
