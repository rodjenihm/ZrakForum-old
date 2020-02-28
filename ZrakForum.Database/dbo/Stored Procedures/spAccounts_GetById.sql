CREATE PROCEDURE [dbo].[spAccounts_GetById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Accounts]
	WHERE [Id] = @Id;
END
