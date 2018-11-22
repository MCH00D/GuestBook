CREATE DATABASE GuestBook;

USE GuestBook;

CREATE TABLE Records
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Message] NVARCHAR(100) NOT NULL,
	[Author] NVARCHAR(30) NOT NULL,
	[Date] DATETIME NOT NULL
);

INSERT INTO [Records]([Message], [Author], [Date]) 
VALUES('Hello', 'Andrew', '2018-11-09 15:57:41'),
		('Wonderful', 'Petya', '2018-11-09 15:58:41'),
		('Not very good', 'Valia', '2018-11-09 16:09:02'),
		('Delightfully', 'Katya', '2018-11-09 11:33:44'),
		('Fine', 'Ira', '2018-11-09 12:54:56');