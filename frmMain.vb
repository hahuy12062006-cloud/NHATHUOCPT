Imports System.Data.SqlClient
Imports System.Data
Public Class frmMain
    Private Const ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=DangNhap0;Integrated Security=True"
    Private UserName As String
    Public Sub New(ByVal user As String)
        ' This call is required by the designer.
        InitializeComponent()
        Me.UserName = user
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTenHienThi.Text = "Tên đăng nhập: " & Me.UserName
    End Sub
    Private Sub btnBanHang_Click(sender As Object, e As EventArgs) Handles btnBanHang.Click
        Dim frmBanHang As New frmBanHang()
        frmBanHang.Show()
    End Sub
    Private Sub btnNhaCungCap_Click(sender As Object, e As EventArgs) Handles btnNhaCungCap.Click
        ' Bạn cần tạo form frmNhaCungCap
        Dim frmNhaCungCap As New frmNhaCungCap()
        frmNhaCungCap.Show()
        MessageBox.Show("Chức năng quản lý nhà cung cấp sẽ được mở ở đây.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub btnNhapHang_Click(sender As Object, e As EventArgs) Handles btnNhapHang.Click
        ' Bạn cần tạo form frmNhapHang
        Dim frmNhapHang As New frmNhapHang()
        frmNhapHang.Show()
        MessageBox.Show("Chức năng nhập hàng sẽ được mở ở đây.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' Đảm bảo tên nút là btnHoaDon
    Private Sub btnHoaDon_Click(sender As Object, e As EventArgs) Handles btnHoaDon.Click
        ' Bạn cần tạo form frmHoaDon
        Dim frmHoaDon As New frmHoaDon()
        frmHoaDon.Show()
        MessageBox.Show("Chức năng xem hóa đơn sẽ được mở ở đây.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lblTenHienThi_Click(sender As Object, e As EventArgs) Handles lblTenHienThi.Click

    End Sub
End Class