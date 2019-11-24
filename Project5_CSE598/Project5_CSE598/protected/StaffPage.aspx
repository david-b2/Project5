<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffPage.aspx.cs" Inherits="protected_StaffPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> <title>staff page</title> </head>
<body>
    <form id="form1" runat="server">
        <h1>Staff Page </h1>
        <div style="height: 715px">  
            <asp:Label ID="GreetingLabel" runat="server"></asp:Label>
            <br />
        In this Page existing Staff members can add new staff members as needed one at a time, simply provide their details in the input boxes below. Only authenticated users can access this page .<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Member Name:"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server" style="margin-left: 27px" Width="202px"></asp:TextBox>
            <br />
            User Name:
            <asp:TextBox ID="TextBoxUserName" runat="server" style="margin-left: 52px" Width="205px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxPwd" runat="server" Width="205px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Add User" Width="219px" OnClick="Button1_Click" />
            &nbsp;<asp:Button ID="ButtonSignOut" runat="server" OnClick="ButtonSignOut_Click" style="margin-left: 164px" Text="Sign Out" Width="241px" />
            <br />
            <br />
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>    
    </form>
</body>
</html>

