CREATE PROCEDURE [dbo].[spAccount_GetAll]
AS
BEGIN
	SELECT Id, FirstName, LastName 
	FROM dbo.[Account];
END