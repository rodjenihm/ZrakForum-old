CREATE TABLE [dbo].[Threads]
(
	[Id]			INT				NOT NULL,
	[CreatedAt]		DATETIME2(7)    NOT NULL DEFAULT GETDATE(),
	[Name]			NVARCHAR(255)	NOT NULL,
	[AuthorId]		INT				NOT NULL DEFAULT 1,
	[ForumId]		INT				NOT NULL,
    CONSTRAINT [PK_Threads] PRIMARY KEY ([Id] ASC),
	CONSTRAINT [FK_Threads_Accounts] FOREIGN KEY ([AuthorId]) REFERENCES [Accounts]([Id]) ON DELETE SET DEFAULT,
	CONSTRAINT [FK_Threads_Forums] FOREIGN KEY ([ForumId]) REFERENCES [Forums]([Id]) ON DELETE CASCADE
)

GO
CREATE NONCLUSTERED INDEX [IX_Threads_AuthorId]
    ON [dbo].[Threads]([AuthorId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Threads_FOrumId]
    ON [dbo].[Threads]([ForumId] ASC);