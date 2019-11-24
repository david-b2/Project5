<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>The Default Page</h1>
        <p class="lead">This is the default page.........</p>
        
    </div>

    <div class="row">
        <div class="col-md-3">
            <h2>Member Page </h2>
            <p>
               Some description......
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Member Page" Width="184px" />
            </p>
            
        </div>
         <div class="col-md-3">
            <h2>Member Page Login</h2>
            <p>
               Some description......
            </p>
            <p>
                <asp:Button ID="Button3" runat="server" Text="Member Page" Width="184px" />
            </p>
            
        </div>
        <div class="col-md-3">
            <h2>Staff Page</h2>
            <p>
                Some description..... 
            </p>
            <p>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Staff Page" Width="189px" />
            </p>
            
        </div>
            <div class="col-md-3">
            <h2>Staff Page Login</h2>
            <p>
                Some description..... 
            </p>
            <p>
                <asp:Button ID="Button4" runat="server" OnClick="Button3_Click" Text="Staff Page" Width="189px" />
            </p>
            
        </div>
        
    </div>
</asp:Content>
