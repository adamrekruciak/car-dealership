-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 02 Kwi 2023, 22:02
-- Wersja serwera: 10.4.27-MariaDB
-- Wersja PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `komisdb`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `image`
--

CREATE TABLE `image` (
  `id_obrazek` int(11) NOT NULL,
  `filename` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `image`
--

INSERT INTO `image` (`id_obrazek`, `filename`) VALUES
(0, 'bmwe60inside.jpg'),
(1, 'bmwe46.jpg'),
(2, 'bmwe36-1.jpg'),
(3, 'bmwe36-2.jpg'),
(4, 'bmwe36-3.jpg'),
(5, 'bmwe36-4.jpg'),
(6, 'bmwe60.jpg'),
(7, 'audia3-1.jpg'),
(8, 'audia4-1.jpg'),
(9, 'audirs61-1.jpg'),
(10, 'mercedesaklasa1-1.jpg'),
(11, 'mercedesbklasa1-1.jpg'),
(12, 'mercedescklasa1-1.jpg'),
(13, 'vwpolo1-1.jpg'),
(14, 'vwpassat1-1.jpg'),
(15, 'vwgolf1-1.jpg'),
(16, 'opelastra1-1.jpg'),
(17, 'opelcorsa1-1.jpg'),
(18, 'opelcalibra1-1.jpg'),
(19, 'porsche9111-1.jpg'),
(20, 'porshepanamera1-1.jpg'),
(21, 'cayenne1-1.jpg'),
(22, 'bmwe39.jpg'),
(23, 'audirs6.jpg'),
(24, 'bmwe36-1inside.jpg'),
(25, 'bmwe36-2tyl.jpg'),
(26, 'bmwe60inside.jpg'),
(27, 'bmwe60front.jpg'),
(28, 'bmwe39back.jpg'),
(29, 'audia3back.jpg'),
(30, 'golf4inside.jpg'),
(31, 'corsainside.jpg');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `marka`
--

CREATE TABLE `marka` (
  `id_marka` int(11) NOT NULL,
  `nazwa_marka` varchar(200) DEFAULT NULL,
  `kraj` varchar(2000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `marka`
--

INSERT INTO `marka` (`id_marka`, `nazwa_marka`, `kraj`) VALUES
(1, 'BMW', 'Niemcy'),
(2, 'Audi', 'Niemcy'),
(3, 'Mercedes', 'Niemcy'),
(4, 'Volkswagen', 'Niemcy'),
(5, 'Opel', 'Niemcy'),
(6, 'Porsche', 'Niemcy');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `model`
--

CREATE TABLE `model` (
  `id_model` int(11) NOT NULL,
  `nazwa_model` varchar(200) DEFAULT NULL,
  `naped` varchar(200) DEFAULT NULL,
  `marka_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `model`
--

INSERT INTO `model` (`id_model`, `nazwa_model`, `naped`, `marka_id`) VALUES
(1, 'E46', 'RWD', 1),
(2, 'E36', 'RWD', 1),
(3, 'E60', 'RWD', 1),
(5, 'A3', 'RWD', 2),
(6, 'A4', 'RWD', 2),
(7, 'A KLASA', 'RWD', 3),
(8, 'B KLASA ', 'RWD', 3),
(9, 'C KLASA', 'RWD', 3),
(10, 'Polo', 'FWD', 4),
(11, 'Passat', 'FWD', 4),
(12, 'Golf', 'FWD', 4),
(13, 'Astra', 'FWD', 5),
(14, 'Corsa', 'FWD', 5),
(15, 'Calibra', 'FWD', 5),
(16, '911', 'RWD', 6),
(17, 'Panamera', 'AWD', 6),
(18, 'Cayenne', 'AWD', 6),
(19, 'RS6', 'AWD', 2),
(20, 'E39', 'RWD', 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pojazd`
--

CREATE TABLE `pojazd` (
  `id_pojazd` int(11) NOT NULL,
  `cena` int(11) DEFAULT NULL,
  `rok_produkcji` varchar(4) DEFAULT NULL,
  `przebieg` int(11) DEFAULT NULL,
  `silnik` varchar(40) DEFAULT NULL,
  `moc` int(11) DEFAULT NULL,
  `rodzaj_paliwa` varchar(30) DEFAULT NULL,
  `stan_techniczny` varchar(50) DEFAULT NULL,
  `kolor` varchar(50) DEFAULT NULL,
  `skrzynia_biegow` varchar(50) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `VIN` varchar(18) DEFAULT NULL,
  `faktura` varchar(3) DEFAULT NULL,
  `model_id` int(11) NOT NULL,
  `id_obrazek` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `pojazd`
--

INSERT INTO `pojazd` (`id_pojazd`, `cena`, `rok_produkcji`, `przebieg`, `silnik`, `moc`, `rodzaj_paliwa`, `stan_techniczny`, `kolor`, `skrzynia_biegow`, `status`, `VIN`, `faktura`, `model_id`, `id_obrazek`) VALUES
(2, 6000, '2002', 248000, '2.5', 192, 'Benzyna', 'Nieuszkodzony', 'Zielony', 'Manualna', 'Dostępny', 'VF1RFB00154724294', 'Tak', 2, 5),
(3, 13000, '2004', 128500, '2.0', 240, 'Benzyna', 'Nieuszkodzony', 'Bialy', 'Manualna', 'Dostępny', 'WE1RFB01154723334', 'Tak', 2, 3),
(4, 9800, '2002', 148520, '1.9', 150, 'Benzyna', 'Uszkodzony', 'Czerwony', 'Manualna', 'Dostępny', 'WE1RFB01154723334', 'Tak', 2, 1),
(5, 24100, '2003', 95000, '1.8', 162, 'Diesel', 'Nieuszkodzony', 'Bialy', 'Manualna', 'Dostępny', 'WE1RFB01154723334', 'Tak', 3, 3),
(6, 18500, '1998', 98500, '1.4', 112, 'Diesel', 'Uszkodzony', 'Czarny', 'Automat', 'Dostępny', 'WE1RFB01154723334', 'Tak', 3, 8),
(7, 11100, '1995', 101500, '1.4', 152, 'LPG', 'Nieuszkodzony', 'Czarny', 'Automat', 'Dostępny', 'WE1RFB01154723334', 'Tak', 5, 9),
(8, 9800, '2010', 111200, '1.6', 70, 'LPG', 'Nieuszkodzony', 'Czerwony', 'Automat', 'Dostępny', 'WE1RFB01154723334', 'Tak', 6, 9),
(10, 114000, '2012', 318500, '1.4', 144, 'Benzyna', 'Nieuszkodzony', 'Szary', 'Automat', 'Niedostępny', 'WE1RFB01154723334', 'Tak', 7, 10),
(11, 49200, '2011', 192500, '2.5', 320, 'Benzyna', 'Nieuszkodzony', 'Niebieski', 'Manualna', 'Niedostępny', 'WE1RFB01154723334', 'Tak', 8, 11),
(12, 171000, '2008', 128500, '3.0', 320, 'Benzyna', 'Nieuszkodzony', 'Niebieski', 'Manualna', 'Niedostępny', 'WE1RFB01154723334', 'Nie', 9, 11),
(13, 16999, '2006', 199910, '2.5', 192, 'Benzyna', 'Nieuszkodzony', 'Srebrny', 'Automat', 'Dostępny', 'WE1RFB01154723334', 'Tak', 10, 13),
(14, 7000, '2004', 215510, '3.0', 245, 'Benzyna', 'Nieuszkodzony', 'Niebieski', 'Manualna', 'Dostępny', 'WE1RFB01154723334', 'Tak', 11, 14),
(15, 6500, '2005', 998400, '2.0', 186, 'Diesel', 'Nieuszkodzony', 'Zielony', 'Manualna', 'Dostępny', 'WE1RFB01154723334', 'Tak', 12, 15),
(16, 22790, '2007', 2712510, '2.2', 170, 'Diesel', 'Nieuszkodzony', 'Niebieski', 'Automat', 'Dostępny', 'WE1RFB01154723399', 'Nie', 13, 16),
(17, 8500, '2007', 2712510, '2.2', 170, 'Benzyna + LPG', 'Nieuszkodzony', 'Żółty', 'Automat', 'Dostępny', 'WPA3301154723312', 'Tak', 14, 17),
(18, 210500, '1996', 11450, '4.2', 340, 'Benzyna', 'Nieuszkodzony', 'Czarny', 'Manual', 'Dostępny', 'WE1RFB01154723334', 'Tak', 15, 18),
(19, 347900, '2007', 2712510, '2.2', 170, 'Elektryczny', 'Nieuszkodzony', 'Czarny', 'Automat', 'Dostępny', 'WPA3301154723312', 'Tak', 16, 19),
(20, 210500, '2019', 114510, '4.2', 340, 'Benzyna', 'Nieuszkodzony', 'Czarny', 'Automat', 'Dostępny', 'WE1RFB01154723334', 'Tak', 17, 20),
(21, 179000, '2022', 712510, '5.0', 490, 'Diesel', 'Nieuszkodzony', 'Bialy', 'Manual', 'Dostępny', 'WE1RFB01154723334', 'Tak', 18, 21),
(22, 26900, '1998', 217000, '3.0', 320, 'Benzyna', 'Nieuszkodzony', 'Żółty', 'Automat', 'Dostępny', 'JH4DB7550RS000461', 'Tak', 20, 23);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pojazd_images`
--

CREATE TABLE `pojazd_images` (
  `id_pojazd` int(11) NOT NULL,
  `id_obrazek` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Zrzut danych tabeli `pojazd_images`
--

INSERT INTO `pojazd_images` (`id_pojazd`, `id_obrazek`) VALUES
(2, 2),
(2, 24),
(3, 3),
(3, 25),
(4, 1),
(4, 26),
(5, 3),
(5, 27),
(22, 23),
(22, 28),
(22, 23),
(22, 28),
(7, 9),
(7, 29),
(15, 15),
(15, 30),
(17, 17),
(17, 31);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `image`
--
ALTER TABLE `image`
  ADD PRIMARY KEY (`id_obrazek`);

--
-- Indeksy dla tabeli `marka`
--
ALTER TABLE `marka`
  ADD PRIMARY KEY (`id_marka`);

--
-- Indeksy dla tabeli `model`
--
ALTER TABLE `model`
  ADD PRIMARY KEY (`id_model`),
  ADD KEY `marka_id` (`marka_id`);

--
-- Indeksy dla tabeli `pojazd`
--
ALTER TABLE `pojazd`
  ADD PRIMARY KEY (`id_pojazd`),
  ADD KEY `model_id` (`model_id`),
  ADD KEY `id_obrazek` (`id_obrazek`);

--
-- Indeksy dla tabeli `pojazd_images`
--
ALTER TABLE `pojazd_images`
  ADD KEY `id_pojazd` (`id_pojazd`),
  ADD KEY `id_obrazek` (`id_obrazek`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `marka`
--
ALTER TABLE `marka`
  MODIFY `id_marka` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `model`
--
ALTER TABLE `model`
  MODIFY `id_model` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT dla tabeli `pojazd`
--
ALTER TABLE `pojazd`
  MODIFY `id_pojazd` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `model`
--
ALTER TABLE `model`
  ADD CONSTRAINT `model_ibfk_1` FOREIGN KEY (`marka_id`) REFERENCES `marka` (`id_marka`);

--
-- Ograniczenia dla tabeli `pojazd`
--
ALTER TABLE `pojazd`
  ADD CONSTRAINT `pojazd_ibfk_1` FOREIGN KEY (`model_id`) REFERENCES `model` (`id_model`);

--
-- Ograniczenia dla tabeli `pojazd_images`
--
ALTER TABLE `pojazd_images`
  ADD CONSTRAINT `pojazd_images_ibfk_1` FOREIGN KEY (`id_obrazek`) REFERENCES `image` (`id_obrazek`),
  ADD CONSTRAINT `pojazd_images_ibfk_2` FOREIGN KEY (`id_pojazd`) REFERENCES `pojazd` (`id_pojazd`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
