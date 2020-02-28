CREATE PROCEDURE [dbo].[spRoles_GetByName]
	@Name NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Roles]
	WHERE [Name] = @Name;
END