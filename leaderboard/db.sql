CREATE TABLE tbl_Games(
	GameID INT(3) NOT NULL,
	Name VARCHAR(30) NOT NULL DEFAULT,
	Description VARCHAR(100),
	PRIMARY KEY(GameID)
)

CREATE TABLE tbl_Players(
	PlayerID INT(7) NOT NULL,
	Player_Name VARCHAR(30) NOT NULL,
	PRIMARY KEY(PlayerID)
)

CREATE TABLE tbl_Scores(
<<<<<<< HEAD
	LevelID INT(10) NOT NULL,
	PlayerID INT(7) NOT NULL,
	Score INT(5) UNSIGNED NOT NULL DEFAULT ‘0’,
	Date_Set TIMESTAMP(),
	PRIMARY KEY(LevelID, PlayerID),
	FOREIGN KEY (LevelID) REFERENCES tbl_Levels(LevelID),
	FOREIGN KEY (PlayerID) REFERENCES tbl_Players(PlayerID)
)

CREATE TABLE tbl_Levels(
	LevelID INT(3) NOT NULL,
	GameID INT(3) NOT NULL,
	Level INT(2),
	PRIMARY KEY(LevelID),
	FOREIGN KEY (GameID) REFERENCES tbl_Games(GameID)
)



=======
	ScoreID VARCHAR(10) NOT NULL,
	GameID INT(3) NOT NULL,
	PlayerID INT(7) NOT NULL,
	Score INT(5) UNSIGNED NOT NULL DEFAULT ‘0’,
	Date_Set TIMESTAMP(),
	PRIMARY KEY(ScoreID)
)

>>>>>>> master
ENGINE=InnoDB;
