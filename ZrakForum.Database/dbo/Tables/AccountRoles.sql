CREATE TABLE [dbo].[AccountRoles]
(
	[AccountId]     INT NOT NULL,
	[RoleId]        INT NOT NULL, 
    [AssignedAt]    DATETIME2(7) NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_AccountRoles] PRIMARY KEY CLUSTERED ([AccountId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AccountRoles_Accounts] FOREIGN KEY ([AccountId]) REFERENCES [Accounts]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_AccountRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([Id]) ON DELETE CASCADE
)

GO
CREATE NONCLUSTERED INDEX [IX_AccountRoles_AccountId]
    ON [dbo].[AccountRoles]([AccountId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_AccountRoles_RoleId]
    ON [dbo].[AccountRoles]([RoleId] ASC);