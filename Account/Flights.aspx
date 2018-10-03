<%@ Page Title="" Language="VB" MasterPageFile="~/Account/SubMaster.master" AutoEventWireup="false" CodeFile="Flights.aspx.vb" Inherits="Account_Flights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" CssClass="table table-striped table-bordered table-condensed">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:ButtonField Text="Share" ControlStyle-CssClass="btn btn-default" CommandName="Share"/>
            <asp:ButtonField Text="View" ControlStyle-CssClass="btn btn-default" CommandName="View"/>
            <asp:ButtonField Text="Delete" ControlStyle-CssClass="btn btn-default" CommandName="Deletel1"/>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <div class="form-horizontal">
        <label><asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-default"/></label>
        <label><asp:Button ID="Button1" runat="server" Text="Upload" CssClass="btn btn-default"/></label>
    </div>

</asp:Content>

