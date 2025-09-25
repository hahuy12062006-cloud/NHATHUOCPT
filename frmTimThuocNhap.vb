Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmTimThuocNhap
    ' Delegate đã được sửa để bao gồm DonGia
    Public Delegate Sub SelectedDrugHandler(ByVal maThuoc As Integer, ByVal tenThuoc As String, ByVal donGia As Decimal)

    Public Event DrugSelected As SelectedDrugHandler

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub

    Private Sub frmTimThuocNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDanhSachThuoc()
    End Sub

    Private Sub LoadDanhSachThuoc()
        Dim ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True"
        Using con As New SqlConnection(ConString)
            Dim query As String = "SELECT MaThuoc, TenThuoc, NhaSanXuat, DonGia AS DonGiaBan FROM Thuoc"
            Using adapter As New SqlDataAdapter(query, con)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvTimKiemThuoc.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub dgvTimKiemThuoc_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvTimKiemThuoc.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvTimKiemThuoc.Rows(e.RowIndex)
            Dim maThuoc As Integer = CInt(selectedRow.Cells("MaThuoc").Value)
            Dim tenThuoc As String = selectedRow.Cells("TenThuoc").Value.ToString()
            Dim donGia As Decimal = CDec(selectedRow.Cells("DonGiaBan").Value)

            ' Phát ra sự kiện với đầy đủ 3 tham số
            RaiseEvent DrugSelected(maThuoc, tenThuoc, donGia)

            Me.Close()
        End If
    End Sub
End Class
