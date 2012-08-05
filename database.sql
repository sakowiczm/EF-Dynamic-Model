
CREATE TABLE [dbo].[lookup2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](10) NOT NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_lookup2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[lookup1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](10) NOT NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_lookup1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO lookup1(code, [description]) VALUES('A1', 'a one');
INSERT INTO lookup1(code, [description]) VALUES('A2', 'a two');
INSERT INTO lookup1(code, [description]) VALUES('A3', 'a three');
INSERT INTO lookup1(code, [description]) VALUES('A4', 'a four');

INSERT INTO lookup2(code, [description]) VALUES('B1', 'b one');
INSERT INTO lookup2(code, [description]) VALUES('B2', 'b two');
GO