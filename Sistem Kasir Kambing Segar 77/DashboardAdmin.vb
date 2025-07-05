Public Class DashboardAdmin
    Private activeForm As Form = Nothing

    ' Prosedur inti untuk membuka sebuah form di dalam pnlKonten
    ' Ini akan membersihkan panel, lalu menanam form baru di dalamnya.
    Private Sub BukaFormDiPanel(childForm As Form)
        ' Jika sudah ada form yang aktif, tutup dulu
        If activeForm IsNot Nothing Then
            activeForm.Close()
        End If

        ' Simpan referensi form baru sebagai form yang aktif
        activeForm = childForm

        ' Pengaturan penting agar form bisa ditanam di dalam panel
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None ' Hilangkan border dan title bar
        childForm.Dock = DockStyle.Fill ' Buat form mengisi seluruh panel

        ' Tambahkan form ke dalam panel konten dan tampilkan
        pnlKonten.Controls.Add(childForm)
        pnlKonten.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    ' --- Event Handler untuk Tombol Navigasi ---
    Private Sub btnManajemenPengguna_Click(sender As Object, e As EventArgs) Handles btnManajemenPengguna.Click
        BukaFormDiPanel(New FormManajemenPengguna())
    End Sub

    Private Sub btnManajemenKategori_Click(sender As Object, e As EventArgs) Handles btnManajemenKategori.Click
        BukaFormDiPanel(New FormManajemenKategori())
    End Sub

    Private Sub btnManajemenMenu_Click(sender As Object, e As EventArgs) Handles btnManajemenMenu.Click
        BukaFormDiPanel(New FormManajemenMenu())
    End Sub

    Private Sub btnLaporanPenjualan_Click(sender As Object, e As EventArgs) Handles btnLaporanPenjualan.Click
        BukaFormDiPanel(New FormLaporan())
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Hide()
            Dim loginForm As New FormLogin()
            loginForm.Show()
        End If
    End Sub

    Private Sub DashboardAdmin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Pastikan aplikasi tertutup sepenuhnya jika form ini ditutup via tombol 'X'
        If Application.OpenForms.Count = 0 Then
            Application.Exit()
        End If
    End Sub
End Class