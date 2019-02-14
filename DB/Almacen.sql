-- MySQL dump 10.13  Distrib 8.0.14, for Win64 (x86_64)
--
-- Host: localhost    Database: almacen
-- ------------------------------------------------------
-- Server version	8.0.14

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `productos` (
  `CodProd` int(5) NOT NULL,
  `IdCatProd` int(5) DEFAULT NULL,
  `DescripcionProd` varchar(50) DEFAULT NULL,
  `MarcaProd` varchar(30) DEFAULT NULL,
  `PrecioProd` double(8,2) DEFAULT NULL,
  `StockProd` int(6) DEFAULT NULL,
  PRIMARY KEY (`CodProd`),
  KEY `IdCatProd` (`IdCatProd`),
  CONSTRAINT `IdCatProd` FOREIGN KEY (`IdCatProd`) REFERENCES `productos_categorias` (`IdCatProd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,1,'para 2 personas','nikkko',75.00,50),(2,1,'para 4 personas','coleman',90.00,40),(3,2,'pequeña','asatex',20.10,12),(4,2,'mediana','cortaviento',32.00,45),(5,2,'grande','simple',45.00,30),(6,3,'pequeña','porta',22.50,40),(7,3,'pequeña 3','tigo',20.00,33),(8,3,'grande','asatex',125.30,32);
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos_categorias`
--

DROP TABLE IF EXISTS `productos_categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `productos_categorias` (
  `IdCatProd` int(5) NOT NULL,
  `NombreCatProd` varchar(32) NOT NULL,
  PRIMARY KEY (`IdCatProd`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos_categorias`
--

LOCK TABLES `productos_categorias` WRITE;
/*!40000 ALTER TABLE `productos_categorias` DISABLE KEYS */;
INSERT INTO `productos_categorias` VALUES (1,'CARPAS MONTAÑA11'),(2,'SOMBRILLAS2'),(3,'MOCHILAS'),(4,'Tablas de surf'),(5,'TABLA'),(6,'SACOS DE DORMIR'),(7,'ROPA DE MONTAÑA');
/*!40000 ALTER TABLE `productos_categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitudes`
--

DROP TABLE IF EXISTS `solicitudes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `solicitudes` (
  `CodSolicitud` int(11) NOT NULL,
  `FechaSolicitud` date DEFAULT NULL,
  `CantItemsSolicitud` int(11) DEFAULT NULL,
  `IdUsuario` int(3) NOT NULL,
  `EstadoSolicitud` varchar(15) DEFAULT NULL,
  `DescripcionSolicitud` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`CodSolicitud`),
  KEY `IdUsuario` (`IdUsuario`),
  CONSTRAINT `IdUsuario` FOREIGN KEY (`IdUsuario`) REFERENCES `usuarios` (`IdUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitudes`
--

LOCK TABLES `solicitudes` WRITE;
/*!40000 ALTER TABLE `solicitudes` DISABLE KEYS */;
INSERT INTO `solicitudes` VALUES (1,'2019-01-28',12,1,'PROCESANDO',NULL),(2,'2019-01-29',8,1,'PROCESANDO',NULL),(3,'2019-01-30',6,1,'PROCESANDO',NULL);
/*!40000 ALTER TABLE `solicitudes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitudes_detalle`
--

DROP TABLE IF EXISTS `solicitudes_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `solicitudes_detalle` (
  `CodSolicitud` int(11) NOT NULL,
  `CodProd` int(5) NOT NULL,
  `CantProd` int(11) DEFAULT NULL,
  KEY `CodSolicitud` (`CodSolicitud`),
  CONSTRAINT `CodProd` FOREIGN KEY (`CodSolicitud`) REFERENCES `productos` (`CodProd`),
  CONSTRAINT `CodSolicitud` FOREIGN KEY (`CodSolicitud`) REFERENCES `solicitudes` (`CodSolicitud`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitudes_detalle`
--

LOCK TABLES `solicitudes_detalle` WRITE;
/*!40000 ALTER TABLE `solicitudes_detalle` DISABLE KEYS */;
INSERT INTO `solicitudes_detalle` VALUES (1,1,12),(2,3,8),(3,6,6);
/*!40000 ALTER TABLE `solicitudes_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario_permisos`
--

DROP TABLE IF EXISTS `usuario_permisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuario_permisos` (
  `IdUsuario` int(3) NOT NULL,
  `PerProductos` tinyint(1) DEFAULT NULL,
  `PerIngresos` tinyint(1) DEFAULT NULL,
  `PerSalidas` tinyint(1) DEFAULT NULL,
  `PerSolicitudes` tinyint(1) DEFAULT NULL,
  `PerReportes` tinyint(1) DEFAULT NULL,
  `PerUsuarios` tinyint(1) DEFAULT NULL,
  KEY `IdUsuario` (`IdUsuario`),
  CONSTRAINT `usuario_permisos_ibfk_1` FOREIGN KEY (`IdUsuario`) REFERENCES `usuarios` (`IdUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario_permisos`
--

LOCK TABLES `usuario_permisos` WRITE;
/*!40000 ALTER TABLE `usuario_permisos` DISABLE KEYS */;
INSERT INTO `usuario_permisos` VALUES (1,1,1,1,1,1,1),(2,1,1,1,1,0,0),(3,1,0,0,1,0,0);
/*!40000 ALTER TABLE `usuario_permisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario_tipos`
--

DROP TABLE IF EXISTS `usuario_tipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuario_tipos` (
  `IdTipoUser` int(3) NOT NULL,
  `DescripcionTipoUser` varchar(20) NOT NULL,
  PRIMARY KEY (`IdTipoUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario_tipos`
--

LOCK TABLES `usuario_tipos` WRITE;
/*!40000 ALTER TABLE `usuario_tipos` DISABLE KEYS */;
INSERT INTO `usuario_tipos` VALUES (1,'Administrador'),(2,'Almacenero'),(3,'Empleado');
/*!40000 ALTER TABLE `usuario_tipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuarios` (
  `IdUsuario` int(3) NOT NULL,
  `IdTipoUser` int(3) NOT NULL,
  `CuentaUsuario` varchar(20) NOT NULL,
  `PasswordUsuario` varchar(20) NOT NULL,
  `DNIUsuario` int(12) NOT NULL,
  `NombreUsuario` varchar(50) DEFAULT NULL,
  `ApellidoUsuario` varchar(50) DEFAULT NULL,
  `TelefonoUsuario` varchar(15) NOT NULL,
  `CorreoUsuario` varchar(40) DEFAULT NULL,
  `DireccionUsuario` varchar(100) DEFAULT NULL,
  `ComentarioUsuario` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdUsuario`),
  CONSTRAINT `IdTipoUser` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario_tipos` (`IdTipoUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,1,'DENNIS','samael',46776134,'Dennis Severino','Calderòn Mamani','925599814','dennis.tacna@gmail.com','Asociaciòn de Vivienda san Pedro y San Pablo Manzana I Lote 0444','Desarrollador del Sistema'),(2,2,'dennis2','samael',43243,'fwefwe','fwefwe','345345','ferfer','ferfer','erferfer'),(3,3,'dennis3','samael',423423,'vvasdfv','dfvdfvd','3453453','evergerg','ergerg','rgerg');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'almacen'
--

--
-- Dumping routines for database 'almacen'
--
/*!50003 DROP PROCEDURE IF EXISTS `Btn_PU_Anterior` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Btn_PU_Anterior`(
in _IdUsuario int(3)
)
BEGIN
set @id = _IdUsuario - 1;
select u.IdUsuario, ut.DescripcionTipoUser, u.CuentaUsuario, u.NombreUsuario, u.ApellidoUsuario,
up.PerProductos, up.PerIngresos, up.PerSalidas, up.PerSolicitudes, up.PerReportes,PerUsuarios
from usuario_permisos as up, usuarios as u, usuario_tipos as ut
where u.IdTipoUser = ut.IdTipoUser and up.IdUsuario = u.IdUsuario 
and u.IdUsuario = @id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Btn_PU_Primero` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Btn_PU_Primero`()
BEGIN
set @id = (SELECT Min(IdUsuario) FROM usuarios);
select u.IdUsuario, ut.DescripcionTipoUser, u.CuentaUsuario, u.NombreUsuario, u.ApellidoUsuario,
up.PerProductos, up.PerIngresos, up.PerSalidas, up.PerSolicitudes, up.PerReportes,PerUsuarios
from usuario_permisos as up, usuarios as u, usuario_tipos as ut
where u.IdTipoUser = ut.IdTipoUser and up.IdUsuario = u.IdUsuario 
and u.IdUsuario = @id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Btn_PU_Siguiente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Btn_PU_Siguiente`(
in _IdUsuario int(3)
)
BEGIN
set @id = _IdUsuario + 1;
select u.IdUsuario, ut.DescripcionTipoUser, u.CuentaUsuario, u.NombreUsuario, u.ApellidoUsuario,
up.PerProductos, up.PerIngresos, up.PerSalidas, up.PerSolicitudes, up.PerReportes,PerUsuarios
from usuario_permisos as up, usuarios as u, usuario_tipos as ut
where u.IdTipoUser = ut.IdTipoUser and up.IdUsuario = u.IdUsuario 
and u.IdUsuario = @id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Btn_PU_Ultimo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Btn_PU_Ultimo`()
BEGIN
set @id = (SELECT Max(IdUsuario) FROM usuarios);
select u.IdUsuario, ut.DescripcionTipoUser, u.CuentaUsuario, u.NombreUsuario, u.ApellidoUsuario,
up.PerProductos, up.PerIngresos, up.PerSalidas, up.PerSolicitudes, up.PerReportes,PerUsuarios
from usuario_permisos as up, usuarios as u, usuario_tipos as ut
where u.IdTipoUser = ut.IdTipoUser and up.IdUsuario = u.IdUsuario 
and u.IdUsuario = @id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Btn_Solicitudes_Anterior` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Btn_Solicitudes_Anterior`(
in _CodSolicitud int(11)
)
BEGIN
set @id= _CodSolicitud - 1;
select s.CodSolicitud, s.FechaSolicitud, s. CantItemsSolicitud, u.CuentaUsuario, s.EstadoSolicitud, s.DescripcionSolicitud
from solicitudes as s, usuarios as u
where 
s.IdUsuario = u.IdUsuario and CodSolicitud=@id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Btn_Solicitudes_Primero` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Btn_Solicitudes_Primero`()
BEGIN
set @id=(select min(CodSolicitud) from solicitudes);
select s.CodSolicitud, s.FechaSolicitud, s. CantItemsSolicitud, u.CuentaUsuario, s.EstadoSolicitud, s.DescripcionSolicitud
from solicitudes as s, usuarios as u
where 
s.IdUsuario = u.IdUsuario and CodSolicitud=@id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Btn_Solicitudes_Siguiente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Btn_Solicitudes_Siguiente`(
in _CodSolicitud int(11)
)
BEGIN
set @id= _CodSolicitud + 1;
select s.CodSolicitud, s.FechaSolicitud, s. CantItemsSolicitud, u.CuentaUsuario, s.EstadoSolicitud, s.DescripcionSolicitud
from solicitudes as s, usuarios as u
where 
s.IdUsuario = u.IdUsuario and CodSolicitud=@id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Btn_Solicitudes_Ultimo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Btn_Solicitudes_Ultimo`()
BEGIN
set @id=(select max(CodSolicitud) from solicitudes);
select s.CodSolicitud, s.FechaSolicitud, s. CantItemsSolicitud, u.CuentaUsuario, s.EstadoSolicitud, s.DescripcionSolicitud
from solicitudes as s, usuarios as u
where 
s.IdUsuario = u.IdUsuario and CodSolicitud=@id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Insert_Categorias` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_Categorias`(
in _NombreCatProd varchar(32)
)
BEGIN
set @id=(SELECT Max(IdCatProd) FROM almacen.productos_categorias) + 1;
INSERT INTO almacen.productos_categorias (IdCatProd, NombreCatProd)
    VALUES (@id, _NombreCatProd);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Insert_Productos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_Productos`(
in _NombreCatProd varchar(32),
in _DescripcionProd varchar(50),
in _MarcaProd varchar(30),
in _PrecioProd double(8,2),
in _StockProd int(6)
)
BEGIN
	set @id1=(SELECT Max(CodProd) FROM productos) + 1;
	set @id2=(SELECT IdCatProd FROM productos_categorias where NombreCatProd = _NombreCatProd);
	insert into productos (CodProd, IdCatProd, DescripcionProd, MarcaProd, PrecioProd, StockProd)
    values(@id1, @id2, _DescripcionProd, _MarcaProd, _PrecioProd, _StockProd);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Insert_Usuarios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_Usuarios`(
in _descripciontipouser varchar(20),
in _CuentaUsuario varchar(20),
in _PasswordUsuario varchar(20),
in _DNIUsuario int(12),
in _NombreUsuario varchar(50),
in _ApellidoUsuario varchar(50),
in _TelefonoUsuario varchar(15),
in _CorreoUsuario varchar(40),
in _DireccionUsuario varchar(100),
in _ComentarioUsuario varchar(100)
)
BEGIN
set @id1=(SELECT Max(IdUsuario) FROM usuarios) + 1;
set @id2=(SELECT idtipouser FROM usuario_tipos where descripciontipouser = _descripciontipouser);

insert into usuarios (IdUsuario, IdTipoUser, CuentaUsuario, PasswordUsuario, DNIUsuario, NombreUsuario,
ApellidoUsuario, TelefonoUsuario, CorreoUsuario, DireccionUsuario, ComentarioUsuario)
values
(@id1, @id2, _CuentaUsuario, _PasswordUsuario, _DNIUsuario, _NombreUsuario, _ApellidoUsuario,
_TelefonoUsuario, _CorreoUsuario, _DireccionUsuario, _ComentarioUsuario);

If @id2 = 1 then
insert into usuario_permisos values (@id1, 1, 1, 1, 1, 1, 1);
end If;
If @id2 = 2 then
insert into usuario_permisos values (@id1, 1, 1, 1, 1, 0, 0);
end If;
If @id2 = 3 then
insert into usuario_permisos values (@id1, 0, 0, 0, 1, 0, 0);
end If;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `login` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `login`(
in _CuentaUsuario varchar(20),
in _PasswordUsuario varchar(20))
BEGIN
	select u.CuentaUsuario as cuenta, ut.descripciontipouser as descripcion
    from usuarios as u, usuario_tipos as ut
    where 
    u.IdTipoUser = ut.IdTipoUser and
    u.CuentaUsuario = _CuentaUsuario and 
    u.PasswordUsuario = _PasswordUsuario;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Mostrar_Categorias` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Mostrar_Categorias`()
BEGIN
	select IdCatProd, NombreCatProd from productos_categorias;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Mostrar_Categorias_Descripcion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Mostrar_Categorias_Descripcion`()
BEGIN
	select IdCatProd, NombreCatProd from productos_categorias;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Mostrar_Productos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Mostrar_Productos`()
BEGIN
	select p.CodProd, pc.NombreCatProd, p.DescripcionProd, p.MarcaProd, p.PrecioProd, p.StockProd
	from productos as p, productos_categorias as pc
	where p.IdCatProd = pc.IdCatProd;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Mostrar_Usuarios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Mostrar_Usuarios`()
BEGIN
	select u.IdUsuario, ut.descripciontipouser, u.CuentaUsuario, u.PasswordUsuario, u.DNIUsuario,
    u.NombreUsuario, u.ApellidoUsuario, u.TelefonoUsuario, u.CorreoUsuario, u.DireccionUsuario,
    u.ComentarioUsuario
    from usuarios as u, usuario_tipos as ut
    where u.IdTipoUser= ut.IdTipoUser;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Mostrar_Usuarios_Permisos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Mostrar_Usuarios_Permisos`(
in _CuentaUsuario varchar(20))
BEGIN
set @id=(SELECT IdUsuario FROM usuarios where CuentaUsuario = _CuentaUsuario);
select * from usuario_permisos where IdUsuario=@id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Mostrar_Usuarios_Tipos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Mostrar_Usuarios_Tipos`()
BEGIN
select idtipouser, descripciontipouser from usuario_tipos;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Read_Productos_Buscar` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Read_Productos_Buscar`()
BEGIN
select pc.NombreCatProd, p.DescripcionProd, p.StockProd
from productos as p, productos_categorias as pc
where p.IdCatProd = pc.IdCatProd;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Read_Solicitud_Detalle` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Read_Solicitud_Detalle`(
in _CodSolicitud int(11)
)
BEGIN
select ct.NombreCatProd, p.DescripcionProd, sd.CantProd
from solicitudes_detalle as sd, productos as p, productos_categorias as ct
where sd.CodProd = p.CodProd and p.IdCatProd = ct.IdCatProd and sd.CodSolicitud = _CodSolicitud
;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Update_Categorias` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Update_Categorias`(
in _IdCatProd int,
in _NombreCatProd varchar(32)
)
BEGIN
	update productos_categorias set NombreCatProd =_NombreCatProd 
    where 
    IdCatProd = _IdCatProd;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Update_Productos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Update_Productos`(
in _CodProd int(5),
in _NombreCatProd varchar(32),
in _DescripcionProd varchar(50),
in _MarcaProd varchar(30),
in _PrecioProd double(8,2),
in _StockProd int(6)
)
BEGIN
	set @id=(SELECT IdCatProd FROM productos_categorias where NombreCatProd = _NombreCatProd);
	update productos set  IdCatProd=@id, DescripcionProd= _DescripcionProd,
    MarcaProd=_MarcaProd, PrecioProd=_PrecioProd, StockProd=_StockProd
    where CodProd=_CodProd;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Update_Usuarios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Update_Usuarios`(
in _IdUsuario int(3),
in _descripciontipouser varchar(20),
in _CuentaUsuario varchar(20),
in _PasswordUsuario varchar(20),
in _DNIUsuario int(12),
in _NombreUsuario varchar(50),
in _ApellidoUsuario varchar(50),
in _TelefonoUsuario varchar(15),
in _CorreoUsuario varchar(40),
in _DireccionUsuario varchar(100),
in _ComentarioUsuario varchar(100)
)
BEGIN
set @id=(SELECT idtipouser FROM usuario_tipos where descripciontipouser = _descripciontipouser);
update usuarios set IdTipoUser=@id, CuentaUsuario= _CuentaUsuario, PasswordUsuario=_PasswordUsuario,
DNIUsuario=_DNIUsuario, NombreUsuario=_NombreUsuario, ApellidoUsuario=_ApellidoUsuario, 
TelefonoUsuario=_TelefonoUsuario, CorreoUsuario=_CorreoUsuario, DireccionUsuario=_DireccionUsuario,
ComentarioUsuario=_ComentarioUsuario
where IdUsuario=_IdUsuario;

If @id = 1 then
update usuario_permisos set PerProductos=1, PerIngresos=1, PerSalidas=1, PerSolicitudes=1, PerReportes=1, PerUsuarios=1
where IdUsuario=_IdUsuario;
end If;
If @id = 2 then
update usuario_permisos set PerProductos=1, PerIngresos=1, PerSalidas=1, PerSolicitudes=1, PerReportes=0, PerUsuarios=0
where IdUsuario=_IdUsuario;
end If;
If @id = 3 then
update usuario_permisos set PerProductos=0, PerIngresos=0, PerSalidas=0, PerSolicitudes=1, PerReportes=0, PerUsuarios=0
where IdUsuario=_IdUsuario;
end If;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Update_Usuarios_Permisos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Update_Usuarios_Permisos`(
in _IdUsuario int(3),
in _PerProductos tinyint(1),
in _PerIngresos tinyint(1),
in _PerSalidas tinyint(1),
in _PerSolicitudes tinyint(1),
in _PerReportes tinyint(1),
in _PerUsuarios tinyint(1)
)
BEGIN
update usuario_permisos set PerProductos=_PerProductos, PerIngresos= _PerIngresos, PerSalidas=_PerSalidas,
PerSolicitudes=_PerSolicitudes, PerReportes=_PerReportes, PerUsuarios=_PerUsuarios
where IdUsuario=_IdUsuario;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-14  7:21:30
