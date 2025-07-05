<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormManajemenKategori
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
        dgvKategori = New DataGridView()
        grpDetail = New GroupBox()
        lblKategoriId = New Label()
        btnHapus = New Button()
        btnBatal = New Button()
        btnEdit = New Button()
        btnSimpan = New Button()
        lblKategori = New Label()
        txtNamaKategori = New TextBox()
        CType(dgvKategori, ComponentModel.ISupportInitialize).BeginInit()
        grpDetail.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvKategori
        ' 
        dgvKategori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvKategori.Dock = DockStyle.Left
        dgvKategori.Location = New Point(0, 0)
        dgvKategori.Name = "dgvKategori"
        dgvKategori.RowHeadersWidth = 51
        dgvKategori.Size = New Size(706, 733)
        dgvKategori.TabIndex = 0
        ' 
        ' grpDetail
        ' 
        grpDetail.Controls.Add(lblKategoriId)
        grpDetail.Controls.Add(btnHapus)
        grpDetail.Controls.Add(btnBatal)
        grpDetail.Controls.Add(btnEdit)
        grpDetail.Controls.Add(btnSimpan)
        grpDetail.Controls.Add(lblKategori)
        grpDetail.Controls.Add(txtNamaKategori)
        grpDetail.Dock = DockStyle.Fill
        grpDetail.Location = New Point(706, 0)
        grpDetail.Name = "grpDetail"
        grpDetail.Size = New Size(756, 733)
        grpDetail.TabIndex = 1
        grpDetail.TabStop = False
        ' 
        ' lblKategoriId
        ' 
        lblKategoriId.AutoSize = True
        lblKategoriId.Location = New Point(284, 265)
        lblKategoriId.Name = "lblKategoriId"
        lblKategoriId.Size = New Size(22, 20)
        lblKategoriId.TabIndex = 13
        lblKategoriId.Text = "id"
        lblKategoriId.Visible = False
        ' 
        ' btnHapus
        ' 
        btnHapus.Font = New Font("Segoe UI", 10.8F)
        btnHapus.Location = New Point(281, 122)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(94, 42)
        btnHapus.TabIndex = 12
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = True
        ' 
        ' btnBatal
        ' 
        btnBatal.Font = New Font("Segoe UI", 10.8F)
        btnBatal.Location = New Point(381, 122)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(94, 42)
        btnBatal.TabIndex = 11
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Font = New Font("Segoe UI", 10.8F)
        btnEdit.Location = New Point(166, 122)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(94, 42)
        btnEdit.TabIndex = 10
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnSimpan
        ' 
        btnSimpan.Font = New Font("Segoe UI", 10.8F)
        btnSimpan.Location = New Point(36, 122)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(94, 42)
        btnSimpan.TabIndex = 9
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = True
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Font = New Font("Segoe UI", 10.8F)
        lblKategori.Location = New Point(36, 35)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(78, 25)
        lblKategori.TabIndex = 1
        lblKategori.Text = "Kategori"
        ' 
        ' txtNamaKategori
        ' 
        txtNamaKategori.Font = New Font("Segoe UI", 10.8F)
        txtNamaKategori.Location = New Point(135, 32)
        txtNamaKategori.Name = "txtNamaKategori"
        txtNamaKategori.Size = New Size(340, 31)
        txtNamaKategori.TabIndex = 0
        ' 
        ' FormManajemenKategori
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1462, 733)
        Controls.Add(grpDetail)
        Controls.Add(dgvKategori)
        Name = "FormManajemenKategori"
        Text = "FormManajemenKategori"
        CType(dgvKategori, ComponentModel.ISupportInitialize).EndInit()
        grpDetail.ResumeLayout(False)
        grpDetail.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvKategori As DataGridView
    Friend WithEvents grpDetail As GroupBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents txtNamaKategori As TextBox
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents lblKategoriId As Label
End Class
