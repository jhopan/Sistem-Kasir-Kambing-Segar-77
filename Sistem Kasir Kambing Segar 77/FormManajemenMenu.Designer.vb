<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormManajemenMenu
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
        dgvMenu = New DataGridView()
        grpDetail = New GroupBox()
        cmbKategori = New ComboBox()
        numHarga = New NumericUpDown()
        txtNamaMenu = New TextBox()
        btnHapus = New Button()
        btnBatal = New Button()
        btnEdit = New Button()
        btnSimpan = New Button()
        lblMenuId = New Label()
        lblKategori = New Label()
        lblHarga = New Label()
        lblNamaMenu = New Label()
        CType(dgvMenu, ComponentModel.ISupportInitialize).BeginInit()
        grpDetail.SuspendLayout()
        CType(numHarga, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvMenu
        ' 
        dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMenu.Dock = DockStyle.Left
        dgvMenu.Location = New Point(0, 0)
        dgvMenu.Name = "dgvMenu"
        dgvMenu.RowHeadersWidth = 51
        dgvMenu.Size = New Size(706, 733)
        dgvMenu.TabIndex = 0
        ' 
        ' grpDetail
        ' 
        grpDetail.Controls.Add(cmbKategori)
        grpDetail.Controls.Add(numHarga)
        grpDetail.Controls.Add(txtNamaMenu)
        grpDetail.Controls.Add(btnHapus)
        grpDetail.Controls.Add(btnBatal)
        grpDetail.Controls.Add(btnEdit)
        grpDetail.Controls.Add(btnSimpan)
        grpDetail.Controls.Add(lblMenuId)
        grpDetail.Controls.Add(lblKategori)
        grpDetail.Controls.Add(lblHarga)
        grpDetail.Controls.Add(lblNamaMenu)
        grpDetail.Dock = DockStyle.Fill
        grpDetail.Location = New Point(706, 0)
        grpDetail.Name = "grpDetail"
        grpDetail.Size = New Size(756, 733)
        grpDetail.TabIndex = 1
        grpDetail.TabStop = False
        ' 
        ' cmbKategori
        ' 
        cmbKategori.Font = New Font("Segoe UI", 10.8F)
        cmbKategori.FormattingEnabled = True
        cmbKategori.Location = New Point(169, 132)
        cmbKategori.Name = "cmbKategori"
        cmbKategori.Size = New Size(343, 33)
        cmbKategori.TabIndex = 15
        ' 
        ' numHarga
        ' 
        numHarga.BorderStyle = BorderStyle.FixedSingle
        numHarga.Font = New Font("Segoe UI", 10.8F)
        numHarga.Location = New Point(169, 87)
        numHarga.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        numHarga.Name = "numHarga"
        numHarga.Size = New Size(343, 31)
        numHarga.TabIndex = 14
        ' 
        ' txtNamaMenu
        ' 
        txtNamaMenu.Font = New Font("Segoe UI", 10.8F)
        txtNamaMenu.Location = New Point(169, 38)
        txtNamaMenu.Name = "txtNamaMenu"
        txtNamaMenu.Size = New Size(343, 31)
        txtNamaMenu.TabIndex = 13
        ' 
        ' btnHapus
        ' 
        btnHapus.Font = New Font("Segoe UI", 10.8F)
        btnHapus.Location = New Point(302, 217)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(94, 43)
        btnHapus.TabIndex = 12
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = True
        ' 
        ' btnBatal
        ' 
        btnBatal.Font = New Font("Segoe UI", 10.8F)
        btnBatal.Location = New Point(431, 217)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(94, 43)
        btnBatal.TabIndex = 11
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Font = New Font("Segoe UI", 10.8F)
        btnEdit.Location = New Point(169, 217)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(94, 43)
        btnEdit.TabIndex = 10
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnSimpan
        ' 
        btnSimpan.Font = New Font("Segoe UI", 10.8F)
        btnSimpan.Location = New Point(33, 217)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(94, 43)
        btnSimpan.TabIndex = 9
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = True
        ' 
        ' lblMenuId
        ' 
        lblMenuId.AutoSize = True
        lblMenuId.Font = New Font("Segoe UI", 10.8F)
        lblMenuId.Location = New Point(44, 465)
        lblMenuId.Name = "lblMenuId"
        lblMenuId.Size = New Size(28, 25)
        lblMenuId.TabIndex = 3
        lblMenuId.Text = "Id"
        lblMenuId.Visible = False
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Font = New Font("Segoe UI", 10.8F)
        lblKategori.Location = New Point(23, 140)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(78, 25)
        lblKategori.TabIndex = 2
        lblKategori.Text = "Kategori"
        ' 
        ' lblHarga
        ' 
        lblHarga.AutoSize = True
        lblHarga.Font = New Font("Segoe UI", 10.8F)
        lblHarga.Location = New Point(23, 89)
        lblHarga.Name = "lblHarga"
        lblHarga.Size = New Size(60, 25)
        lblHarga.TabIndex = 1
        lblHarga.Text = "Harga"
        ' 
        ' lblNamaMenu
        ' 
        lblNamaMenu.AutoSize = True
        lblNamaMenu.Font = New Font("Segoe UI", 10.8F)
        lblNamaMenu.Location = New Point(23, 44)
        lblNamaMenu.Name = "lblNamaMenu"
        lblNamaMenu.Size = New Size(109, 25)
        lblNamaMenu.TabIndex = 0
        lblNamaMenu.Text = "Nama Menu"
        ' 
        ' FormManajemenMenu
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1462, 733)
        Controls.Add(grpDetail)
        Controls.Add(dgvMenu)
        Name = "FormManajemenMenu"
        Text = "FormManajemenMenu"
        CType(dgvMenu, ComponentModel.ISupportInitialize).EndInit()
        grpDetail.ResumeLayout(False)
        grpDetail.PerformLayout()
        CType(numHarga, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvMenu As DataGridView
    Friend WithEvents grpDetail As GroupBox
    Friend WithEvents lblMenuId As Label
    Friend WithEvents lblKategori As Label
    Friend WithEvents lblHarga As Label
    Friend WithEvents lblNamaMenu As Label
    Friend WithEvents cmbKategori As ComboBox
    Friend WithEvents numHarga As NumericUpDown
    Friend WithEvents txtNamaMenu As TextBox
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSimpan As Button
End Class
