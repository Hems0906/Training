<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ElectricityBillingSystem.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login - Electricity Billing System</title>
    <link href="App_Themes/Default/Styles.css" rel="stylesheet" />
</head>
<body style="background-color:darkslateblue; background-size: cover; background-position: center; height:100vh;align-content:center">
<form id="form1" runat="server">
    <div class="container" style="max-width:420px;">
        <h2>Admin Login</h2>
        <span class="label">Username</span>
        <asp:TextBox ID="txtUser" runat="server" />
        <span class="label">Password</span>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
        <br /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <br /><br />
        <asp:Label ID="lblMsg" runat="server" />
    </div>
</form>
</body>
</html>
