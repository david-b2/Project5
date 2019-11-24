<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageVerifier.ascx.cs" Inherits="Project5.ImageVerifier" %>


<asp:Image ID="Image1" runat="server" Height="62px" Width="183px" />
    <br />
<br />
    <asp:Label ID="Label1" runat="server" Text="For Verification, Enter String Shown Above:"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox2" runat="server" Height="21px"></asp:TextBox>
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
