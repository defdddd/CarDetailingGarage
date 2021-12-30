CREATE PROCEDURE SearchPersonUserName
	@UserName varchar(255) 

AS
	select * from Person where UserName = @UserName; 
RETURN 0
