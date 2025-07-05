Imports MySql.Data.MySqlClient

Public Class FormLaporan

    Private Sub FormLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- Setup Awal ---
        ' Isi ComboBox Bulan
        cmbBulan.Items.Clear()
        cmbBulan.Items.Add("Semua Bulan") ' Tambahkan pilihan untuk laporan tahunan
        For i As Integer = 1 To 12
            cmbBulan.Items.Add(New DateTime(2000, i, 1).ToString("MMMM"))
        Next

        ' --- LOGIKA BARU UNTUK MENGATUR TAHUN ---
        Dim tahunAwal As Integer = DateTime.Now.Year ' Default ke tahun ini jika tidak ada data
        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()

        If connection IsNot Nothing Then
            Try
                ' Query untuk mendapatkan tahun dari transaksi paling pertama
                Dim query As String = "SELECT MIN(YEAR(waktu_transaksi)) FROM tbl_laporan"
                Dim cmd As New MySqlCommand(query, connection)
                ' ExecuteScalar digunakan untuk mengambil satu nilai tunggal
                Dim result As Object = cmd.ExecuteScalar()

                ' Cek apakah hasilnya valid (bukan null)
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    tahunAwal = Convert.ToInt32(result)
                End If
            Catch ex As Exception
                ' Jika ada error, biarkan tahunAwal tetap tahun ini
                MessageBox.Show("Gagal mengambil data tahun awal: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End If

        ' Atur properti NumericUpDown
        numTahun.Minimum = tahunAwal ' Tahun minimum adalah tahun transaksi pertama
        numTahun.Maximum = DateTime.Now.Year ' Tahun maksimum adalah tahun sekarang
        numTahun.Value = DateTime.Now.Year ' Nilai default tetap tahun sekarang

        ' Atur default bulan ke "Semua Bulan"
        cmbBulan.SelectedIndex = 0

        ' Atur tampilan grid utama
        dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvLaporan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLaporan.ReadOnly = True
        dgvLaporan.AllowUserToAddRows = False
    End Sub

    ' Tombol utama untuk menampilkan laporan
    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        Dim connection As MySqlConnection = ModuleKoneksi.GetConnection()
        If connection Is Nothing Then Return

        Try
            Dim query As String
            Dim cmd As New MySqlCommand()
            cmd.Connection = connection

            ' Query sekarang mengambil semua data detail secara langsung, tidak ada GROUP BY
            query = "SELECT id_transaksi_grup, waktu_transaksi, nama_menu, harga_satuan, jumlah, subtotal FROM tbl_laporan "

            ' Tentukan filter WHERE berdasarkan pilihan
            If cmbBulan.SelectedIndex = 0 Then
                ' Filter hanya berdasarkan TAHUN
                query &= "WHERE YEAR(waktu_transaksi) = @tahun ORDER BY waktu_transaksi DESC"
                cmd.Parameters.AddWithValue("@tahun", numTahun.Value)
            Else
                ' Filter berdasarkan BULAN dan TAHUN
                query &= "WHERE MONTH(waktu_transaksi) = @bulan AND YEAR(waktu_transaksi) = @tahun ORDER BY waktu_transaksi DESC"
                cmd.Parameters.AddWithValue("@bulan", cmbBulan.SelectedIndex) ' Index 1 akan menjadi bulan Januari, dst.
                cmd.Parameters.AddWithValue("@tahun", numTahun.Value)
            End If

            cmd.CommandText = query
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            dgvLaporan.DataSource = dt

            ' --- Perhitungan Ringkasan ---
            If dt.Rows.Count > 0 Then
                ' Menghitung Total Pendapatan
                Dim totalPendapatan As Decimal = Convert.ToDecimal(dt.Compute("SUM(subtotal)", ""))
                lblTotalPendapatan.Text = "Rp " & totalPendapatan.ToString("N0")

                ' Menghitung Total Transaksi unik
                Dim distinctTransactions As Integer = dt.DefaultView.ToTable(True, "id_transaksi_grup").Rows.Count
                lblTotalTransaksi.Text = distinctTransactions.ToString()

            Else
                ' Jika tidak ada data, kosongkan ringkasan
                lblTotalPendapatan.Text = "Rp 0"
                lblTotalTransaksi.Text = "0"
            End If

            ' Format kolom
            FormatKolomLaporan()

        Catch ex As Exception
            MessageBox.Show("Error saat memuat laporan: " & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Prosedur bantuan untuk merapikan header & format kolom
    Private Sub FormatKolomLaporan()
        If dgvLaporan.Columns.Count > 0 Then
            dgvLaporan.Columns("id_transaksi_grup").HeaderText = "ID Transaksi"
            dgvLaporan.Columns("waktu_transaksi").HeaderText = "Waktu"
            dgvLaporan.Columns("nama_menu").HeaderText = "Nama Item"
            dgvLaporan.Columns("harga_satuan").HeaderText = "Harga Satuan"
            dgvLaporan.Columns("jumlah").HeaderText = "Jumlah"
            dgvLaporan.Columns("subtotal").HeaderText = "Subtotal"

            ' Format angka dan tanggal
            dgvLaporan.Columns("waktu_transaksi").DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss"
            dgvLaporan.Columns("harga_satuan").DefaultCellStyle.Format = "N0"
            dgvLaporan.Columns("subtotal").DefaultCellStyle.Format = "N0"
        End If
    End Sub
End Class