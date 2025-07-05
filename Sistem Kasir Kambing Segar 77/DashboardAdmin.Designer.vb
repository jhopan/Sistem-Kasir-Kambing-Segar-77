<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashboardAdmin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnManajemenPengguna = New Button()
        btnManajemenMenu = New Button()
        btnLaporanPenjualan = New Button()
        btnLogout = New Button()
        pnlNavigasi = New Panel()
        btnManajemenKategori = New Button()
        pnlKonten = New Panel()
        pnlNavigasi.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnManajemenPengguna
        ' 
        btnManajemenPengguna.Location = New Point(0, 30)
        btnManajemenPengguna.Name = "btnManajemenPengguna"
        btnManajemenPengguna.Size = New Size(207, 63)
        btnManajemenPengguna.TabIndex = 1
        btnManajemenPengguna.Text = "Manajemen" & vbCrLf & "Pengguna"
        btnManajemenPengguna.UseVisualStyleBackColor = True
        ' 
        ' btnManajemenMenu
        ' 
        btnManajemenMenu.Location = New Point(3, 168)
        btnManajemenMenu.Name = "btnManajemenMenu"
        btnManajemenMenu.Size = New Size(204, 63)
        btnManajemenMenu.TabIndex = 2
        btnManajemenMenu.Text = "Manajemen" & vbCrLf & "Menu"
        btnManajemenMenu.UseVisualStyleBackColor = True
        ' 
        ' btnLaporanPenjualan
        ' 
        btnLaporanPenjualan.Location = New Point(0, 237)
        btnLaporanPenjualan.Name = "btnLaporanPenjualan"
        btnLaporanPenjualan.Size = New Size(207, 59)
        btnLaporanPenjualan.TabIndex = 3
        btnLaporanPenjualan.Text = "Laporan" & vbCrLf & "Penjualan"
        btnLaporanPenjualan.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(3, 302)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(201, 63)
        btnLogout.TabIndex = 4
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' pnlNavigasi
        ' 
        pnlNavigasi.BackColor = Color.Linen
        pnlNavigasi.Controls.Add(btnManajemenKategori)
        pnlNavigasi.Controls.Add(btnManajemenPengguna)
        pnlNavigasi.Controls.Add(btnLaporanPenjualan)
        pnlNavigasi.Controls.Add(btnLogout)
        pnlNavigasi.Controls.Add(btnManajemenMenu)
        pnlNavigasi.Dock = DockStyle.Left
        pnlNavigasi.Location = New Point(0, 0)
        pnlNavigasi.Name = "pnlNavigasi"
        pnlNavigasi.Size = New Size(207, 733)
        pnlNavigasi.TabIndex = 5
        ' 
        ' btnManajemenKategori
        ' 
        btnManajemenKategori.Location = New Point(0, 99)
        btnManajemenKategori.Name = "btnManajemenKategori"
        btnManajemenKategori.Size = New Size(207, 63)
        btnManajemenKategori.TabIndex = 5
        btnManajemenKategori.Text = "Manajemen" & vbCrLf & "Kategori"
        btnManajemenKategori.UseVisualStyleBackColor = True
        ' 
        ' pnlKonten
        ' 
        pnlKonten.Dock = DockStyle.Fill
        pnlKonten.Location = New Point(207, 0)
        pnlKonten.Name = "pnlKonten"
        pnlKonten.Size = New Size(1255, 733)
        pnlKonten.TabIndex = 6
        ' 
        ' DashboardAdmin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1462, 733)
        Controls.Add(pnlKonten)
        Controls.Add(pnlNavigasi)
        Name = "DashboardAdmin"
        Text = "DashboardAdmin"
        pnlNavigasi.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnManajemenPengguna As Button
    Friend WithEvents btnManajemenMenu As Button
    Friend WithEvents btnLaporanPenjualan As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents pnlKonten As Panel
    Friend WithEvents btnManajemenKategori As Button
End Class
