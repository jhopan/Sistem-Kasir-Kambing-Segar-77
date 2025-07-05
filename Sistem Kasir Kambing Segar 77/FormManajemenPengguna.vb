Imports MySql.Data.MySqlClient

Public Class FormManajemenPengguna

    Private Sub FormManajemenPengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Pengaturan awal untuk DataGridView
        dgvPengguna.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPengguna.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPengguna.MultiSelect = False
        dgvPengguna.ReadOnly = True
        dgvPengguna.AllowUserToAddRows = False

        ' Muat data dan atur form ke kondisi awal (mode Tambah Baru)
        LoadPengguna()
        ClearForm()
    End Sub

    ' Memuat semua data pengguna ke DataGridView
    Private Sub LoadPengguna()
        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return
        Try
            Dim query As String = "SELECT id_pengguna, username, nama_lengkap, role FROM tbl_pengguna ORDER BY username"
            Dim da As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvPengguna.DataSource = dt
            If dgvPengguna.Columns.Contains("id_pengguna") Then
                dgvPengguna.Columns("id_pengguna").Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error saat memuat data pengguna: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Prosedur untuk mengatur form ke kondisi "Tambah Baru"
    Private Sub ClearForm()
        lblUserId.Text = ""
        txtUsername.Clear()
        txtNamaLengkap.Clear()
        txtPassword.Clear()
        cmbRole.SelectedIndex = -1

        ' --- Atur Status Kontrol untuk Mode Tambah ---
        SetInputControls(True) ' Aktifkan semua input
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False

        txtUsername.Focus()
    End Sub

    ' Prosedur bantuan untuk mengaktifkan/menonaktifkan semua kontrol input
    Private Sub SetInputControls(enabled As Boolean)
        txtUsername.ReadOnly = Not enabled
        txtNamaLengkap.ReadOnly = Not enabled
        txtPassword.ReadOnly = Not enabled
        cmbRole.Enabled = enabled
    End Sub


    ' Event saat sebuah baris di tabel diklik
    Private Sub dgvPengguna_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPengguna.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvPengguna.Rows(e.RowIndex)

            ' Isi form dengan data dari baris yang dipilih
            lblUserId.Text = row.Cells("id_pengguna").Value.ToString()
            txtUsername.Text = row.Cells("username").Value.ToString()
            txtNamaLengkap.Text = row.Cells("nama_lengkap").Value.ToString()
            cmbRole.SelectedItem = row.Cells("role").Value.ToString()
            txtPassword.Clear() ' Selalu kosongkan password saat memilih

            ' --- Atur Status Kontrol untuk Mode Lihat (Terkunci) ---
            SetInputControls(False) ' Non-aktifkan semua input
            btnSimpan.Enabled = False ' Tombol simpan non-aktif
            btnEdit.Enabled = True  ' Tombol edit aktif
            btnHapus.Enabled = True ' Tombol hapus aktif
        End If
    End Sub

    ' Tombol untuk "membuka kunci" form dan masuk ke mode Edit
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' --- Atur Status Kontrol untuk Mode Edit ---
        SetInputControls(True) ' Aktifkan kembali semua input
        btnSimpan.Enabled = True ' Aktifkan tombol Simpan
        txtUsername.Focus()
    End Sub

    ' Tombol untuk menyimpan data (bisa untuk Tambah atau Ubah)
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtNamaLengkap.Text) OrElse cmbRole.SelectedIndex = -1 Then
            MessageBox.Show("Username, Nama Lengkap, dan Role wajib diisi.", "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return

        Try
            Dim query As String
            Dim cmd As New MySqlCommand()
            cmd.Connection = connection

            If String.IsNullOrEmpty(lblUserId.Text) Then ' === MODE TAMBAH ===
                If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                    MessageBox.Show("Password wajib diisi untuk pengguna baru.", "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                query = "INSERT INTO tbl_pengguna (username, password_hash, nama_lengkap, role) VALUES (@user, @hash, @nama, @role)"
                cmd.Parameters.AddWithValue("@hash", ModuleHashing.HashPassword(txtPassword.Text))
            Else ' === MODE UBAH ===
                If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                    ' Jika password diisi, maka UPDATE passwordnya
                    query = "UPDATE tbl_pengguna SET username=@user, password_hash=@hash, nama_lengkap=@nama, role=@role WHERE id_pengguna=@id"
                    cmd.Parameters.AddWithValue("@hash", ModuleHashing.HashPassword(txtPassword.Text))
                Else
                    ' Jika password dikosongkan, JANGAN UPDATE passwordnya
                    query = "UPDATE tbl_pengguna SET username=@user, nama_lengkap=@nama, role=@role WHERE id_pengguna=@id"
                End If
                cmd.Parameters.AddWithValue("@id", CInt(lblUserId.Text))
            End If

            cmd.Parameters.AddWithValue("@user", txtUsername.Text)
            cmd.Parameters.AddWithValue("@nama", txtNamaLengkap.Text)
            cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString())
            cmd.CommandText = query
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data pengguna berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("Username '" & txtUsername.Text & "' sudah ada.", "Error Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Terjadi error database: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi error umum: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try

        LoadPengguna()
        ClearForm()
    End Sub

    ' Tombol untuk menghapus data yang dipilih
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If String.IsNullOrEmpty(lblUserId.Text) Then Return
        If MessageBox.Show("Anda yakin ingin menghapus pengguna '" & txtUsername.Text & "'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return

        Try
            Dim query As String = "DELETE FROM tbl_pengguna WHERE id_pengguna = @id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@id", CInt(lblUserId.Text))
            cmd.ExecuteNonQuery()
            MessageBox.Show("Pengguna berhasil dihapus.", "Sukses")
        Catch ex As Exception
            MessageBox.Show("Error saat menghapus data: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try

        LoadPengguna()
        ClearForm()
    End Sub

    ' Tombol untuk membatalkan aksi dan kembali ke mode Tambah Baru
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ClearForm()
    End Sub
End Class