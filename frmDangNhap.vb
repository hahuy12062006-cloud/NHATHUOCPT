Imports System.Data.SqlClient
Imports System.Data

Public Class frmDangNhap
    Private Const ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=DangNhap0;Integrated Security=True"

    Private Sub btnDangNhap_Click(sender As Object, e As EventArgs) Handles btnDangNhap.Click
        'NHẬP VÀ XÓA TRẮNG
        Dim userName As String = txtTenDangNhap.Text.Trim()
        Dim passWord As String = txtMatKhau.Text.Trim()
        'CHECK ĐÃ NHẬP ĐẦY ĐỦ TÊN VÀ MK 
        If String.IsNullOrEmpty(userName) OrElse String.IsNullOrEmpty(passWord) Then
            MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        'TẠO BIẾN KẾT NỐI SQL
        Using con As New SqlConnection(ConString)
            Dim cmd As SqlCommand = Nothing 'BIẾN ĐỂ THỰC HIỆN  CÁC LỆNH TRONG SQL
            Try
                con.Open()
                Dim query As String = "SELECT COUNT(1) FROM Accout WHERE UserName = @UserName AND PassWord = @PassWord" 'CHECK USER VÀ PASS 
                cmd = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UserName", userName)
                cmd.Parameters.AddWithValue("@PassWord", passWord)
                Dim count As Integer = CInt(cmd.ExecuteScalar())
                If count = 1 Then
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim mainForm As New frmMain(userName)
                    mainForm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Lỗi khi kết nối hoặc truy vấn cơ sở dữ liệu: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If cmd IsNot Nothing Then cmd.Dispose()
                con.Close()
            End Try
        End Using
    End Sub

    Private Sub btnQuenMK_Click(sender As Object, e As EventArgs) Handles btnQuenMK.Click
        Dim userName As String = txtTenDangNhap.Text.Trim()
        Dim newPassword As String = Microsoft.VisualBasic.Interaction.InputBox("Vui lòng nhập mật khẩu mới:", "Đổi Mật Khẩu", "")
        'CHECK NGƯỜI NHẬP ĐÃ NHẬP ĐỦ TT 
        If String.IsNullOrEmpty(userName) OrElse String.IsNullOrEmpty(newPassword) Then
            MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        'UPDATE PASS trong SQL
        Using con As New SqlConnection(ConString)
            Dim cmd As SqlCommand = Nothing
            Try
                con.Open()
                Dim query As String = "UPDATE Accout SET PassWord = @newPassword WHERE UserName = @UserName"
                cmd = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UserName", userName)
                cmd.Parameters.AddWithValue("@newPassword", newPassword)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Tên đăng nhập không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Lỗi khi kết nối hoặc truy vấn cơ sở dữ liệu: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If cmd IsNot Nothing Then cmd.Dispose()
                con.Close()
            End Try
        End Using
    End Sub

    Private Sub frmDangNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
