<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDangNhap
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
        Me.btnQuenMK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMatKhau = New System.Windows.Forms.TextBox()
        Me.txtTenDangNhap = New System.Windows.Forms.TextBox()
        Me.btnDangNhap = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnQuenMK
        '
        Me.btnQuenMK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuenMK.BackColor = System.Drawing.SystemColors.Control
        Me.btnQuenMK.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnQuenMK.FlatAppearance.BorderSize = 0
        Me.btnQuenMK.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnQuenMK.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnQuenMK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuenMK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnQuenMK.Location = New System.Drawing.Point(258, 217)
        Me.btnQuenMK.Name = "btnQuenMK"
        Me.btnQuenMK.Size = New System.Drawing.Size(128, 22)
        Me.btnQuenMK.TabIndex = 14
        Me.btnQuenMK.Text = "Quên mật khẩu?"
        Me.btnQuenMK.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gulim", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Mật khẩu"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gulim", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Tên đăng nhập"
        '
        'txtMatKhau
        '
        Me.txtMatKhau.Location = New System.Drawing.Point(91, 186)
        Me.txtMatKhau.Name = "txtMatKhau"
        Me.txtMatKhau.Size = New System.Drawing.Size(295, 25)
        Me.txtMatKhau.TabIndex = 10
        '
        'txtTenDangNhap
        '
        Me.txtTenDangNhap.Location = New System.Drawing.Point(91, 127)
        Me.txtTenDangNhap.Name = "txtTenDangNhap"
        Me.txtTenDangNhap.Size = New System.Drawing.Size(295, 25)
        Me.txtTenDangNhap.TabIndex = 9
        '
        'btnDangNhap
        '
        Me.btnDangNhap.Location = New System.Drawing.Point(155, 245)
        Me.btnDangNhap.Name = "btnDangNhap"
        Me.btnDangNhap.Size = New System.Drawing.Size(143, 43)
        Me.btnDangNhap.TabIndex = 8
        Me.btnDangNhap.Text = "Đăng nhập"
        Me.btnDangNhap.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Gulim", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(-4, -5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(456, 66)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "HỆ THỐNG ĐĂNG NHẬP"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmDangNhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 297)
        Me.Controls.Add(Me.btnQuenMK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMatKhau)
        Me.Controls.Add(Me.txtTenDangNhap)
        Me.Controls.Add(Me.btnDangNhap)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmDangNhap"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnQuenMK As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMatKhau As TextBox
    Friend WithEvents txtTenDangNhap As TextBox
    Friend WithEvents btnDangNhap As Button
    Friend WithEvents Label3 As Label
End Class
