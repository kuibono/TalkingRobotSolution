
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/08/2014 16:55:29
-- Generated from EDMX file: E:\Project\TalkingRobotSolution\DataAccess\Data2.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Word'
CREATE TABLE [dbo].[Word] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Length] int  NOT NULL,
    [cn] bit  NOT NULL,
    [an] bit  NOT NULL,
    [on] bit  NOT NULL,
    [pp] bit  NOT NULL,
    [dp] bit  NOT NULL,
    [qp] bit  NOT NULL,
    [tv] bit  NOT NULL,
    [iv] bit  NOT NULL,
    [cv] bit  NOT NULL,
    [nv] bit  NOT NULL,
    [wv] bit  NOT NULL,
    [dv] bit  NOT NULL,
    [adjn] bit  NOT NULL,
    [adjs] bit  NOT NULL,
    [bno] bit  NOT NULL,
    [ono] bit  NOT NULL,
    [cno] bit  NOT NULL,
    [mno] bit  NOT NULL,
    [ano] bit  NOT NULL,
    [nq] bit  NOT NULL,
    [vq] bit  NOT NULL,
    [advd] bit  NOT NULL,
    [advr] bit  NOT NULL,
    [advt] bit  NOT NULL,
    [advn] bit  NOT NULL,
    [prer] bit  NOT NULL,
    [pred] bit  NOT NULL,
    [prere] bit  NOT NULL,
    [prepu] bit  NOT NULL,
    [prec] bit  NOT NULL,
    [pree] bit  NOT NULL,
    [conu] bit  NOT NULL,
    [conp] bit  NOT NULL,
    [pars] bit  NOT NULL,
    [part] bit  NOT NULL,
    [parm] bit  NOT NULL,
    [inth] bit  NOT NULL,
    [ints] bit  NOT NULL,
    [inta] bit  NOT NULL,
    [intsu] bit  NOT NULL,
    [intc] bit  NOT NULL,
    [intr] bit  NOT NULL,
    [oo] bit  NOT NULL,
    [favor] int  NOT NULL,
    [happy] int  NOT NULL,
    [anger] int  NOT NULL,
    [Regex] nvarchar(max)  NOT NULL,
    [ZhuWei] bit  NOT NULL,
    [DongBin] bit  NOT NULL,
    [PianZhengDingZhong] bit  NOT NULL,
    [PianZhengZhuangZhong] bit  NOT NULL,
    [ZhongBu] bit  NOT NULL,
    [LianHe] bit  NOT NULL,
    [LianWei] bit  NOT NULL,
    [JianYu] bit  NOT NULL,
    [TongWei] bit  NOT NULL,
    [FangWei] bit  NOT NULL
);
GO

-- Creating table 'SentenceTemplateSet'
CREATE TABLE [dbo].[SentenceTemplateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Expression] nvarchar(max)  NOT NULL,
    [IsStatement] bit  NOT NULL,
    [IsInterrogative] bit  NOT NULL,
    [IsImperatives] bit  NOT NULL,
    [IsExclamatory] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Word'
ALTER TABLE [dbo].[Word]
ADD CONSTRAINT [PK_Word]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SentenceTemplateSet'
ALTER TABLE [dbo].[SentenceTemplateSet]
ADD CONSTRAINT [PK_SentenceTemplateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------