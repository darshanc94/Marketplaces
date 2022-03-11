IF db_id('MarketplaceDB') IS NULL 
CREATE DATABASE MarketplaceDB
GO

CREATE TABLE MarketplaceDB.[dbo].[Applicant]
(
	[ApplicantID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(200) NULL, 
    [LastName] VARCHAR(200) NULL, 
    [DateOfBirth] DATETIME NULL, 
    [AnnualIncome] INT NULL
);
CREATE TABLE MarketplaceDB.[dbo].[CreditCards]
(
	[CreditCardID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreditCardName] VARCHAR(100) NULL, 
    [CreditCardApr] DECIMAL NULL, 
    [CreditCardDescription] VARCHAR(200) NULL, 
    [CreditCardMinimumAge] INT NULL, 
    [CreditCardMinimumIncome] INT NULL
);

CREATE TABLE MarketplaceDB.[dbo].[Log] (
    [LogID]              INT NOT NULL PRIMARY KEY IDENTITY, 
    [LogType]            VARCHAR (50)  NULL,
    [ApplicantID]        INT           NULL,
    [LogSubmitted]       DATETIME      NULL,
    [LogRequestStatus]   INT           NULL,
    [CreditCardID]       INT           NULL,
    [LogResponseMessage] VARCHAR (200) NULL,
    [LogRequest] VARCHAR(50) NULL, 
 
);

INSERT INTO MarketplaceDB.[dbo].[Applicant]
    (FirstName, LastName, DateOfBirth,AnnualIncome)
VALUES 
   ('Darshan', 'Chudasama', '1994-05-07', 30000),
   ('Test', 'Underage', '2010-05-07', 50000),
   ('Test', 'LowIncome', '1994-04-07', 10000);

INSERT INTO MarketplaceDB.[dbo].[CreditCards]
    (CreditCardName, CreditCardApr, CreditCardDescription,CreditCardMinimumAge, CreditCardMinimumIncome)
VALUES 
   ('Barclaycard', 2, 'A great credit card for big purchases', 18, 30000),
   ('Vanquis', 4, 'A good starter card for people wanting to need to money fast', 18, 0);

--INSERT INTO  MarketplaceDB.[dbo].[CreditCards] (CreditCardName, CreditCardApr, CreditCardDescription,CreditCardMinimumAge, CreditCardMinimumIncome)
--VALUES ("Barclaycard", 2, "A great credit card for big purchases", 18, 30000);

--INSERT INTO  MarketplaceDB.[dbo].[CreditCards] (CreditCardName, CreditCardApr, CreditCardDescription,CreditCardMinimumAge, CreditCardMinimumIncome)
--VALUES 