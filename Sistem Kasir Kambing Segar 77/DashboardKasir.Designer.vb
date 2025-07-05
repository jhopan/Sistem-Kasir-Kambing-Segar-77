<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashboardKasir
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
        cmbKategori = New ComboBox()
        dgvMenu = New DataGridView()
        dgvPesanan = New DataGridView()
        lblTotal = New Label()
        btnHapusItem = New Button()
        btnReset = New Button()
        btnBayar = New Button()
        btnLogout = New Button()
        grpPilihMenu = New GroupBox()
        lblKategori = New Label()
        grpDetailPesanan = New GroupBox()
        lblTotalHeader = New Label()
        CType(dgvMenu, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvPesanan, ComponentModel.ISupportInitialize).BeginInit()
        grpPilihMenu.SuspendLayout()
        grpDetailPesanan.SuspendLayout()
        SuspendLayout()
        ' 
        ' cmbKategori
        ' 
        cmbKategori.Font = New Font("Segoe UI", 10.8F)
        cmbKategori.FormattingEnabled = True
        cmbKategori.Location = New Point(431, 23)
        cmbKategori.Name = "cmbKategori"
        cmbKategori.Size = New Size(151, 33)
        cmbKategori.TabIndex = 0
        ' 
        ' dgvMenu
        ' 
        dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMenu.Dock = DockStyle.Left
        dgvMenu.Location = New Point(3, 23)
        dgvMenu.Name = "dgvMenu"
        dgvMenu.RowHeadersWidth = 51
        dgvMenu.Size = New Size(324, 707)
        dgvMenu.TabIndex = 1
        ' 
        ' dgvPesanan
        ' 
        dgvPesanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPesanan.Dock = DockStyle.Left
        dgvPesanan.Location = New Point(3, 23)
        dgvPesanan.Name = "dgvPesanan"
        dgvPesanan.RowHeadersWidth = 51
        dgvPesanan.Size = New Size(609, 707)
        dgvPesanan.TabIndex = 2
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI", 10.8F)
        lblTotal.Location = New Point(717, 52)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(49, 25)
        lblTotal.TabIndex = 3
        lblTotal.Text = "Rp 0"
        ' 
        ' btnHapusItem
        ' 
        btnHapusItem.Font = New Font("Segoe UI", 10.8F)
        btnHapusItem.Location = New Point(744, 197)
        btnHapusItem.Name = "btnHapusItem"
        btnHapusItem.Size = New Size(94, 40)
        btnHapusItem.TabIndex = 4
        btnHapusItem.Text = "Hapus Item"
        btnHapusItem.UseVisualStyleBackColor = True
        ' 
        ' btnReset
        ' 
        btnReset.Font = New Font("Segoe UI", 10.8F)
        btnReset.Location = New Point(628, 256)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(94, 40)
        btnReset.TabIndex = 5
        btnReset.Text = "Reset"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' btnBayar
        ' 
        btnBayar.Font = New Font("Segoe UI", 10.8F)
        btnBayar.Location = New Point(628, 197)
        btnBayar.Name = "btnBayar"
        btnBayar.Size = New Size(94, 40)
        btnBayar.TabIndex = 6
        btnBayar.Text = "Bayar"
        btnBayar.UseVisualStyleBackColor = True
        ' 
        ' btnLogout
        ' 
        btnLogout.Font = New Font("Segoe UI", 10.8F)
        btnLogout.Location = New Point(744, 256)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(94, 40)
        btnLogout.TabIndex = 7
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' grpPilihMenu
        ' 
        grpPilihMenu.Controls.Add(lblKategori)
        grpPilihMenu.Controls.Add(cmbKategori)
        grpPilihMenu.Controls.Add(dgvMenu)
        grpPilihMenu.Dock = DockStyle.Left
        grpPilihMenu.Location = New Point(0, 0)
        grpPilihMenu.Name = "grpPilihMenu"
        grpPilihMenu.Size = New Size(600, 733)
        grpPilihMenu.TabIndex = 8
        grpPilihMenu.TabStop = False
        grpPilihMenu.Text = "Pilih Menu"
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Font = New Font("Segoe UI", 10.8F)
        lblKategori.Location = New Point(338, 26)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(87, 25)
        lblKategori.TabIndex = 9
        lblKategori.Text = "Kategori :"
        ' 
        ' grpDetailPesanan
        ' 
        grpDetailPesanan.Controls.Add(lblTotalHeader)
        grpDetailPesanan.Controls.Add(dgvPesanan)
        grpDetailPesanan.Controls.Add(btnHapusItem)
        grpDetailPesanan.Controls.Add(btnBayar)
        grpDetailPesanan.Controls.Add(btnLogout)
        grpDetailPesanan.Controls.Add(lblTotal)
        grpDetailPesanan.Controls.Add(btnReset)
        grpDetailPesanan.Dock = DockStyle.Fill
        grpDetailPesanan.Location = New Point(600, 0)
        grpDetailPesanan.Name = "grpDetailPesanan"
        grpDetailPesanan.Size = New Size(862, 733)
        grpDetailPesanan.TabIndex = 10
        grpDetailPesanan.TabStop = False
        grpDetailPesanan.Text = "Detail Pesanan"
        ' 
        ' lblTotalHeader
        ' 
        lblTotalHeader.AutoSize = True
        lblTotalHeader.Font = New Font("Segoe UI", 10.8F)
        lblTotalHeader.Location = New Point(641, 52)
        lblTotalHeader.Name = "lblTotalHeader"
        lblTotalHeader.Size = New Size(70, 25)
        lblTotalHeader.TabIndex = 11
        lblTotalHeader.Text = "TOTAL :"
        ' 
        ' DashboardKasir
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1462, 733)
        Controls.Add(grpDetailPesanan)
        Controls.Add(grpPilihMenu)
        Name = "DashboardKasir"
        Text = "DashboardKasir"
        CType(dgvMenu, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvPesanan, ComponentModel.ISupportInitialize).EndInit()
        grpPilihMenu.ResumeLayout(False)
        grpPilihMenu.PerformLayout()
        grpDetailPesanan.ResumeLayout(False)
        grpDetailPesanan.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents cmbKategori As ComboBox
    Friend WithEvents dgvMenu As DataGridView
    Friend WithEvents dgvPesanan As DataGridView
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnHapusItem As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents btnBayar As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents grpPilihMenu As GroupBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents grpDetailPesanan As GroupBox
    Friend WithEvents lblTotalHeader As Label
End Class
