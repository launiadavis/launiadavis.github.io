ALTER TABLE Items DROP CONSTRAINT [FK_dbo.Items];
ALTER TABLE Bids DROP CONSTRAINT [FK_dbo.Bids];
ALTER TABLE Bids DROP CONSTRAINT [FK2_dbo.Bids];

DROP TABLE [dbo].[Buyers];
DROP TABLE [dbo].[Sellers];
DROP TABLE [dbo].[Items];
DROP TABLE [dbo].[Bids];