<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffLogin.aspx.cs" Inherits="protected_StaffPageLogin" %>

<!DOCTYPE html>

<html>
<body>
    <h1>Login to access Staff page
    </h1>
    <hr>
    <form runat="server">
        <table cellpadding="4">
            <tr>
                <td>User Name:  </td>
                <td>
                    <asp:TextBox ID="StaffUserName" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Password: </td>
                <td>
                    <asp:TextBox ID="StaffPassword" TextMode="password"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="Login" OnClick="LoginFunc" runat="server" />
            </tr>
        </table>
    </form>
    <hr>
    <h3>
        <asp:Label ID="Output" runat="server" />
    </h3>
</body>
</html>

