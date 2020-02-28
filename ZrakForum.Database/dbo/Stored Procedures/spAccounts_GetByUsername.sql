CREATE PROCEDURE [dbo].[spAccounts_GetByUsername]
	@Username NVARCHAR(30)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Accounts]
	WHERE [Username] = @Username;
END