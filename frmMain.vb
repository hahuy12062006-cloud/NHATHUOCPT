Imports System.Data.SqlClient
Imports System.Data
Public Class frmMain
    Private Const ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=DangNhap0;Integrated Security=True"
    Private _userName As String
    'KHỞI TẠO BIẾN ĐỂ HIỆN TÊN USER LÊN MAIN
    Public Sub New(ByVal user As String)
        InitializeComponent()
        Me._userName = user
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TÊN USER =LABLE
        lblTenHienThi.Text = "Tên đăng nhập: " & Me._userName
    End Sub
    Private Sub btnBanHang_Click(sender As Object, e As EventArgs) Handles btnBanHang.Click
        Dim frmBanHang As New frmBanHang()
        frmBanHang.Show()
        MessageBox.Show("Chức năng quản lý bán hàng sẽ được mở ở đây.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub btnNhaCungCap_Click(sender As Object, e As EventArgs) Handles btnNhaCungCap.Click
        Dim frmNhaCungCap As New frmNhaCungCap()
        frmNhaCungCap.Show()
        MessageBox.Show("Chức năng quản lý nhà cung cấp sẽ được mở ở đây.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnNhapHang_Click(sender As Object, e As EventArgs) Handles btnNhapHang.Click
        Dim frmNhapHang As New frmNhapHang(_userName)
        frmNhapHang.Show()
        MessageBox.Show("Chức năng nhập hàng sẽ được mở ở đây.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnHoaDon_Click(sender As Object, e As EventArgs) Handles btnHoaDon.Click
        Dim frmHoaDon As New frmXemHoaDonBanHang()
        frmHoaDon.Show()
        MessageBox.Show("Chức năng xem hóa đơn sẽ được mở ở đây.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
