-- --------------------------------------------------------
-- Hôte:                         127.0.0.1
-- Version du serveur:           8.0.30 - MySQL Community Server - GPL
-- SE du serveur:                Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Listage de la structure de la base pour stockage
CREATE DATABASE IF NOT EXISTS `stockage` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `stockage`;

-- Listage de la structure de table stockage. entrepots
CREATE TABLE IF NOT EXISTS `entrepots` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text,
  `cap_max` text,
  `date_creation` date DEFAULT NULL,
  `id_lieu` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_lieu` (`id_lieu`),
  CONSTRAINT `FK_entrepots_lieux` FOREIGN KEY (`id_lieu`) REFERENCES `lieux` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Listage des données de la table stockage.entrepots : ~3 rows (environ)
INSERT INTO `entrepots` (`id`, `name`, `cap_max`, `date_creation`, `id_lieu`) VALUES
	(1, 'Entrepot NY', '7500', '2022-12-01', 1),
	(2, 'Entrepot Paris', '9000', '2001-11-15', 2),
	(3, 'Entrepot Londres', '3500', '2005-05-23', 3);

-- Listage de la structure de table stockage. lieux
CREATE TABLE IF NOT EXISTS `lieux` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ville` text CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `pays` text NOT NULL,
  `image` text CHARACTER SET latin1 COLLATE latin1_swedish_ci,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Listage des données de la table stockage.lieux : ~3 rows (environ)
INSERT INTO `lieux` (`id`, `ville`, `pays`, `image`) VALUES
	(1, 'New York', 'USA', 'https://cdn.futura-sciences.com/buildsv6/images/largeoriginal/7/d/b/7dbc209eca_114440_gratte-ciel-new-york.jpg'),
	(2, 'Paris', 'France', 'https://images2.alphacoders.com/528/528327.jpg'),
	(3, 'Londres', 'UK', 'https://c.wallhere.com/photos/e3/61/London_buses_Big_Ben_sunset_road-1401545.jpg!d');

-- Listage de la structure de table stockage. liste_objets
CREATE TABLE IF NOT EXISTS `liste_objets` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text NOT NULL,
  `image` text NOT NULL,
  `id_type` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_type` (`id_type`),
  CONSTRAINT `FK_liste_objets_types` FOREIGN KEY (`id_type`) REFERENCES `types` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Listage des données de la table stockage.liste_objets : ~3 rows (environ)
INSERT INTO `liste_objets` (`id`, `name`, `image`, `id_type`) VALUES
	(1, 'TéléviseurLG', 'https://www.lg.com/fr/images/televiseurs/md05988500/gallery/medium02.jpg', 3),
	(2, 'Lave vaisselle', 'https://boulanger.scene7.com/is/image/Boulanger/8003437203169_h_f_l_0?wid=500&hei=500', 2),
	(3, 'HP ELITEBOOK 840 G3 - WINDOWS 10', 'https://www.tradediscount.com/media/wysiwyg/fiche_produit/840G3-fiche.png', 4);

-- Listage de la structure de table stockage. stock
CREATE TABLE IF NOT EXISTS `stock` (
  `id_entrepot` int NOT NULL,
  `id_objet` int NOT NULL,
  `quantity` int NOT NULL,
  UNIQUE KEY `id_objet` (`id_objet`),
  KEY `id_entrepot` (`id_entrepot`),
  CONSTRAINT `FK_stock_entrepots` FOREIGN KEY (`id_entrepot`) REFERENCES `entrepots` (`id`),
  CONSTRAINT `FK_stock_liste_objets` FOREIGN KEY (`id_objet`) REFERENCES `liste_objets` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Listage des données de la table stockage.stock : ~3 rows (environ)
INSERT INTO `stock` (`id_entrepot`, `id_objet`, `quantity`) VALUES
	(1, 1, 35),
	(3, 2, 87),
	(2, 3, 66);

-- Listage de la structure de table stockage. types
CREATE TABLE IF NOT EXISTS `types` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

-- Listage des données de la table stockage.types : ~24 rows (environ)
INSERT INTO `types` (`id`, `type`) VALUES
	(1, 'Meuble'),
	(2, 'Electromenager'),
	(3, 'Electronique'),
	(4, 'Informatique'),
	(5, 'Plantes'),
	(6, 'Nourriture'),
	(7, 'Boisson'),
	(8, 'Véhicule'),
	(9, 'Outillage'),
	(10, 'Maquillage'),
	(11, 'Vêtement'),
	(12, 'Bijou'),
	(13, 'Literie'),
	(14, 'Plomberie'),
	(15, 'Peinture'),
	(16, 'Eclairage'),
	(17, 'Climatisation'),
	(18, 'Livre'),
	(19, 'Vélo'),
	(20, 'Fitness'),
	(21, 'Valise'),
	(22, 'Jouets'),
	(23, 'Scolaire'),
	(24, 'Soin');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
