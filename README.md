# CommentApp
Application Title: CommentApp

Tech stack used:
-------------------
ASP.NET Core Web API and Microsoft SQL Server for backend and Angular and Angular Material for front-end.

Dependencies
------------------
.Net Core SDK 3.1 and above,
Angular 10 and above,
Angular Material,
Node.js,
Entity Framework core 3.1.0


Steps to run the application:
--------------------------------
Step1: Create a Database and Table use the below script
       
CREATE DATABASE CommentAppDb

CREATE TABLE UserAccount(
  [UserId] uniqueidentifier NOT NULL PRIMARY KEY,
  [EmailId] nvarchar(max) NOT NULL,
  [Password] nvarchar(max) NOT NULL,
  [SecretCode] nvarchar(max) NOT NULL,
  [IsActive] bit NOT NULL,
  [CreatedOn] DateTime NOT NULL
)
CREATE TABLE Comment(
  [CommentId] uniqueidentifier NOT NULL PRIMARY KEY,
  [CommentDescription] nvarchar(max) NOT NULL,
  [UserId] uniqueidentifier FOREIGN KEY REFERENCES UserAccount(UserId),
  [IsActive] bit NOT NULL,
  [CreatedOn] DateTime NOT NULL
)

Step2: Open CommentApp.Web folder in CMD and run the command npm install

Step3: After npm install open the CommmentApp.Web folder in Visual studio code and run the command npm start

Step4: Open the CommentApp.sln solution file in Visual studio

Step5: Install .Net Core SDK 3.1 and above in Visual studio

Step6: Right click on the CommentApp and choose Set as Startup Project after that run the IIS Express
