-- Crea DB
CREATE DATABASE PickAVibeDB;
GO

-- Usa DB
USE PickAVibeDB;
GO

-- Tab Principali
-- Crea Users
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    IsAdmin BIT
);
GO

-- Crea Movies
CREATE TABLE Movies (
    MovieID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Year NVARCHAR(4) NOT NULL,
    Duration INT NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    PosterImg NVARCHAR(MAX),
    TrailerURL NVARCHAR(MAX)
);
GO

-- Crea Moods
CREATE TABLE Moods (
    MoodID INT IDENTITY(1,1) PRIMARY KEY,
    MoodName NVARCHAR(50) NOT NULL
);
GO

-- Crea Vibes
CREATE TABLE Vibes (
    VibeID INT IDENTITY(1,1) PRIMARY KEY,
    VibeName NVARCHAR(100) NOT NULL
);
GO

-- Tab Relazioni
-- Crea MoviesVibes
CREATE TABLE MoviesVibes (
    MovieVibeID INT IDENTITY(1,1) PRIMARY KEY,
    FK_MovieID INT,
    FK_VibeID INT,
    CONSTRAINT FK_MoviesVibes_MovieID FOREIGN KEY (FK_MovieID) REFERENCES Movies(MovieID),
    CONSTRAINT FK_MoviesVibes_VibeID FOREIGN KEY (FK_VibeID) REFERENCES Vibes(VibeID)
);
GO

-- Crea MoodsVibes
CREATE TABLE MoodsVibes (
    MoodVibeID INT IDENTITY(1,1) PRIMARY KEY,
    FK_MoodID INT,
    FK_VibeID INT,
    CONSTRAINT FK_MoodsVibes_MoodID FOREIGN KEY (FK_MoodID) REFERENCES Moods(MoodID),
    CONSTRAINT FK_MoodsVibes_VibeID FOREIGN KEY (FK_VibeID) REFERENCES Vibes(VibeID)
);
GO

-- Crea Watchlist
CREATE TABLE Watchlist (
    WatchlistID INT IDENTITY(1,1) PRIMARY KEY,
    FK_UserID INT,
    FK_MovieID INT,
    CONSTRAINT FK_Watchlist_UserID FOREIGN KEY (FK_UserID) REFERENCES Users(UserID),
    CONSTRAINT FK_Watchlist_MovieID FOREIGN KEY (FK_MovieID) REFERENCES Movies(MovieID)
);
GO

-- Crea Watched
CREATE TABLE Watched (
    WatchedID INT IDENTITY(1,1) PRIMARY KEY,
    FK_UserID INT,
    FK_MovieID INT,
    Rating INT CHECK (Rating >= 0 AND Rating <= 100),
    CONSTRAINT FK_Watched_UserID FOREIGN KEY (FK_UserID) REFERENCES Users(UserID),
    CONSTRAINT FK_Watched_MovieID FOREIGN KEY (FK_MovieID) REFERENCES Movies(MovieID)
);
GO
