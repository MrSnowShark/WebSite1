Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient



Public Partial Class Account_Register
    Inherits Page
    Protected Sub CreateUser_Click(sender As Object, e As EventArgs)
        Dim conn As New MySqlConnection
        conn.ConnectionString = "server=127.0.0.1;user id=root;password=Cooper96;persistsecurityinfo=True;database=csci"
        Try
            conn.Open()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            ' recover here
        Catch myerror As MySqlException
            MsgBox("Error!")
        End Try
        If conn.State = Data.ConnectionState.Open Then
            Dim cmd As New MySqlCommand("INSERT INTO Student VALUES (" + id.Text + ", '" + fname.Text + "', '" + lname.Text + "', '" + email.Text + "', '" + Password.Text + "', 'n');", conn)
            cmd.ExecuteNonQuery()
        Else
            MsgBox("Error!")
        End If
        conn.Close()
        Response.Redirect("Login.aspx")
    End Sub
End Class
