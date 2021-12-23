-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.27-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema flores
--

CREATE DATABASE IF NOT EXISTS flores;
USE flores;

--
-- Definition of table `datosflores`
--

DROP TABLE IF EXISTS `datosflores`;
CREATE TABLE `datosflores` (
  `idflor` int(10) unsigned NOT NULL auto_increment,
  `nombrecientifico` varchar(100) NOT NULL,
  `nombrecomun` varchar(200) NOT NULL,
  `origen` varchar(300) NOT NULL,
  `descripcion` text NOT NULL,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY  USING BTREE (`idflor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `datosflores`
--

/*!40000 ALTER TABLE `datosflores` DISABLE KEYS */;
INSERT INTO `datosflores` (`idflor`,`nombrecientifico`,`nombrecomun`,`origen`,`descripcion`,`nombre`) VALUES 
 (1,'Lilium spp.','Azucena, lirios verdaderos, lilium, martagón','Proviene de las regiones templadas del hemisferio norte. Herbácea perenne, familia de las Liliáceas','Son plantas bulbosas que llegan a medir 1 metro de altura, su tallo es rígido y al final sostiene entre 8 y 12 flores con forma de trompeta que nacen de un mismo lugar. Los pétalos de estas flores son curvados hacia atrás. Las azucenas desprenden un exquisito y suave perfume, sobre todo durante la noche, pero no todas las variedades poseen aroma. Sus colores pueden ser muy variados: blanco, anaranjado, púrpura, rosa, amarillo, a las que se le suman sus combinaciones, y las variedades con manchitas marrones y púrpuras. Se plantan en la primavera, aunque a pocas variedades se las siembra en otoño para que desarrollen mejor sus raíces. La profundidad en que se planten los bulbos dependerá de la especie, y se debe mantener la tierra fresca y abonada. Las azucenas tienen hojas lineales que llegan a medir hasta 30 centímetros, y son de color verde oscuro. Estas plantas crecen sin dificultad en un lugar donde tengan sombra, y nunca deben tener luz directa. Las azucenas florecen al final de la primavera hasta finales de verano. Durante los meses del verano se pueden separar los pequeños bulbos que se forman junto al bulbo mayor y así multiplicar la especie. Si esto se hace por semilla, hay que tener en cuenta que florecerán a los cuatro o cinco años. La azucena es una hermosa, atractiva y decorativa planta que florece y puede tener vida en el jardín durante muchos años.','Azucena'),
 (3,'Cosmos bipinnatus','Cosmos',' México. Planta herbácea anual','El Cosmos pertenece a la familia de las ASTERACEAE, cuyo nombre viene de ASTER (estrella).\r\n\r\nSus llamadas flores, no son tales, sino inflorescencias, ya que están formadas por pequeñas flores, las del centro o botón, son tubulares y las hojas que lo rodean , son cada una de ellas una flor, llamada \"lígula\". De aquí el nombre de \"compuestas\". Es originaria de Centroamérica y se ha convertido en una flor de jardín bastante popular por su belleza y vistosidad.\r\n\r\nOtras flores de la misma familia: Equinácea, senecio, matrircaria, milenrama. Siendo muchas de ellas usadas en fitoterapia y también en esencia floral.Florece desde primavera hasta principios de otoño. Se mantiene durante todo el verano en flor incluso bajo condiciones de alta temperatura y humedad.\r\n\r\nMuy elegante. Ideal para patios y jardines. Conviene dejarla en un lugar permanentemente soleado. Riego moderado. Se multiplica por semillas en invierno y primavera. Germinación en 8-14 días a 18ºC.','Cosmos');
INSERT INTO `datosflores` (`idflor`,`nombrecientifico`,`nombrecomun`,`origen`,`descripcion`,`nombre`) VALUES 
 (6,'Calendula officinalis','Caléndula, botón de oro, corona de rey, caléndula, caldo, flamenquilla, flor de difunto, maravilla, rosa de muertos o cempasúchitl','Crece espontáneamente en el campo y diferentes lugares del planeta. Está muy extendida en la zona mediterránea (Europa meridional y norte de Oriente próximo). ','Es una planta herbácea, anual, con flores amarillas. Su floración dura casi todo el año, cerrándose de noche y abriéndose al amanecer. Tiene una altura media que oscila entre los 30-50 cm., su tallo es semi-erecto, angular y ramificado y sus hojas son alternas, oblongas o lanceoladas y sensiles; capítulos de 3-5 cm. de anchura, amarillos o anaranjados, con una corona de 15-20 lígulas, y frutos encorvados, provistos casi todos de alas membranosas o púas dorsales. Se cultiva muy a menudo en los jardines de los que escapa con facilidad.','Caléndula'),
 (8,'Rosa spp.','Rosa, rosal, escaramujo, roseira (Brasil) ','Proviene de la la Antigua China. Arbusto, familia de las Rosáceas','La rosa es la flor del rosal, que es una planta rústica con fuertes tallos con muchas espinas.\r\nLas hojas verdes y brillosas se componen de dos o tres pares más una impar.\r\nHay numerosos tipos de rosales: trepadoras, no trepadoras, arbustos, matas y miniaturas.\r\nLa hermosa flor posee un atractivo incomparable al que se le suma su suave y exquisito aroma. Su elegancia y belleza hace que sea la más cultivada de todas las flores. \r\n\r\nExisten más de cien especies de rosas silvestres.\r\n\r\nLas plantas miniatura de flores pequeñas son ideales para los balcones y terrazas, y florecen ininterrumpidamente de mayo a noviembre.\r\n\r\n\r\n\r\nLa rosa puede ser cultivada en cualquier ambiente menos a la sombra total. Con algunas horas de sol por la mañana le alcanza para que florezca regularmente.\r\nNo necesita demasiado riego, excepto si está en maceta. \r\nLos rosales se desarrollan mejor en zonas templadas y crecen con más facilidad con inviernos fríos y helados, primaveras suaves, y días con mucho sol en verano.\r\nLa planta no debe ponerse a favor del viento, ni tampoco a pleno sol. Aunque puede adaptarse a condiciones adversas de temperaturas y cantidades variables de sol y lluvia.\r\n\r\nLa poda del rosal evita ramificaciones inútiles que impiden que se desarrollen las flores de forma correcta y que nazcan de calidad.','Rosa');
INSERT INTO `datosflores` (`idflor`,`nombrecientifico`,`nombrecomun`,`origen`,`descripcion`,`nombre`) VALUES 
 (12,'Dahlia spp.','Dalia, dahlia, xicamiti, flor de camote. ','Proviene de las regiones de Cuernavaca y Tepoztlán, en México. Familia de las compuestas','Se conocen más de 2 mil variedades diferentes de esta planta. Crece en forma de mata y puede medir desde unos pocos centímetros hasta más de un metro de altura, según la variedad.\r\n\r\nTiene hojas de forma ovalada, compuestas y de color verde oscuro. Las flores pueden ser de diferentes dimensiones, incluso muy grandes. Los tonos también son variados: rosas, amarillos, púrpuras, rojos, anaranjados, y sus combinaciones.\r\n\r\nLa dalia se reproduce a través de bulbos. Se planta a fines del invierno o comienzo de la primavera cuidándola de las últimas heladas. Necesita un lugar soleado, algunas horas de sombra también y sin corrientes fuertes de aire. Abundante agua. Suelo abonado, fresco y permeable. Puede soportar altas temperaturas.\r\n\r\nNo sobrevive a las heladas, volverá a nacer la próxima primavera desde sus bulbos que contiene los nutrientes necesarios para el posterior desarrollo. En algunos casos retiran los bulbos del suelo, al retirarlos se ven los pequeños bulbitos que nacieron y sirven para la reproducción de la planta; se guardan en un lugar seco para ser plantados la próxima primavera.\r\n\r\nLa dalia no sobrevive en interiores, le gusta la luz y el aire.\r\n\r\nFlorece desde mediados de verano hasta los primeros fríos.\r\n\r\nEsta es otra bella planta que gracias a su gran cantidad de colores le da a los jardines una hermosa pincelada.','Dahlia '),
 (23,'Helianthus annuus','Girasol, Mirasol, tornasol, helianto, sol de las Indias ','Proviene de las Andes centrales (Perú) en América. Planta anual.','Esta planta tiene un solo tallo bastante resistente y llega a medir más de dos metros.\r\nSus hojas son grandes y de forma triangular, ásperas al tacto y bordes aserrados.\r\nLa flor del girasol llega a tener un tamaño muy grande, muchas veces hace que el tallo se incline por su peso. Sus pétalos son de color amarillo intenso, lo que le da a la planta una belleza única.\r\n\r\nEl girasol se planta de semilla en primavera y florece todo el verano, de cada planta crece sólo una flor, aunque se han visto casos en que da más cantidad en un tamaño más pequeño.\r\n\r\n\r\nDebe tener sol pleno. La luz es un elemento fundamental. El girasol necesita una ubicación cálida, soleada y protegida del viento. \r\nSu nombre se debe a que gira su gran inflorescencia siguiendo el movimiento solar: al amanecer la orienta hacia el este y continúa girando a medida que avanza el día, hasta quedar orientada hacia el poniente; así, los rayos solares inciden perpendicularmente sobre ella.\r\n\r\nDebe estar bien regada durante su crecimiento y mientras está en flor. Pero no soporta los estancamientos de agua, ya que su raíz se pudre fácil.\r\nEl suelo debe estar abonado y no aguanta los trasplantes. Resiste distintas temperaturas pero no las heladas.','Girasol');
INSERT INTO `datosflores` (`idflor`,`nombrecientifico`,`nombrecomun`,`origen`,`descripcion`,`nombre`) VALUES 
 (24,'Zinnia elegans','Zinnia, zinia, rosa mística, flor de papel','Su origen es de México. Es una herbácea anual de la familia de las Aráceas.','La zinnia tiene tallos huecos y quebradizos.\r\nSus hojas son ásperas y triangulares y se distribuyen en pares opuestos. \r\nPoseen flores con dos coronas de pétalos y sus sépalos son velludos.\r\nHay una gran variedad de colores y tamaños, se extienden en espesas y rígidas vegetaciones dándole al jardín diversidad de llamativas tonalidades y gran esplendor.\r\nLas especies enanas son ideales para adornar balcones y ventanas. \r\nExisten unas 20 especies diferentes, anuales o arbustos.\r\n\r\nSe plantan cada año de semillas. En suelo fértil la floración es muy rápida y se puede mantener hasta el otoño. \r\nSe le siembra en suelos húmedos, bien drenados y donde reciban una buena dosis de sol diaria.\r\n\r\nSi aún se temen heladas se ponen las semillas en macetas donde germinarán en sólo una o dos semanas. En un mes o dos la planta ya estará lo suficientemente crecida para trasladarla a plena tierra y en ocho o diez semanas comenzarán a emerger los capullos. \r\nLo mejor es buscar una ubicación donde la planta pueda recibir el sol de lleno durante la primavera, el verano y el otoño. \r\nLa planta puede ser perjudicada por pulgones y otros ácaros y hay que cuidar las semillas de babosas y caracoles.\r\nEntre cada riego, lo más aconsejable es dejar que la tierra se seque al menos un centímetro, y hacerlo evitando que las hojas se mojen.\r\nLa planta puede y debe estar a la intemperie durante todo el año. ','Zinnia'),
 (65,'Chrysanthemun leaucanthemum','Margarita común, pascueta o vellorita ','Proviene del centro y norte de Europa. Herbácea perenne, familia de las Asteráceas','La margarita puede medir desde 15 centímetros hasta un metro formando grandes matas. Posee un rizoma rastrero.\r\nSus tallos son largos y delgados, con hojas verde oscuro, largas y dentadas.\r\nSus bellas flores tienen su centro discoidal de color amarillo y pétalos blancos o amarillos. \r\n\r\n\r\n\r\nLa mejor época para sembrarlas es la primavera, se puede hacer por semillas, división o corte.\r\nSe deben regar después de sembrarlas y mantenerlas húmedas, sin excederse para no anegarlas. \r\nLa mejor tierra es la arcillosa, pero se adaptan a casi todo tipo de suelos con nutrientes. Si se abona se favorece su crecimiento y su floración con colores más intensos.\r\nGeneralmente florecen desde la primavera hasta principios del invierno.\r\nA las margaritas les gusta la luz natural y es preferible colocarlas en un lugar bastante soleado.\r\nDurante el invierno se protegen las raíces colocando hojas secas o paja en la base.\r\n\r\nHay una gran variedad de margaritas y todas pertenecen a la categoría Chrysanthemun leaucanthemum con excepción de la margarita menor, originaria de Eurasia, a la que se le llama Bellis perennis.','Margarita');
INSERT INTO `datosflores` (`idflor`,`nombrecientifico`,`nombrecomun`,`origen`,`descripcion`,`nombre`) VALUES 
 (87,'Matricaria Chamomilla ','Manzanilla, manzanilla romana, camomila','Nativa de Europa y algunas zonas de Asia. Herbácea anual, \r\nfamilia de las Asteráceas','La manzanilla es una planta aromática y decorativa. Llega a medir cincuenta centímetros o más y posee en todas sus partes un exquisito perfume.\r\nSus tallos son erguidos y finos. \r\nSus hojas son verdes, delgadas y están muy divididas. \r\nPosee bonitas y pequeñas flores con pétalos blancos y centro amarillo.\r\nLa manzanilla crece sola en muchos lugares, campos, al costado de caminos, terrenos baldíos, jardines, etcétera. \r\nSi se planta debe hacerse en primavera, en tierra fértil, aunque resiste muy bien los suelos pobres. Necesita bastante sol y riego moderado exceptuando si hace mucho tiempo que no llueve.\r\nFlorece en primavera.\r\nLa manzanilla no sufre muchas enfermedades y crece también en interiores.\r\n\r\nSe pueden cosechar las cabezuelas de las flores secas y guardarlas secas en un frasco para el próximo año desmenuzarlas y sembrarlas. A los 10-15 días germinarán.\r\n\r\nLa manzanilla es la más conocida de todas las plantas medicinales, pues posee muchísimas propiedades y además es la única hierba que pueden beber en infusión los niños menores de seis años.','Manzanilla'),
 (92,'Viola Odorata','Violeta, viola','Proviene de Europa y Asia. Herbácea perenne, familia de las Violáceas','La violeta es una plantita silvestre que no crece más de quince centímetros. En el jardín es posible formar pequeños espacios que cubrirán por completo el suelo de manera muy bonita.\r\nSus finos tallos sostienen una hoja color verde oscuro en forma de corazón.\r\nSus flores de cinco pétalos poseen un aroma exquisito y pueden ser de color violeta o blanco.\r\n\r\n\r\n\r\nEsta hierba además de adornar los jardines con sus vivas flores, lo perfuma con su delicioso aroma.\r\n\r\n\r\n\r\nSe cultiva de manera fácil y sencilla, en algunos casos se reproduce sola. Cubre lugares donde apenas incide la luz del sol.\r\nSe planta en septiembre y se multiplica por división de la planta adulta.\r\nLa mejor zona del jardín para plantarla es donde no da el sol directamente, ya que prefiere la sombra. Necesita un riego regular, y hay que evitar que el terreno llegue a quedarse seco. \r\nEn condiciones salvajes, las violetas crecen en prados y lugares húmedos, al comenzar la primavera.\r\n\r\n\r\n\r\nLas flores secas se utilizan para la decoración de interiores. \r\nOtras utilidades son en la medicina, química y gastronomía.\r\nSu aroma es un elemento esencial para perfumes y cosméticos.','Violeta');
/*!40000 ALTER TABLE `datosflores` ENABLE KEYS */;


--
-- Definition of table `imagenesflores`
--

DROP TABLE IF EXISTS `imagenesflores`;
CREATE TABLE `imagenesflores` (
  `idimagen` int(10) unsigned NOT NULL auto_increment,
  `nombreimagen` varchar(100) NOT NULL,
  `idflor` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`idimagen`),
  KEY `FK_imagenesflores_1` (`idflor`),
  CONSTRAINT `FK_imagenesflores_1` FOREIGN KEY (`idflor`) REFERENCES `datosflores` (`idflor`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `imagenesflores`
--

/*!40000 ALTER TABLE `imagenesflores` DISABLE KEYS */;
INSERT INTO `imagenesflores` (`idimagen`,`nombreimagen`,`idflor`) VALUES 
 (1,'azucenas1.jpg',1),
 (2,'azucenas8.jpg',1),
 (3,'calendula2.jpg',6),
 (4,'calendula3.jpg',6),
 (5,'cosmos2.jpg',3),
 (6,'cosmos1.jpg',3),
 (7,'cosmos3.jpg',3),
 (8,'ph-112101.jpg',12),
 (9,'dalia.jpg',12),
 (10,'dalia_roja.jpg',12),
 (11,'2011117143812.jpg',23),
 (12,'girasolessswww.jpg',23),
 (13,'girasol.jpg',23),
 (14,'manzanilla1.jpg',87),
 (15,'manzanilla.jpg',87),
 (16,'flores68.jpg',65),
 (17,'rosa roja.jpg',8),
 (18,'rosa_Grand_Hotel_2.jpg',8),
 (19,'rosa_Kortionza_1.jpg',8),
 (20,'rosa-damascena.jpg',8),
 (21,'zinnia-elegans.jpg',24),
 (22,'zinnia-mix.jpg',24),
 (23,'zinniasa.jpg',24),
 (24,'zinnia29.jpg',24),
 (25,'zinniasun.jpg',24),
 (26,'zinnial.jpg',24),
 (27,'viola-odorata-01.jpg',92),
 (28,'fl3508.jpg',24),
 (29,'zinnia-giant-scarlet-300x300.jpg',24),
 (30,'zinnia-scarlet.jpg',24);
/*!40000 ALTER TABLE `imagenesflores` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
