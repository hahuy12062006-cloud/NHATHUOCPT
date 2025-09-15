Imports System.Data.SqlClient
Public Class frmDangNhap
    Private Const ConString As String = "Data Source=DESKTOP-RK96TBH\SQLEXPRESS;Initial Catalog=DangNhap0;Integrated Security=True"
    Private hienthi As String
    Private Sub frmDangNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnDangNhap_Click(sender As Object, e As EventArgs) Handles btnDangNhap.Click
        Dim UserName As String = txtTenDangNhap.Text.Trim()
        Dim PassWord As String = txtMatKhau.Text.Trim()
        Dim UserName1 As String = txtTenDangNhap.Text()
        'kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
        If String.IsNullOrEmpty(UserName) OrElse String.IsNullOrEmpty(PassWord) Then
            MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'tạo kết nối và thực thi truy vấn
        Using con As New SqlConnection(ConString)
            Dim cmd As SqlCommand = Nothing
            Dim reader As SqlDataReader = Nothing

            Try
                con.Open()
                'câu truy vấn SQL để tìm người dùng khớp với tên đăng nhập và mật khẩu
                Dim query As String = "SELECT COUNT(1) FROM Accout WHERE UserName = @UserName AND PassWord = @PassWord"
                cmd = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UserName", UserName)
                cmd.Parameters.AddWithValue("@PassWord", PassWord)

                Dim count As Integer = CInt(cmd.ExecuteScalar())

                If count = 1 Then
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'dăng nhập thành công, ẩn form hiện tại và hiển thị form chính
                    ' Ẩn form đăng nhập

                    Dim mainForm As New frmMain(txtTenDangNhap.Text)
                    mainForm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Lỗi khi kết nối hoặc truy vấn cơ sở dữ liệu: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If reader IsNot Nothing Then reader.Close()
                If cmd IsNot Nothing Then cmd.Dispose()
                con.Close()
            End Try
        End Using
    End Sub

    Private Sub btnDangNhap_Click_1(sender As Object, e As EventArgs) Handles btnDangNhap.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnQuenMK.Click
        Dim UserName As String = txtTenDangNhap.Text.Trim()
        Dim newPassword As String = Microsoft.VisualBasic.Interaction.InputBox("Vui lòng nhập mật khẩu mới:", "Đổi Mật Khẩu", "")

        'kiểm tra xem người dùng đã nhập đủ thông tin chưa
        If String.IsNullOrEmpty(UserName) OrElse String.IsNullOrEmpty(newPassword) Then
            MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'thực hiện cập nhật mật khẩu trong cơ sở dữ liệu
        Using con As New SqlConnection(ConString)
            Dim cmd As SqlCommand = Nothing
            Try
                con.Open()
                'viết câu truy vấn SQL để cập nhật mật khẩu
                'trong ứng dụng thực tế, nên có thêm bước xác thực (ví dụ: gửi mã xác nhận qua email)
                Dim query As String = "UPDATE dbo.Accout SET PassWord = @newPassword WHERE UserName = @UserName"
                cmd = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UserName", UserName)
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
