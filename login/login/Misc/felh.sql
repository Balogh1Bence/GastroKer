-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2019. Már 15. 09:12
-- Kiszolgáló verziója: 10.1.37-MariaDB
-- PHP verzió: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `felh`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `deskusers`
--

CREATE TABLE `deskusers` (
  `azon` int(11) NOT NULL,
  `username` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `email` varchar(40) NOT NULL,
  `utols` date NOT NULL,
  `jog` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `deskusers`
--

INSERT INTO `deskusers` (`azon`, `username`, `password`, `email`, `utols`, `jog`) VALUES
(1, 'abrlin', '123456', 'baloghbencefacebook@gmail.com', '2001-01-01', 'vez'),
(2, 'nagcso', '123456', 'lujzza08@gmail.com', '2019-01-01', 'rak'),
(3, 'admin', 'admin', 'baloghbencefacebook@gmail.com', '2001-01-01', 'admin'),
(4, 'kirmar', '123456', 'lujzza08@gmail.com', '2019-01-01', 'ugy');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `deskusers`
--
ALTER TABLE `deskusers`
  ADD PRIMARY KEY (`azon`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `deskusers`
--
ALTER TABLE `deskusers`
  MODIFY `azon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
