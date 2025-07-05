Imports MySql.Data.MySqlClient

Public Class FormLogin

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Username dan Password tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return

        Try
            ' 1. Ambil data pengguna berdasarkan USERNAME saja
            Dim query As String = "SELECT password_hash, role FROM tbl_pengguna WHERE username = @user"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@user", txtUsername.Text)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                reader.Read() ' Pindah ke baris data pertama
                Dim storedHash As String = reader.GetString("password_hash")
                Dim userRole As String = reader.GetString("role")

                ' 2. Verifikasi password menggunakan ModuleHashing
                If ModuleHashing.VerifyPassword(txtPassword.Text, storedHash) Then
                    ' 3. Jika password cocok, arahkan ke dashboard yang sesuai
                    MessageBox.Show("Login Berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide() ' Sembunyikan form login

                    Select Case userRole
                        Case "admin"
                            Dim formAdmin As New DashboardAdmin()
                            formAdmin.Show()
                        Case "kasir"
                            Dim formKasir As New DashboardKasir()
                            formKasir.Show()
                        Case Else
                            MessageBox.Show("Peran pengguna tidak dikenali.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Show() ' Tampilkan lagi form login jika ada error
                    End Select
                Else
                    ' Password tidak cocok
                    MessageBox.Show("Username atau Password salah.", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' Username tidak ditemukan
                MessageBox.Show("Username atau Password salah.", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi error saat proses login: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Application.Exit()
    End Sub

End Class