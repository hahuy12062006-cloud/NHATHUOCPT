<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhapHang
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
        Me.dgvChiTietNhapHang = New System.Windows.Forms.DataGridView()
        Me.lblTongTien = New System.Windows.Forms.Label()
        Me.cboNhaCungCap = New System.Windows.Forms.ComboBox()
        Me.txtDonGiaNhap = New System.Windows.Forms.TextBox()
        Me.txtSoLuongNhap = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnTimKiem = New System.Windows.Forms.Button()
        Me.btnLuu = New System.Windows.Forms.Button()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnThoat = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnInHoaDon = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgvChiTietNhapHang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvChiTietNhapHang
        '
        Me.dgvChiTietNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChiTietNhapHang.Location = New System.Drawing.Point(15, 37)
        Me.dgvChiTietNhapHang.Name = "dgvChiTietNhapHang"
        Me.dgvChiTietNhapHang.RowTemplate.Height = 27
        Me.dgvChiTietNhapHang.Size = New System.Drawing.Size(634, 150)
        Me.dgvChiTietNhapHang.TabIndex = 0
        '
        'lblTongTien
        '
        Me.lblTongTien.AutoSize = True
        Me.lblTongTien.Location = New System.Drawing.Point(12, 190)
        Me.lblTongTien.Name = "lblTongTien"
        Me.lblTongTien.Size = New System.Drawing.Size(68, 15)
        Me.lblTongTien.TabIndex = 1
        Me.lblTongTien.Text = "Tổng tiền:"
        '
        'cboNhaCungCap
        '
        Me.cboNhaCungCap.FormattingEnabled = True
        Me.cboNhaCungCap.Location = New System.Drawing.Point(412, 241)
        Me.cboNhaCungCap.Name = "cboNhaCungCap"
        Me.cboNhaCungCap.Size = New System.Drawing.Size(121, 23)
        Me.cboNhaCungCap.TabIndex = 2
        '
        'txtDonGiaNhap
        '
        Me.txtDonGiaNhap.Location = New System.Drawing.Point(109, 218)
        Me.txtDonGiaNhap.Name = "txtDonGiaNhap"
        Me.txtDonGiaNhap.Size = New System.Drawing.Size(100, 25)
        Me.txtDonGiaNhap.TabIndex = 3
        '
        'txtSoLuongNhap
        '
        Me.txtSoLuongNhap.Location = New System.Drawing.Point(109, 249)
        Me.txtSoLuongNhap.Name = "txtSoLuongNhap"
        Me.txtSoLuongNhap.Size = New System.Drawing.Size(45, 25)
        Me.txtSoLuongNhap.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Số lượng nhập"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Đơn giá nhập"
        '
        'btnTimKiem
        '
        Me.btnTimKiem.Location = New System.Drawing.Point(663, 84)
        Me.btnTimKiem.Name = "btnTimKiem"
        Me.btnTimKiem.Size = New System.Drawing.Size(87, 29)
        Me.btnTimKiem.TabIndex = 7
        Me.btnTimKiem.Text = "Thêm"
        Me.btnTimKiem.UseVisualStyleBackColor = True
        '
        'btnLuu
        '
        Me.btnLuu.Location = New System.Drawing.Point(663, 128)
        Me.btnLuu.Name = "btnLuu"
        Me.btnLuu.Size = New System.Drawing.Size(87, 29)
        Me.btnLuu.TabIndex = 8
        Me.btnLuu.Text = "Lưu"
        Me.btnLuu.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(663, 172)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(87, 29)
        Me.btnXoa.TabIndex = 9
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(663, 37)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(87, 32)
        Me.btnReset.TabIndex = 10
        Me.btnReset.Text = "Làm mới"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnThoat
        '
        Me.btnThoat.Location = New System.Drawing.Point(-4, 285)
        Me.btnThoat.Name = "btnThoat"
        Me.btnThoat.Size = New System.Drawing.Size(55, 23)
        Me.btnThoat.TabIndex = 12
        Me.btnThoat.Text = "<="
        Me.btnThoat.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(282, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Tên nhà cung cấp"
        '
        'btnInHoaDon
        '
        Me.btnInHoaDon.Location = New System.Drawing.Point(663, 220)
        Me.btnInHoaDon.Name = "btnInHoaDon"
        Me.btnInHoaDon.Size = New System.Drawing.Size(87, 29)
        Me.btnInHoaDon.TabIndex = 14
        Me.btnInHoaDon.Text = "In hóa đơn"
        Me.btnInHoaDon.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Chi tiết nhập hàng"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(294, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 15)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Ngày nhập hàng"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(412, 204)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 25)
        Me.DateTimePicker1.TabIndex = 17
        '
        'frmNhapHang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(784, 301)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnInHoaDon)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnThoat)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnLuu)
        Me.Controls.Add(Me.btnTimKiem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSoLuongNhap)
        Me.Controls.Add(Me.txtDonGiaNhap)
        Me.Controls.Add(Me.cboNhaCungCap)
        Me.Controls.Add(Me.lblTongTien)
        Me.Controls.Add(Me.dgvChiTietNhapHang)
        Me.Name = "frmNhapHang"
        Me.Text = "frmNhapHang"
        CType(Me.dgvChiTietNhapHang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvChiTietNhapHang As DataGridView
    Friend WithEvents lblTongTien As Label
    Friend WithEvents cboNhaCungCap As ComboBox
    Friend WithEvents txtDonGiaNhap As TextBox
    Friend WithEvents txtSoLuongNhap As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnTimKiem As Button
    Friend WithEvents btnLuu As Button
    Friend WithEvents btnXoa As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents btnThoat As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnInHoaDon As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
