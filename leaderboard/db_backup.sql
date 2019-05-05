-- MySQL dump 10.13  Distrib 5.1.73, for redhat-linux-gnu (x86_64)
--
-- Host: mysql2    Database: dbvr2019
-- ------------------------------------------------------
-- Server version	5.7.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbl_Admins`
--

DROP TABLE IF EXISTS `tbl_Admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_Admins` (
  `Username` varchar(30) NOT NULL,
  `Password` varchar(30) NOT NULL,
  PRIMARY KEY (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_Admins`
--

LOCK TABLES `tbl_Admins` WRITE;
/*!40000 ALTER TABLE `tbl_Admins` DISABLE KEYS */;
INSERT INTO `tbl_Admins` VALUES ('admin','adminVR2019');
/*!40000 ALTER TABLE `tbl_Admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_Games`
--

DROP TABLE IF EXISTS `tbl_Games`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_Games` (
  `GameID` int(3) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `About` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`GameID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_Games`
--

LOCK TABLES `tbl_Games` WRITE;
/*!40000 ALTER TABLE `tbl_Games` DISABLE KEYS */;
INSERT INTO `tbl_Games` VALUES (100,'Memory Game','A chemistry themed memory game at UiS Campus.'),(200,'Atom Crusher','A chemistry themed VR game, where you are supposed to crush atoms with swords.'),(300,'Escape Atom','A chemistry themed VR game, where you are supposed to throw atoms at molecules to make a reaction.');
/*!40000 ALTER TABLE `tbl_Games` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_Levels`
--

DROP TABLE IF EXISTS `tbl_Levels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_Levels` (
  `LevelID` int(3) NOT NULL,
  `GameID` int(3) NOT NULL,
  `Level` int(2) DEFAULT NULL,
  PRIMARY KEY (`LevelID`),
  KEY `GameID` (`GameID`),
  CONSTRAINT `tbl_Levels_ibfk_1` FOREIGN KEY (`GameID`) REFERENCES `tbl_Games` (`GameID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_Levels`
--

LOCK TABLES `tbl_Levels` WRITE;
/*!40000 ALTER TABLE `tbl_Levels` DISABLE KEYS */;
INSERT INTO `tbl_Levels` VALUES (101,100,1),(102,100,2),(103,100,3),(201,200,1),(202,200,2),(301,300,1);
/*!40000 ALTER TABLE `tbl_Levels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_Players`
--

DROP TABLE IF EXISTS `tbl_Players`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_Players` (
  `PlayerID` int(7) NOT NULL AUTO_INCREMENT,
  `Player_Name` varchar(30) NOT NULL,
  PRIMARY KEY (`PlayerID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_Players`
--

LOCK TABLES `tbl_Players` WRITE;
/*!40000 ALTER TABLE `tbl_Players` DISABLE KEYS */;
INSERT INTO `tbl_Players` VALUES (1,'Siri'),(2,'Sebastian'),(3,'Steven <3'),(4,'Siri'),(5,'Sebastian'),(6,'Steven <3');
/*!40000 ALTER TABLE `tbl_Players` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_Scores`
--

DROP TABLE IF EXISTS `tbl_Scores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbl_Scores` (
  `ScoreID` int(7) NOT NULL AUTO_INCREMENT,
  `LevelID` int(10) NOT NULL,
  `Player_Name` varchar(30) NOT NULL,
  `Score` int(5) DEFAULT '0',
  `Date_Set` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ScoreID`),
  KEY `LevelID` (`LevelID`),
  CONSTRAINT `tbl_Scores_ibfk_1` FOREIGN KEY (`LevelID`) REFERENCES `tbl_Levels` (`LevelID`)
) ENGINE=InnoDB AUTO_INCREMENT=122 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_Scores`
--

LOCK TABLES `tbl_Scores` WRITE;
/*!40000 ALTER TABLE `tbl_Scores` DISABLE KEYS */;
INSERT INTO `tbl_Scores` VALUES (86,101,'Thotiana',6969,'2019-04-13 14:20:01'),(87,101,'Thotiana',6969,'2019-04-13 14:20:02'),(88,101,'Thotiana',6969,'2019-04-13 14:20:03'),(89,101,'Thotiana',6969,'2019-04-13 14:20:03'),(90,101,'Thotiana',6969,'2019-04-13 14:20:03'),(91,101,'Thotiana',6969,'2019-04-13 14:20:04'),(92,101,'Jonny',2666,'2019-04-14 11:02:23'),(93,101,'Mary',1456,'2019-04-14 11:02:23'),(94,101,'Helga',877,'2019-04-14 11:02:24'),(95,102,'Jo',847,'2019-04-14 11:02:24'),(96,102,'Triana',37,'2019-04-14 11:02:24'),(97,102,'Siri',233,'2019-04-14 11:02:24'),(98,103,'Steven',847,'2019-04-14 11:02:24'),(99,103,'Seb',37,'2019-04-14 11:02:24'),(100,103,'ronny',233,'2019-04-14 11:02:24'),(101,201,'Tien',233,'2019-04-14 11:02:24'),(102,201,'Karen',87,'2019-04-14 11:02:24'),(103,201,'Marte',6749,'2019-04-14 11:02:24'),(104,202,'Magnhild',743,'2019-04-14 11:02:24'),(105,202,'Janne',8390,'2019-04-14 11:02:24'),(106,202,'Monica',19,'2019-04-14 11:02:24'),(107,301,'Nina',847,'2019-04-14 11:02:24'),(108,301,'Rikke',337,'2019-04-14 11:02:24'),(109,301,'hanne',544400,'2019-04-14 11:28:17'),(110,101,'M',295,'2019-04-14 12:48:10'),(111,102,'INGSE',255,'2019-04-14 12:53:11'),(112,101,'HID',190,'2019-04-14 13:08:46'),(113,301,'hanne',544400,'2019-04-16 10:55:59'),(114,202,'SEBBBB',57,'2019-04-16 15:19:16'),(115,101,'SMURDA',305,'2019-04-16 15:32:48'),(116,201,'707',3,'2019-04-16 15:38:52'),(117,102,'SIRI',380,'2019-04-24 06:59:29'),(118,201,'SIRI',6,'2019-04-24 07:00:34'),(119,202,'SIRI',3,'2019-04-24 07:01:21'),(120,301,'SIRI',157,'2019-04-24 07:03:24'),(121,301,'SIRI',150,'2019-04-24 07:30:31');
/*!40000 ALTER TABLE `tbl_Scores` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-05 16:19:26
