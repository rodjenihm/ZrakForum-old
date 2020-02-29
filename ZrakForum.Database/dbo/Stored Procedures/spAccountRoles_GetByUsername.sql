CREATE PROCEDURE [dbo].[spAccountRoles_GetByUsername]
	@Username NVARCHAR(30)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @AccountId INT;
	SET @AccountId =
	(
		SELECT [Id] FROM [dbo].[Accounts]
		WHERE [Username] = @Username
 	);

	SELECT [Name] FROM
	[dbo].[AccountRoles]
	JOIN [dbo].[Roles]
	ON ([AccountRoles].[RoleId] = [Roles].[Id])
	WHERE [AccountId] = @AccountId;

END
