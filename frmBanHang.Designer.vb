<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBanHang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvChiTietHoaDon = New System.Windows.Forms.DataGridView()
        Me.lblTongTien = New System.Windows.Forms.Label()
        Me.txtTimKiemThuoc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnIN = New System.Windows.Forms.Button()
        Me.txtSoLuong = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnTimKiem = New System.Windows.Forms.Button()
        Me.btnHoanThanh = New System.Windows.Forms.Button()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTenKhachHang = New System.Windows.Forms.TextBox()
        Me.cboMaKhachHang = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.dgvChiTietHoaDon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvChiTietHoaDon
        '
        Me.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChiTietHoaDon.Location = New System.Drawing.Point(3, 84)
        Me.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon"
        Me.dgvChiTietHoaDon.RowTemplate.Height = 27
        Me.dgvChiTietHoaDon.Size = New System.Drawing.Size(643, 220)
        Me.dgvChiTietHoaDon.TabIndex = 0
        '
        'lblTongTien
        '
        Me.lblTongTien.AutoSize = True
        Me.lblTongTien.Location = New System.Drawing.Point(0, 307)
        Me.lblTongTien.Name = "lblTongTien"
        Me.lblTongTien.Size = New System.Drawing.Size(78, 15)
        Me.lblTongTien.TabIndex = 1
        Me.lblTongTien.Text = "Thành tiền:"
        '
        'txtTimKiemThuoc
        '
        Me.txtTimKiemThuoc.Location = New System.Drawing.Point(455, 323)
        Me.txtTimKiemThuoc.Name = "txtTimKiemThuoc"
        Me.txtTimKiemThuoc.Size = New System.Drawing.Size(150, 25)
        Me.txtTimKiemThuoc.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(356, 333)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Mã bán hàng"
        '
        'btnIN
        '
        Me.btnIN.Location = New System.Drawing.Point(3, 353)
        Me.btnIN.Name = "btnIN"
        Me.btnIN.Size = New System.Drawing.Size(75, 23)
        Me.btnIN.TabIndex = 4
        Me.btnIN.Text = "In"
        Me.btnIN.UseVisualStyleBackColor = True
        '
        'txtSoLuong
        '
        Me.txtSoLuong.Location = New System.Drawing.Point(396, 34)
        Me.txtSoLuong.Name = "txtSoLuong"
        Me.txtSoLuong.Size = New System.Drawing.Size(187, 25)
        Me.txtSoLuong.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(356, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "SL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Mã khách hàng"
        '
        'btnTimKiem
        '
        Me.btnTimKiem.Location = New System.Drawing.Point(494, 353)
        Me.btnTimKiem.Name = "btnTimKiem"
        Me.btnTimKiem.Size = New System.Drawing.Size(75, 23)
        Me.btnTimKiem.TabIndex = 9
        Me.btnTimKiem.Text = "Tìm kiếm"
        Me.btnTimKiem.UseVisualStyleBackColor = True
        '
        'btnHoanThanh
        '
        Me.btnHoanThanh.Location = New System.Drawing.Point(84, 345)
        Me.btnHoanThanh.Name = "btnHoanThanh"
        Me.btnHoanThanh.Size = New System.Drawing.Size(112, 30)
        Me.btnHoanThanh.TabIndex = 10
        Me.btnHoanThanh.Text = "Hoàn thành"
        Me.btnHoanThanh.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(289, 346)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(82, 29)
        Me.btnXoa.TabIndex = 11
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(202, 345)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 30)
        Me.btnReset.TabIndex = 12
        Me.btnReset.Text = "Làm mới"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(396, -1)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(187, 25)
        Me.DateTimePicker1.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(286, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Ngày giao dịch"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Chi tiết hóa đơn"
        '
        'txtTenKhachHang
        '
        Me.txtTenKhachHang.Location = New System.Drawing.Point(123, 6)
        Me.txtTenKhachHang.Name = "txtTenKhachHang"
        Me.txtTenKhachHang.Size = New System.Drawing.Size(116, 25)
        Me.txtTenKhachHang.TabIndex = 7
        '
        'cboMaKhachHang
        '
        Me.cboMaKhachHang.FormattingEnabled = True
        Me.cboMaKhachHang.Location = New System.Drawing.Point(123, 37)
        Me.cboMaKhachHang.Name = "cboMaKhachHang"
        Me.cboMaKhachHang.Size = New System.Drawing.Size(121, 23)
        Me.cboMaKhachHang.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 15)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Tên khách hàng"
        '
        'frmBanHang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(651, 374)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboMaKhachHang)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnHoanThanh)
        Me.Controls.Add(Me.btnTimKiem)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTenKhachHang)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSoLuong)
        Me.Controls.Add(Me.btnIN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTimKiemThuoc)
        Me.Controls.Add(Me.lblTongTien)
        Me.Controls.Add(Me.dgvChiTietHoaDon)
        Me.Name = "frmBanHang"
        Me.Text = "frmBanHang"
        CType(Me.dgvChiTietHoaDon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvChiTietHoaDon As DataGridView
    Friend WithEvents lblTongTien As Label
    Friend WithEvents txtTimKiemThuoc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnIN As Button
    Friend WithEvents txtSoLuong As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnTimKiem As Button
    Friend WithEvents btnHoanThanh As Button
    Friend WithEvents btnXoa As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTenKhachHang As TextBox
    Friend WithEvents cboMaKhachHang As ComboBox
    Friend WithEvents Label6 As Label
End Class
