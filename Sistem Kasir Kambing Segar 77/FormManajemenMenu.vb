Imports MySql.Data.MySqlClient

Public Class FormManajemenMenu

    Private Sub FormManajemenMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Pengaturan awal untuk DataGridView
        dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMenu.MultiSelect = False
        dgvMenu.ReadOnly = True
        dgvMenu.AllowUserToAddRows = False

        ' Muat data yang diperlukan
        LoadKategoriKeComboBox()
        LoadMenu()
        ClearForm()
    End Sub

#Region "Prosedur Memuat Data & Membersihkan Form"

    ' Mengisi ComboBox dengan data dari tabel kategori
    Private Sub LoadKategoriKeComboBox()
        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return
        Try
            Dim query As String = "SELECT id_kategori, nama_kategori FROM tbl_kategori ORDER BY nama_kategori"
            Dim da As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            cmbKategori.DataSource = dt
            cmbKategori.DisplayMember = "nama_kategori"
            cmbKategori.ValueMember = "id_kategori"
        Catch ex As Exception
            MessageBox.Show("Error saat memuat data kategori: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Mengisi DataGridView dengan data dari tabel menu
    Private Sub LoadMenu()
        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return
        Try
            ' =================================================================
            ' === PENYESUAIAN ADA DI BARIS ORDER BY DI BAWAH INI ===
            ' =================================================================
            Dim query As String = "SELECT m.id_menu, m.nama_menu, m.harga, k.nama_kategori, m.id_kategori FROM tbl_menu m " &
                                  "JOIN tbl_kategori k ON m.id_kategori = k.id_kategori " &
                                  "ORDER BY k.nama_kategori, m.nama_menu" ' <-- DIUBAH DI SINI

            Dim da As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvMenu.DataSource = dt

            ' Atur tampilan kolom
            dgvMenu.Columns("id_menu").Visible = False
            dgvMenu.Columns("id_kategori").Visible = False
            dgvMenu.Columns("nama_menu").HeaderText = "Nama Menu"
            dgvMenu.Columns("harga").HeaderText = "Harga"
            dgvMenu.Columns("harga").DefaultCellStyle.Format = "N0"
            dgvMenu.Columns("nama_kategori").HeaderText = "Kategori"

        Catch ex As Exception
            MessageBox.Show("Error saat memuat data menu: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Mengatur form ke kondisi "Tambah Baru"
    Private Sub ClearForm()
        lblMenuId.Text = ""
        txtNamaMenu.Clear()
        numHarga.Value = 0
        cmbKategori.SelectedIndex = -1
        SetInputControls(True)
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        txtNamaMenu.Focus()
    End Sub

    ' Prosedur bantuan untuk mengunci/membuka kunci kontrol input
    Private Sub SetInputControls(enabled As Boolean)
        txtNamaMenu.ReadOnly = Not enabled
        numHarga.ReadOnly = Not enabled
        cmbKategori.Enabled = enabled
    End Sub

#End Region

#Region "Event Handler untuk Tombol dan Interaksi"

    Private Sub dgvMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvMenu.Rows(e.RowIndex)
            lblMenuId.Text = row.Cells("id_menu").Value.ToString()
            txtNamaMenu.Text = row.Cells("nama_menu").Value.ToString()
            numHarga.Value = Convert.ToDecimal(row.Cells("harga").Value)
            cmbKategori.SelectedValue = Convert.ToInt32(row.Cells("id_kategori").Value)

            SetInputControls(False)
            btnSimpan.Enabled = False
            btnEdit.Enabled = True
            btnHapus.Enabled = True
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        SetInputControls(True)
        btnSimpan.Enabled = True
        txtNamaMenu.Focus()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If String.IsNullOrWhiteSpace(txtNamaMenu.Text) OrElse numHarga.Value <= 0 OrElse cmbKategori.SelectedIndex = -1 Then
            MessageBox.Show("Nama Menu, Harga, dan Kategori wajib diisi.", "Data Tidak Lengkap", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return
        Try
            Dim query As String
            Dim cmd As New MySqlCommand()
            cmd.Connection = connection
            cmd.Parameters.AddWithValue("@nama", txtNamaMenu.Text)
            cmd.Parameters.AddWithValue("@harga", numHarga.Value)
            cmd.Parameters.AddWithValue("@id_kategori", cmbKategori.SelectedValue)

            If String.IsNullOrEmpty(lblMenuId.Text) Then ' MODE TAMBAH
                query = "INSERT INTO tbl_menu (nama_menu, harga, id_kategori) VALUES (@nama, @harga, @id_kategori)"
            Else ' MODE UBAH
                query = "UPDATE tbl_menu SET nama_menu=@nama, harga=@harga, id_kategori=@id_kategori WHERE id_menu=@id"
                cmd.Parameters.AddWithValue("@id", CInt(lblMenuId.Text))
            End If

            cmd.CommandText = query
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data menu berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Terjadi error saat menyimpan menu: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try

        LoadMenu()
        ClearForm()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If String.IsNullOrEmpty(lblMenuId.Text) Then Return
        If MessageBox.Show("Anda yakin ingin menghapus menu '" & txtNamaMenu.Text & "'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return
        Try
            Dim query As String = "DELETE FROM tbl_menu WHERE id_menu = @id"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@id", CInt(lblMenuId.Text))
            cmd.ExecuteNonQuery()
            MessageBox.Show("Menu berhasil dihapus.", "Sukses")
        Catch ex As Exception
            MessageBox.Show("Error saat menghapus menu: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try

        LoadMenu()
        ClearForm()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ClearForm()
    End Sub

#End Region

End Class