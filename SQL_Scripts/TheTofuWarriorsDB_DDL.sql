
--use master;
--go

--CREATE DATABASE TheTofuWarriorsDB;
--go

use TheTofuWarriorsDB;
go


DROP TABLE IF EXISTS App.Comment;
go
DROP TABLE IF EXISTS App.Rating;
go
DROP TABLE IF EXISTS App.UserRecipe;
go
DROP TABLE IF EXISTS App.RecipeIngredient;
go
DROP TABLE IF EXISTS App.Ingredient;
go
DROP TABLE IF EXISTS App.MeasureUnit;
go
DROP TABLE IF EXISTS App.RecipeTag;
go
DROP TABLE IF EXISTS App.Tag;
go
DROP TABLE IF EXISTS App.[Following];
go
DROP TABLE IF EXISTS App.Recipe;
go
DROP TABLE IF EXISTS App.[User];
go

DROP SCHEMA IF EXISTS App;
go

CREATE SCHEMA App;
go

CREATE TABLE App.MeasureUnit (
	MeasureUnitId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_MeasureUnit PRIMARY KEY (MeasureUnitId)
	,Unit NVARCHAR(100) NOT NULL CONSTRAINT UNQ_MeasureUnit_Name UNIQUE (Unit)
	,[Description] NVARCHAR(100)
);

CREATE TABLE App.[User] (
	UserId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_User PRIMARY KEY (UserId)
	,FirstName NVARCHAR(100) NOT NULL
	,LastName NVARCHAR(100) NOT NULL
	,Email NVARCHAR(100) NOT NULL CONSTRAINT UNQ_User_Email UNIQUE (Email)
	,Username NVARCHAR(100) NOT NULL CONSTRAINT UNQ_User_Username UNIQUE (Username)
	,[Password] NVARCHAR(100) NOT NULL
);

CREATE TABLE App.Recipe (
	RecipeId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_Recipe PRIMARY KEY (RecipeId)
	,CreatorUserId INTEGER NOT NULL CONSTRAINT FK_Recipe_User FOREIGN KEY (CreatorUserId) REFERENCES App.[User]
	,[Name] NVARCHAR(100) NOT NULL
	,Instructions NVARCHAR(MAX)
	,CreationTime DATETIME2 NOT NULL
);

CREATE TABLE App.UserRecipe (
	UserRecipeId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_UserRecipe PRIMARY KEY (UserRecipeId)
	,UserId INTEGER NOT NULL CONSTRAINT FK_UserRecipe_User FOREIGN KEY (UserId) REFERENCES App.[User]
	,RecipeId INTEGER NULL CONSTRAINT FK_UserRecipe_Recipe FOREIGN KEY (RecipeId) REFERENCES App.Recipe
	,ApiRecipeKey INTEGER NULL
);

CREATE TABLE App.Rating (
	RatingId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_Rating PRIMARY KEY (RatingId)
	,UserId INTEGER NOT NULL CONSTRAINT FK_Rating_User FOREIGN KEY (UserId) REFERENCES App.[User]
	,RecipeId INTEGER NOT NULL CONSTRAINT FK_Rating_Recipe FOREIGN KEY (RecipeId) REFERENCES App.Recipe
	,Score TINYINT NOT NULL
	,CONSTRAINT UNQ_Rating_UserId_RecipeId UNIQUE (UserId, RecipeId)
);

CREATE TABLE App.Ingredient (
	IngredientId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_Ingredient PRIMARY KEY (IngredientId)
	,[Name] NVARCHAR(100) NOT NULL CONSTRAINT UNQ_Ingredient_Name UNIQUE ([Name])
	,[Description] NVARCHAR(100)
);

CREATE TABLE App.RecipeIngredient (
	RecipeIngredientId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_RecipeIngredient PRIMARY KEY (RecipeIngredientId)
	,RecipeId INTEGER NOT NULL CONSTRAINT FK_RecipeIngredient_Recipe FOREIGN KEY (RecipeId) REFERENCES App.Recipe
	,IngredientId INTEGER NOT NULL CONSTRAINT FK_RecipeIngredient_Ingredient FOREIGN KEY (IngredientId) REFERENCES App.Ingredient
	,Quantity INTEGER NOT NULL
	,MeasureUnitId INTEGER NOT NULL CONSTRAINT FK_RecipeIngredient_MeasureUnit FOREIGN KEY (MeasureUnitId) REFERENCES App.MeasureUnit
);

CREATE TABLE App.Tag (
	TagId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_Tag PRIMARY KEY (TagId)
	,[Name] NVARCHAR(100) NOT NULL
	,TagType SMALLINT
);

CREATE TABLE App.RecipeTag (
	RecipeTagId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_RecipeTag PRIMARY KEY (RecipeTagId)
	,TagId INTEGER NOT NULL CONSTRAINT FK_RecipeTag_Tag FOREIGN KEY (TagId) REFERENCES App.Tag
	,RecipeId INTEGER NOT NULL CONSTRAINT FK_RecipeTag_Recipe FOREIGN KEY (RecipeId) REFERENCES App.Recipe
	,CONSTRAINT UNQ_RecipeTag_TagId_RecipeId UNIQUE (TagId, RecipeId)
);

CREATE TABLE App.Comment (
	CommentId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_Comment PRIMARY KEY (CommentId)
	,UserId INTEGER NOT NULL CONSTRAINT FK_Comment_User FOREIGN KEY (UserId) REFERENCES App.[User]
	,RecipeId INTEGER NOT NULL CONSTRAINT FK_Comment_Recipe FOREIGN KEY (RecipeId) REFERENCES App.Recipe
	,CommentText NVARCHAR(500) NOT NULL
	,CommentTime DATETIME2 NOT NULL
	,PrevCommentId INTEGER NULL CONSTRAINT FK_Comment_Comment FOREIGN KEY (PrevCommentId) REFERENCES App.Comment
);

CREATE TABLE App.[Following] (
	FollowingId INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_Following PRIMARY KEY (FollowingId)
	,FollowerId INTEGER NOT NULL CONSTRAINT FK_Following_FollowerUser FOREIGN KEY (FollowerId) REFERENCES App.[User]
	,InfluencerId INTEGER NOT NULL CONSTRAINT FK_Following_InfluencerUser FOREIGN KEY (InfluencerId) REFERENCES App.[User]
	,CONSTRAINT UNQ_Following_FollowerId_InfluencerId UNIQUE (FollowerId, InfluencerId)
);
