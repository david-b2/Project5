<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Project5.Member" %>

<!DOCTYPE html>
<%@ Register TagPrefix = "ctrl" TagName="resultsBox" src="ResultsDisplayCtrl.ascx" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <br />
        <br />
&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Member Page" Width="445px" BackColor="#338BDB" Height="36px" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
        <br />
        <br />
        This page allows you to enter the name of a store to search for and specify a location and range from location to search within.<br />
        <br />
        Enter the store you wish to search:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbxStorename" runat="server"></asp:TextBox>
        <br />
        <p>
            Enter the zip code you wsh to search near:
            <asp:TextBox ID="tbxLocation" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Enter a range in miles to search within the specifield location<asp:TextBox ID="tbxRadius" runat="server"></asp:TextBox>
        </p>
        <p>
            must be between 0 and 30 miles</p>
        <p>
            <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="Find Store" />
        </p>
        <p>
            <asp:Label ID="lblResults" runat="server" ForeColor="#FF3300"></asp:Label>
        </p>
        <p>
            <asp:ListBox ID="lbxResults" runat="server" Height="218px" Visible="False" Width="908px"></asp:ListBox>

        </p>

    </form>
</body>
</html>
