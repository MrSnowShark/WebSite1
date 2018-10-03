Imports System.Data
Imports MySql.Data.MySqlClient

Partial Class Account_View
    Inherits System.Web.UI.Page
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
                Dim cmd As New MySqlDataAdapter("SELECT * FROM flight_position_information WHERE id = " + id + ";", conn)
                Dim dt As DataTable = New DataTable()
                cmd.Fill(dt)
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.UseAccessibleHeader = True
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader

                Dim cmd2 As New MySqlDataAdapter("SELECT flight_exceedence_information.id, flight_exceedence_information.exceedence_type, flight_exceedence_information.start_time, flight_exceedence_information.end_time, exceedence_type.definition FROM flight_exceedence_information left join exceedence_type on flight_exceedence_information.exceedence_type = exceedence_type.name WHERE id = " + id + ";", conn)
                Dim dt2 As DataTable = New DataTable()
                cmd2.Fill(dt2)
                GridView2.DataSource = dt2
                GridView2.DataBind()
                GridView2.UseAccessibleHeader = True
                GridView2.HeaderRow.TableSection = TableRowSection.TableHeader


            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub
End Class
