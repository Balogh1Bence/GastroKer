-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2019. Már 03. 08:57
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
-- Adatbázis: `gastro`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `bej`
--

CREATE TABLE `bej` (
  `IntAzon` int(11) NOT NULL,
  `Tkod` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `bej`
--

INSERT INTO `bej` (`IntAzon`, `Tkod`) VALUES
(2000, 3),
(2000, 4),
(2001, 1),
(2001, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `besz`
--

CREATE TABLE `besz` (
  `azon` int(4) NOT NULL,
  `nev` varchar(30) COLLATE utf16_hungarian_ci NOT NULL,
  `tel` int(10) NOT NULL,
  `email` varchar(40) COLLATE utf16_hungarian_ci NOT NULL,
  `kapcsnev` varchar(40) COLLATE utf16_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_hungarian_ci;

--
-- A tábla adatainak kiíratása `besz`
--

INSERT INTO `besz` (`azon`, `nev`, `tel`, `email`, `kapcsnev`) VALUES
(2000, 'Hertz', 63333333, 'apacshelikopter1998@gmail.com', 'Lakatos Roz?lia'),
(2001, 'Fagyok kft', 64444444, 'apacshelikopter1998@gmail.com', 'Z?ld Istv?n');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `helyek`
--

CREATE TABLE `helyek` (
  `HelyAzon` int(10) NOT NULL,
  `IntAzon` int(11) NOT NULL,
  `irsz` int(4) NOT NULL,
  `varos` text NOT NULL,
  `utca` text NOT NULL,
  `szam` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `helyek`
--

INSERT INTO `helyek` (`HelyAzon`, `IntAzon`, `irsz`, `varos`, `utca`, `szam`) VALUES
(1, 1000, 6666, 'Szeged', 'Kis', 45),
(2, 1001, 9999, 'K?bekh?za', 'Nagy', 54),
(3, 1001, 7777, 'Miskolc', 'Csereszny', 30),
(4, 1000, 5555, '?jszentiv?n', 'Kossuth', 70);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kat`
--

CREATE TABLE `kat` (
  `Tkatkod` int(11) NOT NULL,
  `Tkatnev` varchar(20) COLLATE utf16_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_hungarian_ci;

--
-- A tábla adatainak kiíratása `kat`
--

INSERT INTO `kat` (`Tkatkod`, `Tkatnev`) VALUES
(1, 'kolb?sz'),
(2, 'tej'),
(3, 'csirkeh?s');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `regitermekek`
--

CREATE TABLE `regitermekek` (
  `Tkod` int(11) NOT NULL,
  `Tnev` varchar(30) CHARACTER SET utf16 COLLATE utf16_hungarian_ci NOT NULL,
  `Tar` int(11) NOT NULL,
  `Tkeszl` int(11) NOT NULL,
  `Tmert` varchar(30) CHARACTER SET utf16 COLLATE utf16_hungarian_ci NOT NULL,
  `Tkatkod` int(11) NOT NULL,
  `Tvonkod` int(20) NOT NULL,
  `Tszavido` date NOT NULL,
  `Tegalizalte` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `regitermekek`
--

INSERT INTO `regitermekek` (`Tkod`, `Tnev`, `Tar`, `Tkeszl`, `Tmert`, `Tkatkod`, `Tvonkod`, `Tszavido`, `Tegalizalte`) VALUES
(1, 'kolbi', 500, 350, 'kg', 1, 132784678, '0000-00-00', 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rend`
--

CREATE TABLE `rend` (
  `Tkod` int(11) NOT NULL,
  `Tmenny` int(11) NOT NULL,
  `Vnev` varchar(50) NOT NULL,
  `Vdate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szall`
--

CREATE TABLE `szall` (
  `Azon` int(11) NOT NULL,
  `tkod` int(11) NOT NULL,
  `datum` date NOT NULL,
  `menny` int(11) NOT NULL,
  `ar` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_hungarian_ci;

--
-- A tábla adatainak kiíratása `szall`
--

INSERT INTO `szall` (`Azon`, `tkod`, `datum`, `menny`, `ar`) VALUES
(1, 1, '2018-01-01', 45, 250),
(1, 2, '2018-01-01', 45, 300);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamla`
--

CREATE TABLE `szamla` (
  `nyugtaszam` int(50) NOT NULL,
  `datum` date NOT NULL,
  `Vkod` int(11) NOT NULL,
  `osszeg` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamla`
--

INSERT INTO `szamla` (`nyugtaszam`, `datum`, `Vkod`, `osszeg`) VALUES
(1234123, '2018-01-01', 1001, 234123);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamlatetel`
--

CREATE TABLE `szamlatetel` (
  `nyugtaszam` int(50) NOT NULL,
  `Tkod` int(6) NOT NULL,
  `menny` int(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamlatetel`
--

INSERT INTO `szamlatetel` (`nyugtaszam`, `Tkod`, `menny`) VALUES
(1234123, 1, 3),
(1234123, 2, 45);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termekek`
--

CREATE TABLE `termekek` (
  `Tkod` int(11) NOT NULL,
  `Tnev` varchar(30) COLLATE utf16_hungarian_ci NOT NULL,
  `Tar` int(11) NOT NULL,
  `Tkeszl` int(11) NOT NULL,
  `Tmert` varchar(30) COLLATE utf16_hungarian_ci NOT NULL,
  `Tkatkod` int(11) NOT NULL,
  `Tvonkod` int(20) NOT NULL,
  `Tszavido` date NOT NULL,
  `Tegalizalte` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_hungarian_ci;

--
-- A tábla adatainak kiíratása `termekek`
--

INSERT INTO `termekek` (`Tkod`, `Tnev`, `Tar`, `Tkeszl`, `Tmert`, `Tkatkod`, `Tvonkod`, `Tszavido`, `Tegalizalte`) VALUES
(1, 'kolbi', 300, 350, 'kg', 1, 121234, '2018-02-03', 1),
(2, 'kolbika', 400, 450, 'kg', 1, 3456633, '2018-11-01', 1),
(3, 'fagyos csirkecomb', 900, 300, 'kb', 3, 3452622, '2019-11-01', 1),
(4, 'f?lzs?ros tej', 150, 20, 'li', 2, 287364, '2019-11-01', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vevok`
--

CREATE TABLE `vevok` (
  `azon` int(4) NOT NULL,
  `nev` varchar(30) COLLATE utf16_hungarian_ci NOT NULL,
  `adoazon` int(8) NOT NULL,
  `banksz` bigint(24) NOT NULL,
  `tel` int(30) NOT NULL,
  `dolg` tinyint(1) NOT NULL,
  `torzs` tinyint(1) NOT NULL,
  `vasmenny` int(11) NOT NULL,
  `felh` varchar(30) COLLATE utf16_hungarian_ci NOT NULL,
  `jelsz` varchar(30) COLLATE utf16_hungarian_ci NOT NULL,
  `email` varchar(30) COLLATE utf16_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf16 COLLATE=utf16_hungarian_ci;

--
-- A tábla adatainak kiíratása `vevok`
--

INSERT INTO `vevok` (`azon`, `nev`, `adoazon`, `banksz`, `tel`, `dolg`, `torzs`, `vasmenny`, `felh`, `jelsz`, `email`) VALUES
(1000, 'Kiss G?za', 87623498, 9843716298654585, 701111111, 0, 1, 550, 'KissJozsef', '123456', 'apacshelikopter1998@gmail.com'),
(1001, 'Nagy B?la', 29832749, 8297465738977561, 302222222, 1, 1, 0, 'NagyBela', '123456', 'apacshelikopter1998@gmail.com');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `bej`
--
ALTER TABLE `bej`
  ADD PRIMARY KEY (`IntAzon`,`Tkod`);

--
-- A tábla indexei `besz`
--
ALTER TABLE `besz`
  ADD PRIMARY KEY (`azon`);

--
-- A tábla indexei `helyek`
--
ALTER TABLE `helyek`
  ADD PRIMARY KEY (`HelyAzon`);

--
-- A tábla indexei `kat`
--
ALTER TABLE `kat`
  ADD PRIMARY KEY (`Tkatkod`);

--
-- A tábla indexei `regitermekek`
--
ALTER TABLE `regitermekek`
  ADD PRIMARY KEY (`Tkod`);

--
-- A tábla indexei `rend`
--
ALTER TABLE `rend`
  ADD PRIMARY KEY (`Vnev`,`Tkod`);

--
-- A tábla indexei `szall`
--
ALTER TABLE `szall`
  ADD PRIMARY KEY (`Azon`,`tkod`);

--
-- A tábla indexei `szamla`
--
ALTER TABLE `szamla`
  ADD PRIMARY KEY (`Vkod`);

--
-- A tábla indexei `szamlatetel`
--
ALTER TABLE `szamlatetel`
  ADD PRIMARY KEY (`nyugtaszam`,`Tkod`);

--
-- A tábla indexei `termekek`
--
ALTER TABLE `termekek`
  ADD PRIMARY KEY (`Tkod`);

--
-- A tábla indexei `vevok`
--
ALTER TABLE `vevok`
  ADD PRIMARY KEY (`azon`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `besz`
--
ALTER TABLE `besz`
  MODIFY `azon` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2002;

--
-- AUTO_INCREMENT a táblához `helyek`
--
ALTER TABLE `helyek`
  MODIFY `HelyAzon` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `kat`
--
ALTER TABLE `kat`
  MODIFY `Tkatkod` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `termekek`
--
ALTER TABLE `termekek`
  MODIFY `Tkod` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `vevok`
--
ALTER TABLE `vevok`
  MODIFY `azon` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1002;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
