-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versi server:                 10.4.32-MariaDB - mariadb.org binary distribution
-- OS Server:                    Win64
-- HeidiSQL Versi:               12.10.0.7000
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Membuang struktur basisdata untuk db_kasir_kambing77
CREATE DATABASE IF NOT EXISTS `db_kasir_kambing77` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `db_kasir_kambing77`;

-- membuang struktur untuk table db_kasir_kambing77.tbl_kategori
CREATE TABLE IF NOT EXISTS `tbl_kategori` (
  `id_kategori` int(11) NOT NULL AUTO_INCREMENT,
  `nama_kategori` varchar(100) NOT NULL,
  PRIMARY KEY (`id_kategori`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Membuang data untuk tabel db_kasir_kambing77.tbl_kategori: ~12 rows (lebih kurang)
INSERT INTO `tbl_kategori` (`id_kategori`, `nama_kategori`) VALUES
	(1, 'SAPI BAKAR'),
	(2, 'SATE SAPI'),
	(3, 'ROGAN JOSH SAPI'),
	(4, 'SAPI SAMBAL PEDAS'),
	(5, 'GULAI SAPI'),
	(6, 'SOP SAPI'),
	(7, 'TENGKLENG SAPI'),
	(8, 'TONGSENG SAPI LADA HITAM'),
	(9, 'SAPI ASAM MANIS'),
	(10, 'MENU AYAM'),
	(11, 'NASI'),
	(12, 'MINUMAN');

-- membuang struktur untuk table db_kasir_kambing77.tbl_laporan
CREATE TABLE IF NOT EXISTS `tbl_laporan` (
  `id_laporan` int(11) NOT NULL AUTO_INCREMENT,
  `id_transaksi_grup` varchar(50) NOT NULL,
  `waktu_transaksi` datetime NOT NULL,
  `nama_menu` varchar(255) NOT NULL,
  `harga_satuan` decimal(10,2) NOT NULL,
  `jumlah` int(11) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id_laporan`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Membuang data untuk tabel db_kasir_kambing77.tbl_laporan: ~10 rows (lebih kurang)
INSERT INTO `tbl_laporan` (`id_laporan`, `id_transaksi_grup`, `waktu_transaksi`, `nama_menu`, `harga_satuan`, `jumlah`, `subtotal`) VALUES
	(1, '20240115-101', '2024-01-15 12:30:15', 'Gulai Sapi', 90000.00, 2, 180000.00),
	(2, '20240115-101', '2024-01-15 12:30:15', 'Nasi Putih', 8000.00, 2, 16000.00),
	(3, '20240115-101', '2024-01-15 12:30:15', 'Teh Manis - Dingin', 8000.00, 1, 8000.00),
	(4, '20240115-101', '2024-01-15 12:30:15', 'Kerupuk', 6000.00, 2, 12000.00),
	(5, '20240322-102', '2024-03-22 19:05:40', 'Sate Sapi', 75000.00, 2, 150000.00),
	(6, '20240322-102', '2024-03-22 19:05:40', 'Nasi Putih', 8000.00, 2, 16000.00),
	(7, '20240322-102', '2024-03-22 19:05:40', 'Air Mineral', 5000.00, 2, 10000.00),
	(8, '20240501-103', '2024-05-01 20:15:10', 'Iga Bakar Denok', 210000.00, 1, 210000.00),
	(9, '20240501-103', '2024-05-01 20:15:10', 'Nasi Putih', 8000.00, 1, 8000.00),
	(10, '20240501-103', '2024-05-01 20:15:10', 'Lemon Tea - Panas', 19000.00, 1, 19000.00);

-- membuang struktur untuk table db_kasir_kambing77.tbl_menu
CREATE TABLE IF NOT EXISTS `tbl_menu` (
  `id_menu` int(11) NOT NULL AUTO_INCREMENT,
  `id_kategori` int(11) NOT NULL,
  `nama_menu` varchar(255) NOT NULL,
  `harga` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id_menu`),
  KEY `id_kategori` (`id_kategori`),
  CONSTRAINT `tbl_menu_ibfk_1` FOREIGN KEY (`id_kategori`) REFERENCES `tbl_kategori` (`id_kategori`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Membuang data untuk tabel db_kasir_kambing77.tbl_menu: ~62 rows (lebih kurang)
INSERT INTO `tbl_menu` (`id_menu`, `id_kategori`, `nama_menu`, `harga`) VALUES
	(1, 1, 'IGA Denok', 210000.00),
	(2, 1, 'Lidah Sapi', 180000.00),
	(3, 2, 'Daging', 75000.00),
	(4, 2, 'Maranggi', 75000.00),
	(5, 2, 'Sosis Sapi', 110000.00),
	(6, 3, 'Sengkel', 95000.00),
	(7, 3, 'Kikil', 95000.00),
	(8, 3, 'Buntut', 95000.00),
	(9, 3, 'Iga', 90000.00),
	(10, 3, 'Daging', 90000.00),
	(11, 4, 'Iga', 210000.00),
	(12, 4, 'Lidah', 180000.00),
	(13, 4, 'Kikil', 90000.00),
	(14, 5, 'Sengkel', 90000.00),
	(15, 5, 'Kikil', 90000.00),
	(16, 5, 'Buntut', 90000.00),
	(17, 5, 'Iga', 90000.00),
	(18, 5, 'Daging', 90000.00),
	(19, 5, 'Kaki Sapi (utuh +- 2.5 kg)', 290000.00),
	(20, 6, 'Sengkel', 90000.00),
	(21, 6, 'Kikil', 90000.00),
	(22, 6, 'Buntut', 90000.00),
	(23, 6, 'Iga', 90000.00),
	(24, 6, 'Daging', 75000.00),
	(25, 6, 'Kaki Sapi (utuh +- 2.5 kg)', 290000.00),
	(26, 7, 'Sengkel', 90000.00),
	(27, 7, 'Kikil', 90000.00),
	(28, 7, 'Buntut', 90000.00),
	(29, 7, 'Iga', 90000.00),
	(30, 7, 'Daging', 75000.00),
	(31, 7, 'Kaki Sapi (utuh +- 2.5 kg)', 290000.00),
	(32, 8, 'Daging Sapi', 75000.00),
	(33, 8, 'Sengkel', 90000.00),
	(34, 8, 'Kikil', 90000.00),
	(35, 8, 'Iga', 90000.00),
	(36, 8, 'Daging', 75000.00),
	(37, 9, 'Sengkel', 90000.00),
	(38, 9, 'Daging', 75000.00),
	(39, 9, 'Kikil', 90000.00),
	(40, 9, 'Iga', 85000.00),
	(41, 10, 'Bakar', 45000.00),
	(42, 10, 'Sop Ayam (Kampung)', 150000.00),
	(43, 10, 'Sate Ayam', 45000.00),
	(44, 10, 'Sosis Ayam', 85000.00),
	(45, 11, 'Nasi Putih', 8000.00),
	(46, 11, 'Emping', 12000.00),
	(47, 11, 'Kerupuk', 6000.00),
	(48, 12, 'Lemon Tea - Panas', 19000.00),
	(49, 12, 'Lemon Tea - Dingin', 19000.00),
	(50, 12, 'Teh Poci + Gula Batu', 27000.00),
	(51, 12, 'Teh Manis - Panas', 8000.00),
	(52, 12, 'Teh Manis - Dingin', 8000.00),
	(53, 12, 'Teh Tawar - Panas', 5000.00),
	(54, 12, 'Teh Tawar - Dingin', 5000.00),
	(55, 12, 'Air Mineral', 5000.00),
	(56, 12, 'Kopi Hitam', 15000.00),
	(57, 12, 'Kopi Latte - Panas', 20000.00),
	(58, 12, 'Kopi Latte - Dingin', 20000.00),
	(59, 12, 'Cappucino - Panas', 20000.00),
	(60, 12, 'Cappucino - Dingin', 20000.00),
	(61, 12, 'Coklat - Panas', 20000.00),
	(62, 12, 'Coklat - Dingin', 20000.00);

-- membuang struktur untuk table db_kasir_kambing77.tbl_pengguna
CREATE TABLE IF NOT EXISTS `tbl_pengguna` (
  `id_pengguna` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `nama_lengkap` varchar(150) DEFAULT NULL,
  `role` enum('admin','kasir') NOT NULL,
  PRIMARY KEY (`id_pengguna`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Membuang data untuk tabel db_kasir_kambing77.tbl_pengguna: ~3 rows (lebih kurang)
INSERT INTO `tbl_pengguna` (`id_pengguna`, `username`, `password_hash`, `nama_lengkap`, `role`) VALUES
	(1, 'admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Administrator Utama', 'admin'),
	(2, 'kasir', 'f02b7c1e519e4fa436147f7e1399974f9510aa9c8e0cb8be29151eb540f9d214', 'Kasir Shift 1', 'kasir'),
	(3, 'Raply', 'fc96624b712c3d2ad9936e02fdb408073e4149345ac59de5041ed265e9335272', 'Raply', 'admin');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
