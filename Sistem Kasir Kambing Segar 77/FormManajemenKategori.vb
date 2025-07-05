Imports MySql.Data.MySqlClient

Public Class FormManajemenKategori

    Private Sub FormManajemenKategori_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Pengaturan tampilan awal untuk DataGridView
        dgvKategori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvKategori.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvKategori.MultiSelect = False
        dgvKategori.ReadOnly = True
        dgvKategori.AllowUserToAddRows = False

        LoadKategori()
        ClearForm()
    End Sub

    ' Memuat semua data kategori ke DataGridView
    Private Sub LoadKategori()
        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return
        Try
            Dim query As String = "SELECT id_kategori, nama_kategori FROM tbl_kategori ORDER BY nama_kategori"
            Dim da As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvKategori.DataSource = dt
            dgvKategori.Columns("id_kategori").HeaderText = "ID"
            dgvKategori.Columns("nama_kategori").HeaderText = "Nama Kategori"
            dgvKategori.Columns("id_kategori").Width = 50
        Catch ex As Exception
            MessageBox.Show("Error saat memuat data kategori: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Prosedur untuk mengatur form ke kondisi "Tambah Baru"
    Private Sub ClearForm()
        lblKategoriId.Text = ""
        txtNamaKategori.Clear()

        ' --- Atur Status Kontrol untuk Mode Tambah ---
        txtNamaKategori.ReadOnly = False ' Inputbox aktif
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False

        txtNamaKategori.Focus()
    End Sub

    ' Event saat sebuah baris di tabel diklik
    Private Sub dgvKategori_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKategori.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvKategori.Rows(e.RowIndex)

            ' Isi form dengan data dari baris yang dipilih
            lblKategoriId.Text = row.Cells("id_kategori").Value.ToString()
            txtNamaKategori.Text = row.Cells("nama_kategori").Value.ToString()

            ' --- Atur Status Kontrol untuk Mode Lihat (Terkunci) ---
            txtNamaKategori.ReadOnly = True ' Kunci inputbox
            btnSimpan.Enabled = False      ' Tombol simpan non-aktif
            btnEdit.Enabled = True         ' Tombol edit aktif
            btnHapus.Enabled = True        ' Tombol hapus aktif
        End If
    End Sub

    ' Tombol untuk "membuka kunci" form dan masuk ke mode Edit
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' --- Atur Status Kontrol untuk Mode Edit ---
        txtNamaKategori.ReadOnly = False ' Aktifkan kembali inputbox
        btnSimpan.Enabled = True         ' Aktifkan tombol Simpan
        txtNamaKategori.Focus()          ' Fokus ke inputbox
    End Sub

    ' Tombol untuk menyimpan data (bisa untuk Tambah atau Ubah)
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If String.IsNullOrWhiteSpace(txtNamaKategori.Text) Then
            MessageBox.Show("Nama Kategori tidak boleh kosong.", "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return

        Try
            Dim query As String
            Dim cmd As New MySqlCommand()
            cmd.Connection = connection
            cmd.Parameters.AddWithValue("@nama", txtNamaKategori.Text)

            If String.IsNullOrEmpty(lblKategoriId.Text) Then ' MODE TAMBAH
                query = "INSERT INTO tbl_kategori (nama_kategori) VALUES (@nama)"
            Else ' MODE UBAH
                query = "UPDATE tbl_kategori SET nama_kategori = @nama WHERE id_kategori = @id"
                cmd.Parameters.AddWithValue("@id", CInt(lblKategoriId.Text))
            End If

            cmd.CommandText = query
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data kategori berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Terjadi error saat menyimpan: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try

        LoadKategori()
        ClearForm()
    End Sub

    ' Tombol untuk menghapus data yang dipilih
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If String.IsNullOrEmpty(lblKategoriId.Text) Then Return
        If MessageBox.Show("Anda yakin ingin menghapus kategori '" & txtNamaKategori.Text & "'? Menghapus kategori dapat mempengaruhi data menu yang terkait.", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return

        Try
            Dim query As String = "DELETE FROM tbl_kategori WHERE id_kategori = @id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@id", CInt(lblKategoriId.Text))
            cmd.ExecuteNonQuery()
            MessageBox.Show("Kategori berhasil dihapus.", "Sukses")

        Catch ex As MySqlException
            If ex.Number = 1451 Then ' Foreign Key constraint fails
                MessageBox.Show("Kategori ini tidak bisa dihapus karena masih digunakan oleh beberapa item menu.", "Gagal Hapus", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error database: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saat menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try

        LoadKategori()
        ClearForm()
    End Sub

    ' Tombol untuk membatalkan aksi dan kembali ke mode Tambah Baru
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ClearForm()
    End Sub
End Class