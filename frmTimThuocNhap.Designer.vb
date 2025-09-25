<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimThuocNhap
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
        Me.dgvTimKiemThuoc = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvTimKiemThuoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTimKiemThuoc
        '
        Me.dgvTimKiemThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimKiemThuoc.Location = New System.Drawing.Point(0, 12)
        Me.dgvTimKiemThuoc.Name = "dgvTimKiemThuoc"
        Me.dgvTimKiemThuoc.RowTemplate.Height = 27
        Me.dgvTimKiemThuoc.Size = New System.Drawing.Size(510, 242)
        Me.dgvTimKiemThuoc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Danh sách thuốc nhập"
        '
        'frmTimThuocNhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 253)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvTimKiemThuoc)
        Me.Name = "frmTimThuocNhap"
        Me.Text = "frmTimThuocNhap"
        CType(Me.dgvTimKiemThuoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvTimKiemThuoc As DataGridView
    Friend WithEvents Label1 As Label
End Class
