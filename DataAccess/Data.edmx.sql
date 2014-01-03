
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/03/2014 14:29:36
-- Generated from EDMX file: E:\Project\TalkingRobotSolution\DataAccess\Data.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Robot];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ObjectObjectPropty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Object] DROP CONSTRAINT [FK_ObjectObjectPropty];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjectObjectPropty1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjectPropty] DROP CONSTRAINT [FK_ObjectObjectPropty1];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjectUser_Object]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjectUser] DROP CONSTRAINT [FK_ObjectUser_Object];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjectUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjectUser] DROP CONSTRAINT [FK_ObjectUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionTemplateAnswerTemplate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnswerTemplate] DROP CONSTRAINT [FK_QuestionTemplateAnswerTemplate];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserRelation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRelation] DROP CONSTRAINT [FK_UserUserRelation];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRelationUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserRelationUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjectUserRelation_Object]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjectUserRelation] DROP CONSTRAINT [FK_ObjectUserRelation_Object];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjectUserRelation_UserRelation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjectUserRelation] DROP CONSTRAINT [FK_ObjectUserRelation_UserRelation];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjectUser1_Object]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjectUser1] DROP CONSTRAINT [FK_ObjectUser1_Object];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjectUser1_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjectUser1] DROP CONSTRAINT [FK_ObjectUser1_User];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryObject_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoryObject] DROP CONSTRAINT [FK_CategoryObject_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryObject_Object]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoryObject] DROP CONSTRAINT [FK_CategoryObject_Object];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Category] DROP CONSTRAINT [FK_CategoryCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Object]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Object];
GO
IF OBJECT_ID(N'[dbo].[ObjectPropty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObjectPropty];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[QuestionTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuestionTemplate];
GO
IF OBJECT_ID(N'[dbo].[AnswerTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnswerTemplate];
GO
IF OBJECT_ID(N'[dbo].[UserRelation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRelation];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[ObjectUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObjectUser];
GO
IF OBJECT_ID(N'[dbo].[ObjectUserRelation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObjectUserRelation];
GO
IF OBJECT_ID(N'[dbo].[ObjectUser1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObjectUser1];
GO
IF OBJECT_ID(N'[dbo].[CategoryObject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryObject];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Object'
CREATE TABLE [dbo].[Object] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [Hot] bigint  NOT NULL
);
GO

-- Creating table 'ObjectPropty'
CREATE TABLE [dbo].[ObjectPropty] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Object_Id] bigint  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [QQ] nvarchar(max)  NOT NULL,
    [Birth] datetime  NOT NULL,
    [Height] int  NOT NULL,
    [Weight] int  NOT NULL,
    [Male] bit  NOT NULL,
    [Married] bit  NOT NULL,
    [UserRelationUser_User_Id] int  NOT NULL
);
GO

-- Creating table 'QuestionTemplate'
CREATE TABLE [dbo].[QuestionTemplate] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Regex] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AnswerTemplate'
CREATE TABLE [dbo].[AnswerTemplate] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Answer] nvarchar(max)  NOT NULL,
    [QuestionTemplate_Id] bigint  NOT NULL
);
GO

-- Creating table 'UserRelation'
CREATE TABLE [dbo].[UserRelation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Parent_Id] int  NULL
);
GO

-- Creating table 'ObjectUser'
CREATE TABLE [dbo].[ObjectUser] (
    [LiveCity_Id] bigint  NOT NULL,
    [ObjectUser_Object_Id] int  NOT NULL
);
GO

-- Creating table 'ObjectUserRelation'
CREATE TABLE [dbo].[ObjectUserRelation] (
    [RelationName_Id] bigint  NOT NULL,
    [ObjectUserRelation_Object_Id] int  NOT NULL
);
GO

-- Creating table 'ObjectUser1'
CREATE TABLE [dbo].[ObjectUser1] (
    [Favorites_Id] bigint  NOT NULL,
    [ObjectUser1_Object_Id] int  NOT NULL
);
GO

