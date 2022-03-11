# Marketplace

## Setting up DB

I have chosen to use a local sql database for this project. Unfortunately this comes with a tiny bit of setup. I have outlined the process below. 

### Step 1: Open project and go to SQL Server Object Explorer Window

![image](https://user-images.githubusercontent.com/61197838/157852015-db6ab1e6-d73c-4bb2-ae67-84ed9797ed55.png)

### Step 2: Right click on "New Query" on the "(localdb)\ProjectModels"

Paste the query below into the window

```
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


```
Paste the query below into the window

![image](https://user-images.githubusercontent.com/61197838/157853345-363070ea-10d4-4457-bf01-6cf9d04bf7a2.png)

Execute the query by pressing the green play button. 

### Step 3: The app should now be ready for use!
The script should create the MarketplaceDB. 
The script should create 3 tables; Applcant, CreditCards and Log. 
I have preloaded Credit Card and some Applicant data but you can remove this if you want!

## Todo
### Testing Layer
I did not have the time to add a testing layer. I would have used Moq and NSubstitute for unit testing and asserts to check data. 

### Middleware
Instead of using ActionAttributes to capture requests and log them, I would have used a custom middleware so that I can make it dynamic to the requests coming in. 
