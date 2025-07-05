Imports MySql.Data.MySqlClient
Module ModuleKoneksi

    ' String koneksi didefinisikan secara terpusat di sini.
    ' Jika ada perubahan (misal: password atau nama database), cukup ubah di sini.
    Private ReadOnly connectionString As String = "Server=localhost;Database=db_kasir_kambing77;Uid=root;Pwd=;"

    ' Fungsi ini akan dipanggil oleh form-form lain untuk mendapatkan koneksi ke database.
    ' Fungsi ini mengembalikan object MySqlConnection yang sudah terbuka.
    Public Function GetConnection() As MySqlConnection
        Try
            Dim conn As New MySqlConnection(connectionString)
            conn.Open()
            Return conn
        Catch ex As MySqlException
            MessageBox.Show("Tidak dapat terhubung ke server database." & vbCrLf &
                            "Pastikan server MySQL/MariaDB sudah berjalan dan konfigurasi koneksi sudah benar." & vbCrLf &
                            "Error: " & ex.Message,
                            "Koneksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan tak terduga saat koneksi." & vbCrLf &
                            "Error: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

End Module