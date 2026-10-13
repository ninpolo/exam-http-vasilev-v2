-- ============================================================
-- Вариант 2: Музикални албуми — база данни ExamDb, таблица dbo.Albums
-- Изпълнете в SQL Server Management Studio или във Visual Studio
-- (View → SQL Server Object Explorer → десен клик върху сървъра → New Query).
-- Скриптът може да се пуска многократно — връща началните данни.
-- ============================================================

IF DB_ID(N'ExamDb') IS NULL
    CREATE DATABASE ExamDb;
GO

USE ExamDb;
GO

IF OBJECT_ID(N'dbo.Albums', N'U') IS NOT NULL
    DROP TABLE dbo.Albums;
GO

CREATE TABLE dbo.Albums
(
    Id    INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Title NVARCHAR(200)  NOT NULL,
    Artist NVARCHAR(100)  NOT NULL,
    Genre NVARCHAR(50)   NOT NULL,
    Year INT            NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);
GO

-- N пред текста е задължително за кирилица (NVARCHAR)
INSERT INTO dbo.Albums (Title, Artist, Genre, Year, Price) VALUES
    (N'Abbey Road', N'The Beatles', N'Rock', 1969, 39.90),
    (N'Revolver', N'The Beatles', N'Pop', 1966, 34.90),
    (N'Let It Be', N'The Beatles', N'Pop', 1970, 32.00),
    (N'Back in Black', N'AC/DC', N'Rock', 1980, 29.90),
    (N'The Dark Side of the Moon', N'Pink Floyd', N'Rock', 1973, 36.00),
    (N'Nevermind', N'Nirvana', N'Rock', 1991, 27.50),
    (N'Thriller', N'Michael Jackson', N'Pop', 1982, 31.00),
    (N'Kind of Blue', N'Miles Davis', N'Jazz', 1959, 28.00);
GO

SELECT * FROM dbo.Albums;
