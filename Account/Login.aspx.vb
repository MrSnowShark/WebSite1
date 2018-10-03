Imports MySql.Data.MySqlClient
Imports System.Web.UI.Page

Public Partial Class Account_Login
    Inherits Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RegisterHyperLink.NavigateUrl = "Register"
        OpenAuthLogin.ReturnUrl = Request.QueryString("ReturnUrl")
        Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        If Not [String].IsNullOrEmpty(returnUrl) Then
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" & returnUrl
        End If
    End Sub

    Protected Sub LogIn(sender As Object, e As EventArgs)
        Dim conn As New MySqlConnection
        conn.ConnectionString = "server=127.0.0.1;user id=root;password=Cooper96;persistsecurityinfo=True;database=csci"
        Try
            conn.Open()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            ' recover here
        End Try
        If conn.State = Data.ConnectionState.Open Then
            Dim cmd As New MySqlCommand("SELECT id FROM Student WHERE email = '" + Email.Text + "' AND password = '" + Password.Text + "';", conn)
            cmd.ExecuteNonQuery()
            Dim read As MySqlDataReader = cmd.ExecuteReader()
            While read.Read()
                If read.HasRows Then
                    Dim test = read.GetString(0)
                    Response.Redirect("Flights.aspx?id=" & HttpUtility.UrlEncode(read.GetString(0)))
                    conn.Close()
                Else
                    Response.Redirect("Login.aspx")
                End If
            End While
        End If
        conn.Close()
    End Sub
End Class
