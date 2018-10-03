Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.DataSet
Imports System.Diagnostics
Partial Class Account_Flights
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub

    Private Sub GridView1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim id As String = Request.QueryString("id")
        Dim conn As New MySqlConnection
        conn.ConnectionString = "server=127.0.0.1;user id=root;password=Cooper96;persistsecurityinfo=True;database=csci"
        Try
            conn.Open()
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Try
            If conn.State = Data.ConnectionState.Open Then
                Dim cmd As New MySqlDataAdapter("SELECT * FROM flight WHERE id IN (SELECT flight_id FROM has_access_to WHERE student_id = " + id + ");", conn)
                Dim dt As DataTable = New DataTable()
                cmd.Fill(dt)
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.UseAccessibleHeader = True
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader


            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("File Uploaded!")
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If (e.CommandName = "View") Then
            Dim rindex As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView1.Rows(rindex)
            Dim id As String = Server.HtmlDecode(row.Cells(3).Text)
            Response.Redirect("View.aspx?id=" & HttpUtility.UrlEncode(id))
        End If
        If (e.CommandName = "Share") Then
            Dim rindex As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView1.Rows(rindex)
            Dim id As String = Server.HtmlDecode(row.Cells(3).Text)
            Response.Redirect("Share.aspx?id=" & HttpUtility.UrlEncode(id))
        End If
        If (e.CommandName = "Delete") Then
            Dim rindex As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView1.Rows(rindex)
            Dim id As String = Server.HtmlDecode(row.Cells(3).Text)
            'Dim cmd As New MySqlDataAdapter("DELETE From has_access_to Where flight_id = " + id + ";", conn)
        End If
    End Sub

End Class
