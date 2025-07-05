# Sistem Kasir Kambing Segar 77

Sistem Kasir Kambing Segar 77 adalah aplikasi kasir sederhana yang mendukung pengelolaan transaksi penjualan kambing. Proyek ini dibuat untuk membantu UMKM dalam mengatur penjualan, stok, dan laporan secara mudah.

## Fitur Utama
- Input, edit, dan hapus data produk (kambing)
- Transaksi penjualan
- Laporan penjualan
- Manajemen stok
- Pengelolaan pengguna

---

## Cara Clone Repository ke Visual Studio 2022

1. **Salin URL Repository**
   ```
   https://github.com/jhopan/Sistem-Kasir-Kambing-Segar-77.git
   ```

2. **Buka Visual Studio 2022**

3. **Pilih Menu "Git" → "Clone Repository..."**

4. **Paste URL Repository**
   - Masukkan URL di atas ke kolom repository location.
   - Pilih folder tujuan di komputer Anda.
   - Klik `Clone`.

5. **Tunggu hingga proses clone selesai.**

---

## Setup Database Lokal Menggunakan HeidiSQL (Disarankan) atau Tool SQL Lainnya

### 1. Instalasi HeidiSQL
- Download dan install [HeidiSQL](https://www.heidisql.com/download.php) (atau gunakan tool lain seperti phpMyAdmin, DBeaver, atau MySQL Workbench sesuai kebutuhan).

### 2. Import Database

1. **Buka HeidiSQL dan koneksikan ke MySQL Server lokal Anda.**
2. **Buat Database Baru**
   - Klik kanan pada server → “Create new” → “Database”
   - Nama database: `kasir_kambing` (atau sesuai file .sql yang disediakan dalam repo)
3. **Import File SQL**
   - Klik kanan pada database yang baru dibuat → “Load SQL file”
   - Pilih file database (biasanya bernama `kasir_kambing.sql` atau serupa, cari di folder repo ini).
   - Jalankan/eksekusi file SQL tersebut hingga selesai.

### 3. Konfigurasi Koneksi Database di Aplikasi

- Buka file konfigurasi koneksi database (misal: `config.php`, `koneksi.php`, atau sesuai nama pada proyek).
- Pastikan pengaturan sesuai dengan database lokal Anda:
  ```php
  $host = "localhost";
  $user = "root";
  $pass = ""; // atau password MySQL Anda
  $db   = "kasir_kambing";
  ```
- Simpan perubahan.

### 4. Jalankan Aplikasi

- Build dan jalankan aplikasi via Visual Studio 2022.
- Login dan mulai gunakan aplikasi kasir.

---

## Catatan

- Pastikan MySQL/MariaDB sudah berjalan di komputer Anda.
- Anda bisa menggunakan tools lain seperti phpMyAdmin, DBeaver, atau MySQL Workbench untuk mengelola database jika tidak menggunakan HeidiSQL.
- File database `.sql` biasanya tersedia di folder `database` atau root repository. Jika tidak tersedia, silakan hubungi pengelola repo.

---
