
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/29/2023 09:21:36
-- Generated from EDMX file: C:\Users\jan\Desktop\Git\pppk-projekt\Apartments\NewModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NewApartments];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Apartments'
CREATE TABLE [dbo].[Apartments] (
    [IDApartment] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(50)  NOT NULL,
    [City] nvarchar(20)  NOT NULL,
    [Contact] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'UploadedFiles'
CREATE TABLE [dbo].[UploadedFiles] (
    [IDUploadedFile] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ContentType] nvarchar(20)  NOT NULL,
    [Content] varbinary(max)  NOT NULL,
    [ApartmentID] int  NOT NULL
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [IDReview] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [ApartmentID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDApartment] in table 'Apartments'
ALTER TABLE [dbo].[Apartments]
ADD CONSTRAINT [PK_Apartments]
    PRIMARY KEY CLUSTERED ([IDApartment] ASC);
GO

-- Creating primary key on [IDUploadedFile] in table 'UploadedFiles'
ALTER TABLE [dbo].[UploadedFiles]
ADD CONSTRAINT [PK_UploadedFiles]
    PRIMARY KEY CLUSTERED ([IDUploadedFile] ASC);
GO

-- Creating primary key on [IDReview] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([IDReview] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ApartmentID] in table 'UploadedFiles'
ALTER TABLE [dbo].[UploadedFiles]
ADD CONSTRAINT [FK_ApartmentUploadedFile]
    FOREIGN KEY ([ApartmentID])
    REFERENCES [dbo].[Apartments]
        ([IDApartment])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartmentUploadedFile'
CREATE INDEX [IX_FK_ApartmentUploadedFile]
ON [dbo].[UploadedFiles]
    ([ApartmentID]);
GO

-- Creating foreign key on [ApartmentID] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_ApartmentReview]
    FOREIGN KEY ([ApartmentID])
    REFERENCES [dbo].[Apartments]
        ([IDApartment])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ApartmentReview'
CREATE INDEX [IX_FK_ApartmentReview]
ON [dbo].[Reviews]
    ([ApartmentID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------