CREATE PROCEDURE [dbo].[spRoles_Create]
	@Name NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Roles]
	([Name])
	VALUES
	(@Name);
END
