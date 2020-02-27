CREATE TABLE [dbo].[Accounts]
(
	[Id]			INT			  NOT NULL,
	[CreatedAt]		DATETIME2(7)  NOT NULL DEFAULT GETDATE(),
	[Email]			NVARCHAR(255) NOT NULL,
	[Username]		NVARCHAR(30)  NOT NULL,
	[PasswordHash]	NVARCHAR(48)  NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY ([Id] ASC)
)

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Accounts_Username]
	ON [dbo].[Accounts] ([Username] ASC)