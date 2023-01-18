CREATE TABLE [dbo].[Completed]
(
	[CompletionId] INT NOT NULL PRIMARY KEY Identity, 
    [Time] TIMESTAMP NULL, 
    [pickupID] NCHAR(10) NULL
)
