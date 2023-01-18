CREATE PROCEDURE [dbo].[RemoveMessage]
	@ResidentID nchar(10)
AS
Begin
	Delete 
	from dbo.ResidentMessages 
	where ResidentID = @ResidentID; 
End
