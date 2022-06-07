
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/07/2022 14:16:18
-- Generated from EDMX file: H:\Project\Models\BookManagementModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BookManagement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Book__AuthorId__32E0915F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Book] DROP CONSTRAINT [FK__Book__AuthorId__32E0915F];
GO
IF OBJECT_ID(N'[dbo].[FK__Book__BookStatus__38996AB5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Book] DROP CONSTRAINT [FK__Book__BookStatus__38996AB5];
GO
IF OBJECT_ID(N'[dbo].[FK__Book__CategoryId__37A5467C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Book] DROP CONSTRAINT [FK__Book__CategoryId__37A5467C];
GO
IF OBJECT_ID(N'[dbo].[FK__Book__ReadingId__33D4B598]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Book] DROP CONSTRAINT [FK__Book__ReadingId__33D4B598];
GO
IF OBJECT_ID(N'[dbo].[FK__Book__UserId__31EC6D26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Book] DROP CONSTRAINT [FK__Book__UserId__31EC6D26];
GO
IF OBJECT_ID(N'[dbo].[FK__Borrow__BookId__36B12243]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Borrow] DROP CONSTRAINT [FK__Borrow__BookId__36B12243];
GO
IF OBJECT_ID(N'[dbo].[FK__Borrow__BookStat__35BCFE0A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Borrow] DROP CONSTRAINT [FK__Borrow__BookStat__35BCFE0A];
GO
IF OBJECT_ID(N'[dbo].[FK__ReadingLi__UserI__34C8D9D1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReadingList] DROP CONSTRAINT [FK__ReadingLi__UserI__34C8D9D1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Author]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Author];
GO
IF OBJECT_ID(N'[dbo].[Book]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Book];
GO
IF OBJECT_ID(N'[dbo].[BookStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookStatus];
GO
IF OBJECT_ID(N'[dbo].[Borrow]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Borrow];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Reading]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reading];
GO
IF OBJECT_ID(N'[dbo].[ReadingList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReadingList];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [AuthorId] int IDENTITY(1,1) NOT NULL,
    [AuthorName] nvarchar(255)  NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [BookId] int IDENTITY(1,1) NOT NULL,
    [BookName] nvarchar(255)  NULL,
    [AuthorId] int  NULL,
    [CategoryId] int  NULL,
    [BuyingDate] datetime  NULL,
    [ReadingId] int  NULL,
    [LendStatus] nvarchar(255)  NULL,
    [Photo] nvarchar(max)  NULL,
    [UserId] int  NULL,
    [BookStatusId] int  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [BorrowerName] nvarchar(255)  NULL,
    [BorrowDate] datetime  NULL
);
GO

-- Creating table 'BookStatus'
CREATE TABLE [dbo].[BookStatus] (
    [BookStatusId] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(255)  NULL
);
GO

-- Creating table 'Borrows'
CREATE TABLE [dbo].[Borrows] (
    [BorrowID] int IDENTITY(1,1) NOT NULL,
    [BookId] int  NULL,
    [BorrowerName] nvarchar(255)  NULL,
    [BorrowDate] datetime  NULL,
    [ReturnDate] datetime  NULL,
    [BookStatusId] int  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryId] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(255)  NULL
);
GO

-- Creating table 'Readings'
CREATE TABLE [dbo].[Readings] (
    [ReadingId] int IDENTITY(1,1) NOT NULL,
    [ReadingStatus] nvarchar(255)  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL
);
GO

-- Creating table 'ReadingLists'
CREATE TABLE [dbo].[ReadingLists] (
    [ReadingListId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [BookId] int  NULL,
    [Total] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(255)  NULL,
    [LastName] nvarchar(255)  NULL,
    [Username] nvarchar(255)  NULL,
    [Email] nvarchar(255)  NULL,
    [Password] nvarchar(255)  NULL,
    [PassCode] nvarchar(255)  NULL,
    [Photo] nvarchar(max)  NULL,
    [RegDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AuthorId] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([AuthorId] ASC);
GO

-- Creating primary key on [BookId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([BookId] ASC);
GO

-- Creating primary key on [BookStatusId] in table 'BookStatus'
ALTER TABLE [dbo].[BookStatus]
ADD CONSTRAINT [PK_BookStatus]
    PRIMARY KEY CLUSTERED ([BookStatusId] ASC);
GO

-- Creating primary key on [BorrowID] in table 'Borrows'
ALTER TABLE [dbo].[Borrows]
ADD CONSTRAINT [PK_Borrows]
    PRIMARY KEY CLUSTERED ([BorrowID] ASC);
GO

-- Creating primary key on [CategoryId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [ReadingId] in table 'Readings'
ALTER TABLE [dbo].[Readings]
ADD CONSTRAINT [PK_Readings]
    PRIMARY KEY CLUSTERED ([ReadingId] ASC);
GO

-- Creating primary key on [ReadingListId] in table 'ReadingLists'
ALTER TABLE [dbo].[ReadingLists]
ADD CONSTRAINT [PK_ReadingLists]
    PRIMARY KEY CLUSTERED ([ReadingListId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AuthorId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Book__AuthorId__32E0915F]
    FOREIGN KEY ([AuthorId])
    REFERENCES [dbo].[Authors]
        ([AuthorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Book__AuthorId__32E0915F'
CREATE INDEX [IX_FK__Book__AuthorId__32E0915F]
ON [dbo].[Books]
    ([AuthorId]);
GO

-- Creating foreign key on [CategoryId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Book__CategoryId__37A5467C]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Book__CategoryId__37A5467C'
CREATE INDEX [IX_FK__Book__CategoryId__37A5467C]
ON [dbo].[Books]
    ([CategoryId]);
GO

-- Creating foreign key on [ReadingId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Book__ReadingId__33D4B598]
    FOREIGN KEY ([ReadingId])
    REFERENCES [dbo].[Readings]
        ([ReadingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Book__ReadingId__33D4B598'
CREATE INDEX [IX_FK__Book__ReadingId__33D4B598]
ON [dbo].[Books]
    ([ReadingId]);
GO

-- Creating foreign key on [UserId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Book__UserId__31EC6D26]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Book__UserId__31EC6D26'
CREATE INDEX [IX_FK__Book__UserId__31EC6D26]
ON [dbo].[Books]
    ([UserId]);
GO

-- Creating foreign key on [BookId] in table 'Borrows'
ALTER TABLE [dbo].[Borrows]
ADD CONSTRAINT [FK__Borrow__BookId__36B12243]
    FOREIGN KEY ([BookId])
    REFERENCES [dbo].[Books]
        ([BookId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Borrow__BookId__36B12243'
CREATE INDEX [IX_FK__Borrow__BookId__36B12243]
ON [dbo].[Borrows]
    ([BookId]);
GO

-- Creating foreign key on [BookStatusId] in table 'Borrows'
ALTER TABLE [dbo].[Borrows]
ADD CONSTRAINT [FK__Borrow__BookStat__35BCFE0A]
    FOREIGN KEY ([BookStatusId])
    REFERENCES [dbo].[BookStatus]
        ([BookStatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Borrow__BookStat__35BCFE0A'
CREATE INDEX [IX_FK__Borrow__BookStat__35BCFE0A]
ON [dbo].[Borrows]
    ([BookStatusId]);
GO

-- Creating foreign key on [UserId] in table 'ReadingLists'
ALTER TABLE [dbo].[ReadingLists]
ADD CONSTRAINT [FK__ReadingLi__UserI__34C8D9D1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ReadingLi__UserI__34C8D9D1'
CREATE INDEX [IX_FK__ReadingLi__UserI__34C8D9D1]
ON [dbo].[ReadingLists]
    ([UserId]);
GO

-- Creating foreign key on [BookStatusId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Book__BookStatus__38996AB5]
    FOREIGN KEY ([BookStatusId])
    REFERENCES [dbo].[BookStatus]
        ([BookStatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Book__BookStatus__38996AB5'
CREATE INDEX [IX_FK__Book__BookStatus__38996AB5]
ON [dbo].[Books]
    ([BookStatusId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------