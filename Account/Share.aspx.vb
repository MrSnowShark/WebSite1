
Imports MySql.Data.MySqlClient

Partial Class Account_Share
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id As String = Request.QueryString("id")
        Dim email As String = TextBox1.Text
        Dim conn As New MySqlConnection
        conn.ConnectionString = "server=127.0.0.1;user id=root;password=Cooper96;persistsecurityinfo=True;database=csci"
        Try
            conn.Open()
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        If conn.State = Data.ConnectionState.Open Then
            Dim cmd As New MySqlCommand("SELECT id FROM Student WHERE email = '" + email + "';", conn)
            cmd.ExecuteNonQuery()
            Dim read As MySqlDataReader = cmd.ExecuteReader()
            Dim stud As String
            While read.Read()
                stud = read.GetString(0)
            End While
            read.Close()
            Dim cmd2 As New MySqlCommand("INSERT INTO has_access_to VALUES ('" + stud + "', '" + id + "');", conn)
            If conn.State = Data.ConnectionState.Open And stud.Any() Then
                cmd2.ExecuteNonQuery()
                MsgBox("successfully shared with " + email)
            End If
        End If
        conn.Close()
    End Sub
End Class
