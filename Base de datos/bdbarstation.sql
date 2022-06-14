-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-06-2022 a las 14:28:55
-- Versión del servidor: 10.4.22-MariaDB
-- Versión de PHP: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bdbarstation`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ingredientes`
--

CREATE TABLE `ingredientes` (
  `idIngredientes` int(11) NOT NULL,
  `nombreIngredientes` varchar(100) NOT NULL,
  `cantidadIngredientes` int(11) NOT NULL,
  `idEstado` int(11) NOT NULL,
  `cantMinIngredientes` varchar(100) NOT NULL,
  `idMedida` int(11) NOT NULL,
  `precioUni` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ingredientes`
--

INSERT INTO `ingredientes` (`idIngredientes`, `nombreIngredientes`, `cantidadIngredientes`, `idEstado`, `cantMinIngredientes`, `idMedida`, `precioUni`) VALUES
(1001, 'Tosineta', 500, 1, '100', 3, 10),
(1002, 'Queso mozzarella', 24, 1, '2', 1, 200),
(1003, 'Carne artesanal', 1000, 1, '120', 3, 200),
(1004, 'Papas Francesas', 3320, 1, '100', 3, 2500),
(1005, 'Tomate', 46, 1, '5', 1, 100),
(1006, 'Piña', 500, 1, '100', 3, 500),
(1007, 'Punta de anca', 17, 1, '5', 1, 600),
(1008, 'Arepas', 6, 1, '2', 1, 1200),
(1009, 'Pechuga', 93, 1, '10', 1, 400),
(1010, 'Chorizo', 61, 1, '5', 1, 800),
(1012, 'Churrasco', 1000, 1, '150', 3, 20);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `ingredientes`
--
ALTER TABLE `ingredientes`
  ADD PRIMARY KEY (`idIngredientes`),
  ADD KEY `FK_Estado` (`idEstado`),
  ADD KEY `idMedida` (`idMedida`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `ingredientes`
--
ALTER TABLE `ingredientes`
  MODIFY `idIngredientes` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2312314;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `ingredientes`
--
ALTER TABLE `ingredientes`
  ADD CONSTRAINT `FK_Estado` FOREIGN KEY (`idEstado`) REFERENCES `estados` (`idEstado`),
  ADD CONSTRAINT `ingredientes_ibfk_1` FOREIGN KEY (`idMedida`) REFERENCES `medidas` (`idMedida`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