-- Creating table 'CategoryObject'
CREATE TABLE [dbo].[CategoryObject] (
    [Category_Id] int  NOT NULL,
    [Object_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Object'
ALTER TABLE [dbo].[Object]
ADD CONSTRAINT [PK_Object]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ObjectPropty'
ALTER TABLE [dbo].[ObjectPropty]
ADD CONSTRAINT [PK_ObjectPropty]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuestionTemplate'
ALTER TABLE [dbo].[QuestionTemplate]
ADD CONSTRAINT [PK_QuestionTemplate]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AnswerTemplate'
ALTER TABLE [dbo].[AnswerTemplate]
ADD CONSTRAINT [PK_AnswerTemplate]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserRelation'
ALTER TABLE [dbo].[UserRelation]
ADD CONSTRAINT [PK_UserRelation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LiveCity_Id], [ObjectUser_Object_Id] in table 'ObjectUser'
ALTER TABLE [dbo].[ObjectUser]
ADD CONSTRAINT [PK_ObjectUser]
    PRIMARY KEY NONCLUSTERED ([LiveCity_Id], [ObjectUser_Object_Id] ASC);
GO

-- Creating primary key on [RelationName_Id], [ObjectUserRelation_Object_Id] in table 'ObjectUserRelation'
ALTER TABLE [dbo].[ObjectUserRelation]
ADD CONSTRAINT [PK_ObjectUserRelation]
    PRIMARY KEY NONCLUSTERED ([RelationName_Id], [ObjectUserRelation_Object_Id] ASC);
GO

-- Creating primary key on [Favorites_Id], [ObjectUser1_Object_Id] in table 'ObjectUser1'
ALTER TABLE [dbo].[ObjectUser1]
ADD CONSTRAINT [PK_ObjectUser1]
    PRIMARY KEY NONCLUSTERED ([Favorites_Id], [ObjectUser1_Object_Id] ASC);
GO

-- Creating primary key on [Category_Id], [Object_Id] in table 'CategoryObject'
ALTER TABLE [dbo].[CategoryObject]
ADD CONSTRAINT [PK_CategoryObject]
    PRIMARY KEY NONCLUSTERED ([Category_Id], [Object_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LiveCity_Id] in table 'ObjectUser'
ALTER TABLE [dbo].[ObjectUser]
ADD CONSTRAINT [FK_ObjectUser_Object]
    FOREIGN KEY ([LiveCity_Id])
    REFERENCES [dbo].[Object]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ObjectUser_Object_Id] in table 'ObjectUser'
ALTER TABLE [dbo].[ObjectUser]
ADD CONSTRAINT [FK_ObjectUser_User]
    FOREIGN KEY ([ObjectUser_Object_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjectUser_User'
CREATE INDEX [IX_FK_ObjectUser_User]
ON [dbo].[ObjectUser]
    ([ObjectUser_Object_Id]);
GO

-- Creating foreign key on [QuestionTemplate_Id] in table 'AnswerTemplate'
ALTER TABLE [dbo].[AnswerTemplate]
ADD CONSTRAINT [FK_QuestionTemplateAnswerTemplate]
    FOREIGN KEY ([QuestionTemplate_Id])
    REFERENCES [dbo].[QuestionTemplate]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionTemplateAnswerTemplate'
CREATE INDEX [IX_FK_QuestionTemplateAnswerTemplate]
ON [dbo].[AnswerTemplate]
    ([QuestionTemplate_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserRelation'
ALTER TABLE [dbo].[UserRelation]
ADD CONSTRAINT [FK_UserUserRelation]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserRelation'
CREATE INDEX [IX_FK_UserUserRelation]
ON [dbo].[UserRelation]
    ([User_Id]);
GO

-- Creating foreign key on [UserRelationUser_User_Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_UserRelationUser]
    FOREIGN KEY ([UserRelationUser_User_Id])
    REFERENCES [dbo].[UserRelation]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRelationUser'
CREATE INDEX [IX_FK_UserRelationUser]
ON [dbo].[User]
    ([UserRelationUser_User_Id]);
GO

-- Creating foreign key on [RelationName_Id] in table 'ObjectUserRelation'
ALTER TABLE [dbo].[ObjectUserRelation]
ADD CONSTRAINT [FK_ObjectUserRelation_Object]
    FOREIGN KEY ([RelationName_Id])
    REFERENCES [dbo].[Object]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ObjectUserRelation_Object_Id] in table 'ObjectUserRelation'
ALTER TABLE [dbo].[ObjectUserRelation]
ADD CONSTRAINT [FK_ObjectUserRelation_UserRelation]
    FOREIGN KEY ([ObjectUserRelation_Object_Id])
    REFERENCES [dbo].[UserRelation]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjectUserRelation_UserRelation'
CREATE INDEX [IX_FK_ObjectUserRelation_UserRelation]
ON [dbo].[ObjectUserRelation]
    ([ObjectUserRelation_Object_Id]);
GO

-- Creating foreign key on [Favorites_Id] in table 'ObjectUser1'
ALTER TABLE [dbo].[ObjectUser1]
ADD CONSTRAINT [FK_ObjectUser1_Object]
    FOREIGN KEY ([Favorites_Id])
    REFERENCES [dbo].[Object]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ObjectUser1_Object_Id] in table 'ObjectUser1'
ALTER TABLE [dbo].[ObjectUser1]
ADD CONSTRAINT [FK_ObjectUser1_User]
    FOREIGN KEY ([ObjectUser1_Object_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjectUser1_User'
CREATE INDEX [IX_FK_ObjectUser1_User]
ON [dbo].[ObjectUser1]
    ([ObjectUser1_Object_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'CategoryObject'
ALTER TABLE [dbo].[CategoryObject]
ADD CONSTRAINT [FK_CategoryObject_Category]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Object_Id] in table 'CategoryObject'
ALTER TABLE [dbo].[CategoryObject]
ADD CONSTRAINT [FK_CategoryObject_Object]
    FOREIGN KEY ([Object_Id])
    REFERENCES [dbo].[Object]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryObject_Object'
CREATE INDEX [IX_FK_CategoryObject_Object]
ON [dbo].[CategoryObject]
    ([Object_Id]);
GO

-- Creating foreign key on [Parent_Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [FK_CategoryCategory]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryCategory'
CREATE INDEX [IX_FK_CategoryCategory]
ON [dbo].[Category]
    ([Parent_Id]);
GO

-- Creating foreign key on [Object_Id] in table 'ObjectPropty'
ALTER TABLE [dbo].[ObjectPropty]
ADD CONSTRAINT [FK_ObjectObjectPropty]
    FOREIGN KEY ([Object_Id])
    REFERENCES [dbo].[Object]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjectObjectPropty'
CREATE INDEX [IX_FK_ObjectObjectPropty]
ON [dbo].[ObjectPropty]
    ([Object_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------