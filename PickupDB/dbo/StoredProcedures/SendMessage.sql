CREATE PROCEDURE [dbo].[SendMessage]
	@messageID nchar(10),
	@pickupID nchar(10)
	
AS
Begin
	insert into dbo.Incomplete (messageID, pickupID)
	values (@messageID, @pickupID) 
End
