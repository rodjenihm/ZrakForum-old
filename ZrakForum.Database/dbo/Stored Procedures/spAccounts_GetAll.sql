CREATE PROCEDURE [dbo].[spAccounts_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Accounts];
END