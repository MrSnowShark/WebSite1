<%@ Page Title="" Language="VB" MasterPageFile="~/Account/SubMaster.master" AutoEventWireup="false" CodeFile="Share.aspx.vb" Inherits="Account_Share" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Enter the student email you would like to share the flight with</h3>
    <asp:TextBox ID="TextBox1" runat="server" Width="221px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Share" />
</asp:Content>

