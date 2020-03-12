CREATE PROCEDURE [dbo].[spThreads_GetByName]
	@Name NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Threads]
	WHERE [Name] = @Name;
END
