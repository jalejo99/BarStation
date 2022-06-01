-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 01-06-2022 a las 18:33:19
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
-- Estructura de tabla para la tabla `comandas`
--

CREATE TABLE `comandas` (
  `idComandas` int(11) NOT NULL,
  `cedulaCociUsu` int(11) DEFAULT NULL,
  `cedulaCamaUsu` int(11) NOT NULL,
  `idEstado` int(11) NOT NULL,
  `idMesa` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `comandas`
--

INSERT INTO `comandas` (`idComandas`, `cedulaCociUsu`, `cedulaCamaUsu`, `idEstado`, `idMesa`) VALUES
(1, NULL, 1035669887, 2, 1),
(2, 1035878342, 1035669887, 2, 2),
(3, 1035878342, 1035669887, 2, 3),
(4, 1035878342, 1035669887, 2, 1),
(5, 1035878342, 1035669887, 3, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estados`
--

CREATE TABLE `estados` (
  `idEstado` int(11) NOT NULL,
  `estado` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `estados`
--

INSERT INTO `estados` (`idEstado`, `estado`) VALUES
(1, 'Activo'),
(2, 'Inactivo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estados_comandas`
--

CREATE TABLE `estados_comandas` (
  `idEstadosCom` int(11) NOT NULL,
  `estadosCom` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `estados_comandas`
--

INSERT INTO `estados_comandas` (`idEstadosCom`, `estadosCom`) VALUES
(1, 'Realizado'),
(2, 'Finalizado'),
(3, 'Cancelado');

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
(1002, 'Queso mozzarella', 30, 1, '2', 1, 200),
(1003, 'Carne artesanal', 1000, 1, '120', 3, 200),
(1004, 'Papas Francesas', 50, 1, '1', 2, 2500),
(1005, 'Tomate', 50, 1, '5', 1, 100),
(1006, 'Piña', 500, 1, '100', 3, 500),
(1007, 'Punta de anca', 20, 1, '5', 1, 600),
(1008, 'Arepas', 10, 1, '2', 1, 1200),
(1009, 'Pechuga', 100, 1, '10', 1, 400),
(1010, 'Chorizo', 80, 1, '5', 1, 800),
(1012, 'Churrasco', 1000, 1, '150', 3, 20);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `medidas`
--

CREATE TABLE `medidas` (
  `idMedida` int(11) NOT NULL,
  `medida` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `medidas`
--

INSERT INTO `medidas` (`idMedida`, `medida`) VALUES
(1, 'Unidad'),
(2, 'Kilos'),
(3, 'Gramos'),
(4, 'Litros');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mesa`
--

CREATE TABLE `mesa` (
  `idMesas` int(11) NOT NULL,
  `mesa` int(11) NOT NULL,
  `sillas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `mesa`
--

INSERT INTO `mesa` (`idMesas`, `mesa`, `sillas`) VALUES
(1, 1, 4),
(2, 2, 4),
(3, 3, 2),
(4, 4, 4),
(5, 5, 6),
(6, 6, 8);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `platos`
--

CREATE TABLE `platos` (
  `idPlato` int(11) NOT NULL,
  `nombrePlato` varchar(100) NOT NULL,
  `precioPlato` int(11) NOT NULL,
  `idEstado` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `platos`
--

INSERT INTO `platos` (`idPlato`, `nombrePlato`, `precioPlato`, `idEstado`) VALUES
(2001, 'Punta de anca', 26000, 2),
(2002, 'Pechuga gratinada', 21000, 1),
(2003, 'Chorizo sensillo', 8500, 1),
(2004, 'Chorizo Especial', 13500, 1),
(2005, 'Pechuga + Chorizo', 15000, 1),
(2010, 'Pechuga a la mostaza', 21000, 1),
(2011, 'Pechuga', 21000, 1),
(2012, 'Churrasco 150', 24000, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `platos_comandas`
--

CREATE TABLE `platos_comandas` (
  `idPlato` int(11) NOT NULL,
  `idComanda` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `platos_comandas`
--

INSERT INTO `platos_comandas` (`idPlato`, `idComanda`, `cantidad`) VALUES
(2004, 1, 1),
(2002, 1, 2),
(2003, 2, 3),
(2004, 3, 3),
(2011, 4, 1),
(2002, 5, 1),
(2003, 5, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `platos_ingredientes`
--

CREATE TABLE `platos_ingredientes` (
  `idPlato` int(11) NOT NULL,
  `idIngrediente` int(11) NOT NULL,
  `cantIngrediente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `platos_ingredientes`
--

INSERT INTO `platos_ingredientes` (`idPlato`, `idIngrediente`, `cantIngrediente`) VALUES
(2001, 1007, 1),
(2001, 1002, 1),
(2001, 1008, 1),
(2001, 1004, 150),
(2002, 1009, 1),
(2002, 1002, 5),
(2002, 1008, 1),
(2002, 1004, 150),
(2003, 1010, 1),
(2003, 1008, 1),
(2004, 1010, 1),
(2004, 1008, 1),
(2004, 1004, 150),
(2005, 1009, 1),
(2005, 1010, 1),
(2005, 1008, 1),
(2005, 1002, 1),
(2005, 1004, 200),
(2010, 1009, 1),
(2010, 1005, 1),
(2010, 1008, 1),
(2010, 1004, 120),
(2011, 1009, 1),
(2011, 1002, 1),
(2011, 1008, 1),
(2011, 1004, 150),
(2012, 1012, 150),
(2012, 1008, 1),
(2012, 1002, 1),
(2012, 1004, 150);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `idRol` int(11) NOT NULL,
  `rol` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`idRol`, `rol`) VALUES
(2, 'Administrador'),
(3, 'Cocinero'),
(4, 'Mesero');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `cedulaUsu` int(11) NOT NULL,
  `nombreUsu` varchar(500) NOT NULL,
  `apellidoUsu` varchar(100) NOT NULL,
  `correoUsu` varchar(100) NOT NULL,
  `celularUsu` varchar(20) NOT NULL,
  `contraUsu` varchar(100) NOT NULL,
  `idRol` int(11) NOT NULL,
  `idEstado` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`cedulaUsu`, `nombreUsu`, `apellidoUsu`, `correoUsu`, `celularUsu`, `contraUsu`, `idRol`, `idEstado`) VALUES
(5554488, 'Laura', 'Castro', 'Laura123@gmail.com', '123456789', 'Laura123', 3, 1),
(102555442, 'Andres', 'Lizcano', 'Andres123@gmail.com', '2022254', 'Andres123', 4, 1),
(1035669887, 'Manuel', 'Longas Cardona', 'Manuel123@gmail.com', '314558785', 'Manuel123', 4, 1),
(1035878340, 'Daniel', 'Bustamante', 'Daniel123@gmail.com', '31974645555', 'Daniel123', 2, 1),
(1035878341, 'Juan Camilo', 'Perez Lopez', 'Juancamilo123@gmail.com', '123456', 'Juan123', 2, 1),
(1035878342, 'Luisa', 'Herrera Orlas', 'Luisa123@gmail.com', '3125445587', 'Luisa123', 3, 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `comandas`
--
ALTER TABLE `comandas`
  ADD PRIMARY KEY (`idComandas`),
  ADD KEY `FK_Camarero` (`cedulaCamaUsu`),
  ADD KEY `FK_Cocinero` (`cedulaCociUsu`),
  ADD KEY `FK_Comandas_Estado` (`idEstado`),
  ADD KEY `FK_Mesa` (`idMesa`);

--
-- Indices de la tabla `estados`
--
ALTER TABLE `estados`
  ADD PRIMARY KEY (`idEstado`),
  ADD UNIQUE KEY `idEstado` (`idEstado`);

--
-- Indices de la tabla `estados_comandas`
--
ALTER TABLE `estados_comandas`
  ADD PRIMARY KEY (`idEstadosCom`);

--
-- Indices de la tabla `ingredientes`
--
ALTER TABLE `ingredientes`
  ADD PRIMARY KEY (`idIngredientes`),
  ADD KEY `FK_Estado` (`idEstado`),
  ADD KEY `idMedida` (`idMedida`);

--
-- Indices de la tabla `medidas`
--
ALTER TABLE `medidas`
  ADD PRIMARY KEY (`idMedida`);

--
-- Indices de la tabla `mesa`
--
ALTER TABLE `mesa`
  ADD PRIMARY KEY (`idMesas`);

--
-- Indices de la tabla `platos`
--
ALTER TABLE `platos`
  ADD PRIMARY KEY (`idPlato`),
  ADD KEY `FK_Plato_Estado` (`idEstado`);

--
-- Indices de la tabla `platos_comandas`
--
ALTER TABLE `platos_comandas`
  ADD KEY `FK_Plato_Comanda_Com` (`idComanda`),
  ADD KEY `FK_Plato_Comanda_PL` (`idPlato`);

--
-- Indices de la tabla `platos_ingredientes`
--
ALTER TABLE `platos_ingredientes`
  ADD KEY `FK_Plato_Ingredientes_PL` (`idPlato`),
  ADD KEY `FK_Plato_Ingredientes_ING` (`idIngrediente`);

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`idRol`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`cedulaUsu`),
  ADD KEY `FK_Rol` (`idRol`),
  ADD KEY `FK_Usuario_Estado` (`idEstado`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `comandas`
--
ALTER TABLE `comandas`
  MODIFY `idComandas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `estados`
--
ALTER TABLE `estados`
  MODIFY `idEstado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `estados_comandas`
--
ALTER TABLE `estados_comandas`
  MODIFY `idEstadosCom` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `ingredientes`
--
ALTER TABLE `ingredientes`
  MODIFY `idIngredientes` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2312314;

--
-- AUTO_INCREMENT de la tabla `medidas`
--
ALTER TABLE `medidas`
  MODIFY `idMedida` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `mesa`
--
ALTER TABLE `mesa`
  MODIFY `idMesas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `platos`
--
ALTER TABLE `platos`
  MODIFY `idPlato` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=123123124;

--
-- AUTO_INCREMENT de la tabla `roles`
--
ALTER TABLE `roles`
  MODIFY `idRol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `cedulaUsu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1035878344;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `comandas`
--
ALTER TABLE `comandas`
  ADD CONSTRAINT `FK_Camarero` FOREIGN KEY (`cedulaCamaUsu`) REFERENCES `usuarios` (`cedulaUsu`),
  ADD CONSTRAINT `FK_Cocinero` FOREIGN KEY (`cedulaCociUsu`) REFERENCES `usuarios` (`cedulaUsu`),
  ADD CONSTRAINT `FK_Comandas_Estado` FOREIGN KEY (`idEstado`) REFERENCES `estados_comandas` (`idEstadosCom`),
  ADD CONSTRAINT `FK_Mesa` FOREIGN KEY (`idMesa`) REFERENCES `mesa` (`idMesas`);

--
-- Filtros para la tabla `ingredientes`
--
ALTER TABLE `ingredientes`
  ADD CONSTRAINT `FK_Estado` FOREIGN KEY (`idEstado`) REFERENCES `estados` (`idEstado`),
  ADD CONSTRAINT `ingredientes_ibfk_1` FOREIGN KEY (`idMedida`) REFERENCES `medidas` (`idMedida`);

--
-- Filtros para la tabla `platos`
--
ALTER TABLE `platos`
  ADD CONSTRAINT `FK_Plato_Estado` FOREIGN KEY (`idEstado`) REFERENCES `estados` (`idEstado`);

--
-- Filtros para la tabla `platos_comandas`
--
ALTER TABLE `platos_comandas`
  ADD CONSTRAINT `FK_Plato_Comanda_Com` FOREIGN KEY (`idComanda`) REFERENCES `comandas` (`idComandas`),
  ADD CONSTRAINT `FK_Plato_Comanda_PL` FOREIGN KEY (`idPlato`) REFERENCES `platos` (`idPlato`);

--
-- Filtros para la tabla `platos_ingredientes`
--
ALTER TABLE `platos_ingredientes`
  ADD CONSTRAINT `FK_Plato_Ingredientes_ING` FOREIGN KEY (`idIngrediente`) REFERENCES `ingredientes` (`idIngredientes`),
  ADD CONSTRAINT `FK_Plato_Ingredientes_PL` FOREIGN KEY (`idPlato`) REFERENCES `platos` (`idPlato`);

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `FK_Rol` FOREIGN KEY (`idRol`) REFERENCES `roles` (`idRol`),
  ADD CONSTRAINT `FK_Usuario_Estado` FOREIGN KEY (`idEstado`) REFERENCES `estados` (`idEstado`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
