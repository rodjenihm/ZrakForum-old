CREATE PROCEDURE [dbo].[spAccounts_Create]
	@Email			NVARCHAR(255),
	@Username		NVARCHAR(30),
	@PasswordHash   NVARCHAR(48)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO	[dbo].[Accounts]
	([Email], [Username], [PasswordHash])
	VALUES
	(@Email, @Username, @PasswordHash);
END