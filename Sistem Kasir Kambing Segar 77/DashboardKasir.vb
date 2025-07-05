Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class DashboardKasir
    ' DataTable untuk menyimpan data pesanan di memori aplikasi (keranjang belanja virtual)
    Private dtPesanan As New DataTable()

    ' Dijalankan sekali saat form pertama kali dimuat
    Private Sub DashboardKasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Siapkan kolom-kolom untuk tabel pesanan (dgvPesanan)
        SetupKolomPesanan()
        ' Atur tampilan visual untuk kedua DataGridView
        SetupTampilanDataGridView()
        ' Muat daftar kategori dari database ke ComboBox
        LoadKategori()

        ' Atur teks awal untuk total
        lblTotal.Text = "Rp 0"
    End Sub

#Region "Prosedur Pengaturan Awal (Setup)"

    ' Prosedur ini membuat struktur tabel virtual untuk menampung pesanan
    Private Sub SetupKolomPesanan()
        dtPesanan.Columns.Add("id_menu", GetType(Integer))
        dtPesanan.Columns.Add("Nama Menu", GetType(String))
        dtPesanan.Columns.Add("Harga", GetType(Decimal))
        dtPesanan.Columns.Add("Jumlah", GetType(Integer))
        ' Kolom Subtotal dibuat dengan ekspresi, akan menghitung otomatis (Harga * Jumlah)
        dtPesanan.Columns.Add("Subtotal", GetType(Decimal), "Harga * Jumlah")

        ' Hubungkan DataTable ini dengan DataGridView pesanan
        dgvPesanan.DataSource = dtPesanan
    End Sub

    ' Prosedur ini mengatur properti visual dari kedua tabel
    Private Sub SetupTampilanDataGridView()
        dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMenu.MultiSelect = False
        dgvMenu.ReadOnly = True
        dgvMenu.AllowUserToAddRows = False

        dgvPesanan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPesanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPesanan.MultiSelect = False
        dgvPesanan.ReadOnly = False
        For Each col As DataGridViewColumn In dgvPesanan.Columns
            If col.Name <> "Jumlah" Then
                col.ReadOnly = True
            End If
        Next
        dgvPesanan.AllowUserToAddRows = False

        AddHandler dgvPesanan.DataBindingComplete, AddressOf SembunyikanKolomId
        AddHandler dgvMenu.DataBindingComplete, AddressOf SembunyikanKolomId
    End Sub

    ' Prosedur ini dipanggil setiap kali data di-bind ke grid untuk menyembunyikan kolom ID
    Private Sub SembunyikanKolomId(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If dgv.Columns.Contains("id_menu") Then
            dgv.Columns("id_menu").Visible = False
        End If
    End Sub
#End Region

#Region "Interaksi dengan Database"

    ' Mengambil data kategori dari database dan menampilkannya di ComboBox
    Private Sub LoadKategori()
        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return

        Try
            Dim query As String = "SELECT id_kategori, nama_kategori FROM tbl_kategori ORDER BY nama_kategori"
            Dim da As New MySqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            da.Fill(dt)

            Dim row As DataRow = dt.NewRow()
            row("id_kategori") = 0
            row("nama_kategori") = "-- Pilih Kategori --"
            dt.Rows.InsertAt(row, 0)

            cmbKategori.DataSource = dt
            cmbKategori.DisplayMember = "nama_kategori"
            cmbKategori.ValueMember = "id_kategori"
        Catch ex As Exception
            MessageBox.Show("Error saat memuat kategori: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Dijalankan setiap kali pilihan di ComboBox Kategori berubah
    Private Sub cmbKategori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKategori.SelectedIndexChanged
        If cmbKategori.SelectedIndex <= 0 Then
            dgvMenu.DataSource = Nothing
            Return
        End If

        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return

        Try
            Dim idKategori As Integer = CInt(cmbKategori.SelectedValue)
            Dim query As String = "SELECT id_menu, nama_menu, harga FROM tbl_menu WHERE id_kategori = @idKategori ORDER BY nama_menu"
            Dim da As New MySqlDataAdapter(query, connection)
            da.SelectCommand.Parameters.AddWithValue("@idKategori", idKategori)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvMenu.DataSource = dt
            dgvMenu.Columns("harga").DefaultCellStyle.Format = "N0"
        Catch ex As Exception
            MessageBox.Show("Error saat memuat menu: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub
#End Region

#Region "Logika Inti Kasir"

    ' Event ini dijalankan ketika pengguna melakukan double-click pada sebuah menu
    Private Sub dgvMenu_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvMenu.Rows(e.RowIndex)
            Dim idMenu As Integer = CInt(selectedRow.Cells("id_menu").Value)
            Dim namaMenu As String = selectedRow.Cells("nama_menu").Value.ToString()
            Dim harga As Decimal = CDec(selectedRow.Cells("harga").Value)

            Dim existingRows() As DataRow = dtPesanan.Select($"id_menu = {idMenu}")
            If existingRows.Length > 0 Then
                existingRows(0)("Jumlah") = CInt(existingRows(0)("Jumlah")) + 1
            Else
                dtPesanan.Rows.Add(idMenu, namaMenu, harga, 1)
            End If
            HitungTotal()
        End If
    End Sub

    ' Event ini dijalankan setiap kali ada perubahan di sel tabel pesanan (misal: mengubah jumlah)
    Private Sub dgvPesanan_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPesanan.CellValueChanged
        HitungTotal()
    End Sub

    ' Prosedur untuk menghitung total harga dari semua pesanan dan menampilkannya di label
    Private Sub HitungTotal()
        Dim total As Decimal = 0
        If dtPesanan.Rows.Count > 0 Then
            total = CDec(dtPesanan.Compute("SUM(Subtotal)", String.Empty))
        End If
        lblTotal.Text = "Rp " & total.ToString("N0")
    End Sub
#End Region

#Region "Logika Tombol (Buttons)"

    Private Sub btnHapusItem_Click(sender As Object, e As EventArgs) Handles btnHapusItem.Click
        If dgvPesanan.SelectedRows.Count > 0 Then
            Dim selectedIndex As Integer = dgvPesanan.SelectedRows(0).Index
            dtPesanan.Rows.RemoveAt(selectedIndex)
            HitungTotal()
        Else
            MessageBox.Show("Pilih item pada tabel pesanan yang ingin dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        If dtPesanan.Rows.Count > 0 Then
            Dim result = MessageBox.Show("Anda yakin ingin mengosongkan semua pesanan?", "Konfirmasi Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                dtPesanan.Clear()
                HitungTotal()
            End If
        End If
    End Sub

    ' ======================================================================================
    ' === INI BAGIAN YANG DIPERBARUI SESUAI DATABASE tbl_laporan ===
    ' ======================================================================================
    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        If dtPesanan.Rows.Count = 0 Then
            MessageBox.Show("Pesanan masih kosong.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim totalHarga As Decimal = CDec(dtPesanan.Compute("SUM(Subtotal)", String.Empty))
        Dim result = MessageBox.Show($"Total belanja adalah: Rp {totalHarga:N0}{vbCrLf}{vbCrLf}Lanjutkan ke pembayaran?", "Konfirmasi Pembayaran", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return
        End If

        ' 1. Buat ID unik untuk mengelompokkan semua item dalam transaksi ini.
        Dim idGrupTransaksi As String = DateTime.Now.ToString("yyyyMMddHHmmss") & "-" & New Random().Next(100, 999)
        Dim waktuSekarang As DateTime = DateTime.Now

        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return

        Dim transaction As MySqlTransaction = connection.BeginTransaction()

        Try
            ' 2. Looping untuk setiap item di keranjang belanja (dtPesanan)
            For Each row As DataRow In dtPesanan.Rows
                ' Siapkan query INSERT untuk setiap item ke dalam tbl_laporan
                Dim query As String = "INSERT INTO tbl_laporan (id_transaksi_grup, waktu_transaksi, nama_menu, harga_satuan, jumlah, subtotal) " &
                                      "VALUES (@id_grup, @waktu, @nama_menu, @harga, @jumlah, @subtotal)"

                Dim cmd As New MySqlCommand(query, connection, transaction)
                cmd.Parameters.AddWithValue("@id_grup", idGrupTransaksi)
                cmd.Parameters.AddWithValue("@waktu", waktuSekarang)
                cmd.Parameters.AddWithValue("@nama_menu", row("Nama Menu").ToString())
                cmd.Parameters.AddWithValue("@harga", Convert.ToDecimal(row("Harga")))
                cmd.Parameters.AddWithValue("@jumlah", Convert.ToInt32(row("Jumlah")))
                cmd.Parameters.AddWithValue("@subtotal", Convert.ToDecimal(row("Subtotal")))

                cmd.ExecuteNonQuery()
            Next

            ' 3. Jika semua loop berhasil, commit transaksi
            transaction.Commit()
            MessageBox.Show("Pembayaran berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Kosongkan pesanan untuk transaksi berikutnya
            dtPesanan.Clear()
            HitungTotal()

        Catch ex As Exception
            transaction.Rollback()
            MessageBox.Show("Terjadi kesalahan saat menyimpan transaksi: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Hide()
            Dim loginForm As New FormLogin()
            loginForm.Show()
        End If
    End Sub
#End Region

    ' Mengatur apa yang terjadi ketika form ditutup (misal: klik tombol 'X' di pojok kanan atas)
    Private Sub DashboardKasir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Application.OpenForms.Count = 0 Then
            Application.Exit()
        End If
    End Sub
End Class