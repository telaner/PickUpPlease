CREATE PROCEDURE [dbo].[ViewMessage]
	@Id int
AS
Begin
	Select Message
	From dbo.[Messages], dbo.Incomplete, dbo.PendingPickUp 
	Where Messages.Id = Incomplete.messageID
	And Incomplete.pickupID = PendingPickUp.PickUpId
	And PendingPickUp.ResidentId = @Id;
End
