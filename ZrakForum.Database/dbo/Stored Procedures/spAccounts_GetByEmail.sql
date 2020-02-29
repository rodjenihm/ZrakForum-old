CREATE PROCEDURE [dbo].[spAccounts_GetByEmail]
	@Email NVARCHAR(30)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Accounts]
	WHERE [Email] = @Email;
END