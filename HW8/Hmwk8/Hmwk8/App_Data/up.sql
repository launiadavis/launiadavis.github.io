CREATE TABLE [dbo].[Buyers]
(
	[ID]			INT IDENTITY (1,1)		NOT NULL,
	[BuyerNAME]		NVARCHAR (80)			NOT NULL,
	
	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Sellers]
(
	[ID]			INT IDENTITY (1,1)		NOT NULL,
	[SellerNAME]	NVARCHAR (80)			NOT NULL,

	CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Items]
(
	[ID]				INT IDENTITY (1001,1)		NOT NULL,
	[ItemNAME]			NVARCHAR (100)				NOT NULL,
	[ItemDESCRIPTION]	NVARCHAR (200)				NOT NULL,
	[SellerID]			INT							NOT NULL,

	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Items] FOREIGN KEY (SellerID) REFERENCES [dbo].[Sellers]([ID])
);

CREATE TABLE [dbo].[Bids]
(
	[ID]			INT IDENTITY (1,1)			NOT NULL,
	[ItemID]		INT 						NOT NULL,
	[BuyerID]		INT 						NOT NULL,
	[BidPRICE]		DECIMAL						NOT NULL,
	[BidTIMESTAMP]	DATETIME					NOT NULL,

	CONSTRAINT [pk_dbo.Bids] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Bids] FOREIGN KEY (ItemID) REFERENCES [dbo].[Items]([ID]),
	CONSTRAINT [FK2_dbo.Bids] FOREIGN KEY (BuyerID) REFERENCES [dbo].[Buyers]([ID])
);

INSERT INTO [dbo].[Buyers] (BuyerNAME) VALUES
	('Jane Stone'),
	('Tom McMasters'),
	('Otto Vanderwall');

INSERT INTO [dbo].[Sellers] (SellerNAME) VALUES
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene');

INSERT INTO [dbo].[Items] (ItemNAME, ItemDESCRIPTION, SellerID) VALUES
	('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 3),
	('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 1),
	('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 2);

INSERT INTO [dbo].[Bids] (ItemID, BuyerID, BidPRICE, BidTIMESTAMP) VALUES
	(1001, 3, 250000, '12/04/2017 09:04:22'),
	(1003, 1, 95000, '12/04/2017 08:44:03');
GO