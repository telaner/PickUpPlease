CREATE PROCEDURE [dbo].[CompletePickUp]
	@pickupId nchar(10)
AS
Begin
	Insert into dbo.Completed (pickupID)
	values(@pickupId);
End
