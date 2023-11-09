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
DELETE FROM `entrepots`;
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
DELETE FROM `lieux`;
INSERT INTO `lieux` (`id`, `ville`, `pays`, `image`) VALUES
	(1, 'New York', 'USA', 'https://cdn.futura-sciences.com/buildsv6/images/largeoriginal/7/d/b/7dbc209eca_114440_gratte-ciel-new-york.jpg'),
	(2, 'Paris', 'France', 'https://images2.alphacoders.com/528/528327.jpg'),
	(3, 'Londres', 'Royaume-Unis', 'https://c.wallhere.com/photos/e3/61/London_buses_Big_Ben_sunset_road-1401545.jpg!d');

-- Listage de la structure de table stockage. liste_objets
CREATE TABLE IF NOT EXISTS `liste_objets` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` text NOT NULL,
  `image` text NOT NULL,
  `id_type` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_type` (`id_type`),
  CONSTRAINT `FK_liste_objets_types` FOREIGN KEY (`id_type`) REFERENCES `types` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=latin1;

-- Listage des données de la table stockage.liste_objets : ~60 rows (environ)
DELETE FROM `liste_objets`;
INSERT INTO `liste_objets` (`id`, `name`, `image`, `id_type`) VALUES
	(1, 'TéléviseurLG', 'https://www.lg.com/fr/images/televiseurs/md05988500/gallery/medium02.jpg', 3),
	(2, 'Lave vaisselle', 'https://boulanger.scene7.com/is/image/Boulanger/8003437203169_h_f_l_0?wid=500&hei=500', 2),
	(3, 'HP ELITEBOOK 840 G3 - WINDOWS 10', 'https://www.tradediscount.com/media/wysiwyg/fiche_produit/840G3-fiche.png', 4),
	(4, 'tabouret', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcR_azYcz3HlUW_rKlrr9Yp3qkEyq9Y4KGFv_Xh1-CxSfpft1LWDMlWo1Zw0qyYLVbXzUESPkXoX9Kb_SH1rrqMg8A_eGejfVgJHhg6b5Kt6wPKFArID1SUh&usqp=CAE', 1),
	(5, 'trousse de soin', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSBa4yY15wjPLDTCFjLyO7cJeNMlxEGxl6DSpXY6QhJah44dbr3tXKwnR9umpIFImxahW6K9zoNjmc3G--mo5jgf9cv49OvTnTk3fJynCtl&usqp=CAE', 24),
	(6, 'bureau', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcTKt__ztiYsyTmcX_yFCiw8ie0OVnTrEhPgnl7rndIOdlhrA_gO6v_6xCKSzgRz8oGLCza4f8w9xBkjG4nzR0Jy6oKRatsu5DguHOorTQIzr5ulHlA69eKFwQ&usqp=CAE', 1),
	(7, 'crème solaire', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQZppmehBJQpzcvCm48-laPbPcsTWx96paEH3w4iXSVLgrl4daoEVWLsyx9kia4ynfxINOQKjViQGfxQemeZ2wppDmfaxe-l5R3FIrj3XHoZkZAFSbOfS8KTw&usqp=CAE', 24),
	(8, 'trottinette électrique', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRDVkXUReWcuIgEk8rF_st2OeLthzcjTa3Vp_OD6e2j8UBmBsy0SEyQ1jp5nkFSJSjCREgZYxVfjKbnxELX7DAaBUqhBsLkAsjS2wFpPPOST8VcIjBZ7M5svA&usqp=CAE', 8),
	(9, 'crayon', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTBUSvUnd6RLfxPjlQGeLsveGyFeOviV-P5Qht8kY-p2irWdQxumk0fJHX8pMHiUqSJp8k3WyESyS-HC13xesctuDviSAf_VyYo8Z_eTwEzj62CTvovDdq5&usqp=CAE', 23),
	(10, 'cahier', 'https://www.welcomeoffice.com/WO_Products_Images/xlarge/203011.jpg', 23),
	(11, 'chaise', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcTBxhW-Tp1iIkUhK1YSQ3djMNpAFNCol0kIZC3pAqEYDEdhxSkx2ntZ7awnl6uh4pEfHmo32td7TZXR7N3tC1_UCvBs2-AutI30ZtzViQq2&usqp=CAE', 1),
	(12, 'souris', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcT4e71pO6ITDcMGnPPUf80iuYB2S_XiklbXzLFN7_zo2aHTikccpGnc45_Bc9lbjNmPWumGQJQTBuo8mcjNyWNKyoMxWXKpSOpClUFG7kvP-hOKjFTocUrGsw&usqp=CAE', 4),
	(13, 'clavier', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTOBmK16O912fNcdJX7YwXo_Ewk_fygWqAXXPLJM_qloOLsGDvGUjhlzeCYtzWAYrSc0ZOqe5BAJyYcm1GUVs38Ub6vhKiRonyKHT5A7d8qDdOFtTucD885jg&usqp=CAE', 4),
	(14, 'câble ethernet', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQb_7UTRFpwPXmymOvvSSql-KfnjOYmji0zYeJATP1OWZK_6Old1peRxG_bFcDaUcbtkUdb3EiOWmA-xzwoVDIFLYAnB-x1csTAQ-lpI0RIl0eYeocVt1V3_A&usqp=CAE', 4),
	(15, 'rouge à lèvre', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcShg6rMySzz3Uk6AEbwxfzcPKgkRwhnT5nSRgVMMM9hQ43m0k7PcSfavYGwk4VavZ9IG0fS7U70K_fDMkOTgjyBA-g10i0R0SzwOzohx0Gagv3ZN9MualTv&usqp=CAE', 10),
	(16, 'mascarat', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRnp7EehX3A41fyhbcBuFe8Oe_ufjslYxWqmqOz8p-zELP4Hy34VgSLJR-KD78ywQ0b_7X3Jib5wXwnASGWP4qoU19FINzT1Xg4qJgSYp0C09GYefoEwEDhEQ&usqp=CAE', 10),
	(17, 'perceuse', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcS0J68qsXHDPBXaVoqeC0KdaOa_wVjbD-xPHv0DLNvMkbfQAp20f2LGG4Ti2ZoTR_uZBzPaRn_1l-uXvTMq9NmGp_QzHlgXZqHEKquc17Oh65O-eqsHykzm&usqp=CAE', 9),
	(18, 'tournevis', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRfSBuRftbhPcLnlQACZYseJcKaaKi-diojLmal_rwIzi1NAoq1LUI0t1gMh3oQj5DYZgPj6jCn2GnFWMNKuaQP_PKNzPuO7Y2-C2hKmBV02iYwseUmcI2wxw&usqp=CAE', 9),
	(19, 'matelat', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcSC--LW1CLjQdIyBFeAr-sTZs4ODmObaf2XnwaLUbiggwbgG84inW4eiJPR46EZb35EoocuIoZ4lq2V8b6_MaLTgzbegh23JPaygVmi7Ko&usqp=CAE', 13),
	(20, 'carrote', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTfFRH_t_KZkBlW5kK57H99ymyguM-3-dZdT-mzF5tE_lo4yl3miLPGn7Pj57lJgyQxjxF8R9FOSUBRWdJcRYiwK_86JKfC-jI04Q1jjWq_Yw8S6OrNI_Be&usqp=CAE', 6),
	(21, 'thon en conserve', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcTVtkWvdjSz6j8WYWnHTL0bZbBdgTmxjkYzu8fgIEvvEvjsIdtf8xDzE5LBzk8__VxeqhF41VzqXXLHdzm59AxdLOh135L8n9CRQ_onYLyC&usqp=CAE', 6),
	(22, 'saucisson', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcTIrsCHQI80VbpkrNaRTAZ-Ugi-n9KZpfutf98D3RJLob8YttWokUubSyOFpLYkoEcFligMq3Fcr1NlVV6Uaqj5xDkFoA1zF9d2ThiJom4&usqp=CAE', 6),
	(23, 'pomme', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQeYfr_43O7HkHX_PuCyjSY9n1kR-MkOKSRcF239_D2PhTMOTg1B-GddqB8poYuEUgNG-ygXF3SvNklAjAkVx2jGlHN4AzwjQ&usqp=CAE', 6),
	(24, 'vin', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSb_WpbvJuY8Z_Z_r0neizSQNN8SDLzVLK8f4o8Op4W7CDnRcBRFkfXMWN0te0fBttnFEe4Rxec3ImUK9XqJF7YlQafvRAcaOeRzXCh-kPk-lFpLgDx0QsBpA&usqp=CAE', 7),
	(25, 'eau', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcTI4sLQ83u7NnNDF3P4tRxyRQgf0HgL3IyscoK0fPcN34K_iOeojOE2mnDrx8kEAy6jiczXOESjz7UzmBK5T8bUfpqlXL0Yx3YAc47lir4Q4EdQNmuNgU3T&usqp=CAE', 7),
	(26, 'pepsi', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcT3u6SF8q6jRdVwFsmU3YX4h7WRZF0YCE-LkkLF5cRPBlzEO7JtKAymegdWniJHNR-hY1p5Sn9dC22W9VkVRSrT4MlGSPKl26S1n2k_asOr8YvyqlZAvyQbzw&usqp=CAE', 7),
	(27, 'table de chevet', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSmhHx4GFv_a9iqx3UgK50nSk3DqssYpjBKXvEys7t2Uz8hsx-XgLtVuvmZpnfdpUUZDXTXCcU4TYpn_9NxTf9bH-oDkJK9Dhtk1xxibhKU&usqp=CAE', 1),
	(28, 'armoire', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRRtXmTcMXKGgbacQr8Jce0LuoNaAw0eGlGXqsgNefXy65BH0iE5FklAcquxmvU7QDPRxHOJMUUTlRao8uFDMVTag_WxPt7pFWLtQR8kOILnVJDScOGvJVC8w&usqp=CAE', 1),
	(29, 'savon', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSSIaKKwQTDtCHc2Op17scs6tp8mcG1ewRPsmTBUWnlTk5v0qtpBu7BhTygH1F9mosOiHFNw6Weapnu45l3aEKtcQ6s3tlfUvIJ5EdM2fQ&usqp=CAE', 24),
	(30, 'tuyau pvc', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcS2TLUeRyk8KVqimzlAukTv3nwO_8ABg9BFR2iUhD7ypz6FWTQw4dUL6xUTkunRInPlsr8M2iXMXlC1H3yT9pfeewDii2oX-OwoBL5LuOzNGzOTG-Bk8YMD&usqp=CAE', 14),
	(31, 'bracelet', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQy3So9KFLIzxW6ZLN3BsodeuHfHR4EK0nzjM_ZfGb86Q0hQ7lQNG5tcbi9zEIJC4h6PMbnm1f5OMMYBHLwbfNhhUHhxp6cXME2O4rjD6ZgbUQ3qLGSEx50&usqp=CAE', 12),
	(32, 'shampoing', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRxh8wlGcU99Wc6I_qL-aVDH8JfL89c5PsfzhG822_Ww_uy_6bu1TXh4uPHF1_jl__-0rxhlYTkCKbucTvelrgMwTGgr67ID8eJUni0tjn2aUZgXBgqNneg0A&usqp=CAE', 24),
	(33, 'canapé', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcTJVfO2vrv8cNGvRCRwEo_gPj6N2qcm03UDLO1sETOaGRDAdKqAycdincvs3eGaG1S0xo_TYQSgoJdrwMYldV6Z_qEdO80z6U7DbP1J-aekYRHaMKsZhW4b&usqp=CAE', 1),
	(34, 'bambou', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQ7WpqXROqxdfbA1P6uOw8i0MkUn2YGYeu-RKnSkkmLvW4pap01y3KPYIT5G61rR1a3Wh01kGrhGW_IoZVj-o4q75tXYteG804cUMt3tIc&usqp=CAE', 5),
	(35, 'pinceau', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcQu6fy6ssrXT7TfjimLm1cKPVheFuVDpejSzdl3R1AJ5WhK2dz3-qN6VPN4Yj4lGibWQPgynFK1E9GvxzJTG7zgI7a4BHG-xEDrZF6uTAsFHUhI9kyJBZtTMJs&usqp=CAE', 15),
	(36, 'tulipe', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQE2EjkUKWh5ynBOgpri0_Ls2dwMdpKkBsOG04hPkGNLmcRKmsPRlc6fAULUIveQ_JReUtnE4HWnXY8BUfElBdSCJw5A-JaDHCNOR30QgFM&usqp=CAE', 5),
	(37, 'table', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSjYxeBSEIFgLoh5PgRuT_3OUSxw-3zoWqbxW1WRUFRinD0fop-Jgdgq8l20MVufhxDESZk5CVzOffeE0V3EnPNiHr78t0TtZSCHuNmZrytGuOQFuSGL8KL&usqp=CAE', 1),
	(38, 'casque', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTr1GKVWQ5ba_yW521ZBQNKH2pYlyr34IkpGM_KcB0_M2NFy_hMGDeksvyiN7wCMCWuoJC2Cb9-QmA63jeedtdkPg45BnDuemP2G1cKzLEWRUWvCOiEFr5dGg&usqp=CAE', 4),
	(39, 'micro', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRWteQm26Ok_e7cKXKqTQaB1isyhlHWS8LsorAgIlZ-MXgMsb9MwKD44Wwu0SbBZFN9U7dUW-P-_GMVA4O3xXJmLLa-8idrtg3TBlwKwJqt58ifWxosO0c1&usqp=CAE', 4),
	(40, 'bloc de climatisation', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRtILwcLM3XPPSL9RmL4kQp8-Abx9rfKYgYCnexAWK40z72m2yZzTPqPMrpPOGTVp79-d8xPLzZrywa-jrCH0XauepapUxCPA&usqp=CAE', 17),
	(41, 'peinture blanche', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQ2JbtApGfE6DdHrhm7Vgfg8359IMGuJDiMBlpvkmiX3QwJ6yqxeqYi9A3M1TOilWroVxa5pZIE8TXLrZNtQ4QO4soXqv84ajwbKj5Ffh3Id9mlmDgImOJG&usqp=CAE', 15),
	(42, 'jeu de société', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcSWHZUMpw9bWsvMqhc7ZVHLxPQoaou3lj1S5i2vE8ENv35C4g3jrFsnUFBrWMhxfVKajKj5UyLvk65zfemKydM676Fom0ePnrzMJWTWMxxGmyTKSYMQa50M&usqp=CAE', 22),
	(43, 'set lego', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRd9Tk8E9Ih5Hx838BSWRM2KPJFf4ZCNaAOwlRE-UGJN9JQ5Cdg0WQnSy-fwwHRkdWIH_gB6X1XNqEADS_8ggjhbbBfn80QevQv233gy4VluI_M9Sk3KXS1uA&usqp=CAE', 22),
	(44, 'quad', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQuw2pRO6rCF9r5ikTOfTDfePAsRIcCsZSNoO8OxCYSwyi1krE00abfA1_0sfL8q80FO0HyUTgEvqmkOnfgobfmdBPdcr5rDZC0sH7081GnYC_I1LXJrTzP&usqp=CAE', 8),
	(45, 'valise a roue', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQgGikJjxmpkbH5bqnOC9comsBq2oU2JFQ1elrH96T7wHs6jqoelDXjiWucKDR0jR0f-t62YhdaXJLN79HCU9rqh4Qel-yUoEXryHzsa52dowxf5Z0NvzoK&usqp=CAE', 21),
	(46, 'rose', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRGQ1RJQkeUXn4HguB1_K4gLg_CtOleE4i6jfo4jdrBgWH6_5EF2QNilc_JVvVj0j2klIPtSO5thGJAGX4B9sYT7bAt8PzZeWVee5qf6gR3&usqp=CAE', 5),
	(47, 'cactus', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQSB3voofeSvg5w5f5_faAWWP0-zXgshUTU5DcSJxfk_moA1Z6VBLO3IIHWsKXdG2gGe5-itJ-6fmflm-UXhycmzdgw7mK3cPgfcwFGeUK5CXWslgR0ssk4rQ&usqp=CAE', 5),
	(48, 'VTT', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQHmV3yN4HjeFYS7S2t_BuHxaLYbfRA5thF0GW8xA4qsNcb7WhSJuAOC_nBNB-pDfD6E53K6ndugjn1XNIHepXALzgJCRDcCLfjDiYrtJDB7jxOZ1QJItzp&usqp=CAE', 19),
	(49, 'lampe de chevet', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTQe7zj-1cMtF_5FyNNX8YfvScAqqRe1I26lBEckmTbP8ILg9dPKRciRfYyKQNVgnuEXry_ISVyiqPo2mfcfcocZrwsw5A0uOQt_NVZ1wcM&usqp=CAE', 16),
	(50, 'lampe de plafond', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSF8Np5C84AcP6ME2N3qg4mUQc1XzhVNlzKxZfwOQ1ZOUFENehi3Hx0OMbYtnLAJYcOXqRNWTAR92vesaIflB-m92P_5juD8w72PHrL-1D2SCqfFsG0gXmCWQ&usqp=CAE', 16),
	(51, 'roman policier', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcSsy87dpv5JXLzPZtrX3lKVzpC8O6wCIUhpwV1eTj_3RIm-kTMASgQ-ZE9ZSEs97azFVqFIB5RDjjtSK07zVNg3R0SFTKJytnjDtnmvS_3dtY94C7Cah0uK&usqp=CAE', 18),
	(52, 'chaise longue', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcTFHA4mRqTdoOmyuq68maE1U12uRNDixlTHOI2COr8I1_YmCEDUAkqILzPd87dOwGqOtHUEpbxRBnaOhFS7ZQamV0NVoyrG5XxvOOPL8o3l&usqp=CAE', 1),
	(53, 'fauteuil', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQhl_K3iFGxBRevhVSUJ662Hojna1NKArue_M0w36G0dS4C5CeWOJdlmTlxm9z9MDs7ynJ00DphiWf5-MIFAxEfIbnIaBB8juEMXm2LlR4l&usqp=CAE', 1),
	(54, 'haltère', 'https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSxpgZ_ncGlmSF8SbPdZHSJz0EERwQGAOatBuSeusEWlR6HhZ9sn96MmCGRxAk4bDTgqfkCZ62eXnjOxoRX90LfccStXTHX-w8r8yylYusy23WnmTtSVIkbNg&usqp=CAE', 20),
	(55, 'vélo dintérieur', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRL4tShcyt3uBZF49x-c-C-6O32WZIcnZ_hmBy9Zc-JD-edpHMBUlZhFTBMafOEy2Ue_1LLCIWpNp-MFbEtCwNL7AFRaVVFiajgIRgbjoEVZ8JLYAfQBW20KA&usqp=CAE', 20),
	(56, 'grille pain', 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcSjNrU-uPNAwUVGS1UP2auvKuiMdKAQh35rdxaONxd8bl0EHdEXOG3zWlYRTAtEqPLTVNAmgyLhvIDEGooZ780MOtLgkMdfF4JLwjJOB9Ew3VA7uJUFT2umhw&usqp=CAE', 2),
	(57, 'bouilloire', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQ9RU19kKn5fTh4yL503DkQgoYePV7PKdyVhF6wt1JIbFVek0DcU_emAfXZ1ET5R8d5Lkq-c9_TcujM2UJNDcw0Uvc-D8OkHoF0IDxorRYBf_v_ORPgooF4-Q&usqp=CAE', 2),
	(58, 'four', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcTlwrgErJphKo8vnzNSfJfVSFPV0w5T2zlMV9fdV3NY69RGEKoILYyyHJYuGn8txW1wLd4IWmz6uWRfOK63kf9wPOATCNIeXdqcmqOCOa58RFiaSxRAVooZ&usqp=CAE', 2),
	(59, 'bague', 'https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcT2iGzNXvAFbJzJ30jxb37NynKXb6LRYDKNsILEhMyNqivT4CYhX6eihuSXlgwOepRwtn8kCnqJmox8uqMm8_pwiLj3W4piSmisJB3tj-JvJ-Z18WTRuFAoJKML&usqp=CAE', 12),
	(60, 'montre', 'https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSNsit1nmmaOPh77_d9U6TNP_xUrZ1gOUlLL-2f8YZcMzQMGz2pZjA0buDu077k4cavRuxhvHHX6FeKg65PDmG04zQBvtIG-z7enUcV-5p1NFRB2pql650i9g&usqp=CAE', 12);

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

-- Listage des données de la table stockage.stock : ~60 rows (environ)
DELETE FROM `stock`;
INSERT INTO `stock` (`id_entrepot`, `id_objet`, `quantity`) VALUES
	(1, 1, 35),
	(3, 2, 87),
	(2, 3, 66),
	(1, 4, 54),
	(1, 5, 77),
	(1, 6, 54),
	(1, 7, 99),
	(1, 8, 10),
	(1, 9, 47),
	(1, 10, 33),
	(1, 11, 25),
	(1, 12, 52),
	(1, 13, 85),
	(1, 14, 6),
	(1, 15, 63),
	(1, 16, 51),
	(1, 17, 13),
	(1, 18, 67),
	(1, 19, 97),
	(1, 20, 143),
	(2, 21, 154),
	(2, 22, 174),
	(2, 23, 84),
	(2, 24, 50),
	(2, 25, 86),
	(2, 26, 12),
	(2, 27, 72),
	(2, 28, 64),
	(2, 29, 103),
	(2, 30, 3),
	(2, 31, 46),
	(2, 32, 64),
	(2, 33, 87),
	(2, 34, 142),
	(2, 35, 69),
	(2, 36, 4),
	(2, 37, 72),
	(2, 38, 81),
	(2, 39, 31),
	(2, 40, 11),
	(3, 41, 46),
	(3, 42, 26),
	(3, 43, 16),
	(3, 44, 38),
	(3, 45, 107),
	(3, 46, 6),
	(3, 47, 35),
	(3, 48, 49),
	(3, 49, 50),
	(3, 50, 61),
	(3, 51, 95),
	(3, 52, 76),
	(3, 53, 88),
	(3, 54, 48),
	(3, 55, 27),
	(3, 56, 33),
	(3, 57, 540),
	(3, 58, 235),
	(3, 59, 10),
	(3, 60, 4);

-- Listage de la structure de table stockage. types
CREATE TABLE IF NOT EXISTS `types` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

-- Listage des données de la table stockage.types : ~24 rows (environ)
DELETE FROM `types`;
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
