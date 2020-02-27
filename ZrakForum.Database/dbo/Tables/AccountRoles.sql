CREATE TABLE [dbo].[AccountRoles]
(
	[AccountId]  INT NOT NULL,
	[RoleId]     INT NOT NULL, 
    CONSTRAINT [FK_AccountRoles_Accounts] FOREIGN KEY ([AccountId]) REFERENCES [Accounts]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_AccountRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([Id]) ON DELETE CASCADE
)

GO
CREATE NONCLUSTERED INDEX [IX_AccountRoles_RoleId]
    ON [dbo].[AccountRoles]([RoleId] ASC);