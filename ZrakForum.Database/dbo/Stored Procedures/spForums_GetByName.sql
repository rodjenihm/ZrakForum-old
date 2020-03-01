CREATE PROCEDURE [dbo].[spForums_GetByName]
	@Name NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Forums]
	WHERE [Name] = @Name;
END