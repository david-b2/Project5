<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResultsDisplayCtrl.ascx.cs" Inherits="Project5.ResultsDisplayCtrl" %>
<asp:ListBox ID="ResultsBox" runat="server" Height="218px" Visible="False" Width="908px"></asp:ListBox>

<br />
<br />
<asp:Button ID="btnDelete" runat="server" Text="Delete Item" Width="96px" OnClick="btnDelete_Click" />