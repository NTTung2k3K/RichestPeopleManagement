CREATE DATABASE BTN_TopWordRichest;
GO

USE BTN_TopWordRichest;
GO

CREATE TABLE Country (
    CountryId int IDENTITY(1,1) PRIMARY KEY,
    CountryName nvarchar(50)
);

CREATE TABLE Industry (
    IndustryId int IDENTITY(1,1) PRIMARY KEY,
    IndustryName nvarchar(50)
);

CREATE TABLE RichestPerson (
    RichestPersonId int IDENTITY(1,1) PRIMARY KEY,
    Rank int,
    Name nvarchar(50),
    Age int,
    NetWorth decimal(16,2),
    CountryId int,
    IndustryId int,
    FOREIGN KEY (CountryId) REFERENCES Country(CountryId) ON DELETE SET NULL,
    FOREIGN KEY (IndustryId) REFERENCES Industry(IndustryId) ON DELETE SET NULL
);

