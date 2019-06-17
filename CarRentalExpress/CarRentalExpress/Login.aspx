<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CarRentalExpress.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="login.css"/>
    <title> Car Rental Express </title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div class ="container">
    <table> 
       
       <tr>
        <td><asp:Label ID="customerIdLB" runat="server" Text="Customer ID:"></asp:Label></td>
        <td><asp:TextBox ID="customerIdTXT" runat="server"></asp:TextBox> </td>
        <td><asp:RequiredFieldValidator ID="customerIdRFV" runat="server" ControlToValidate="customerIdTXT" ErrorMessage="Customer ID Required" ForeColor="Red"></asp:RequiredFieldValidator></td>
       </tr>
        <tr>
        <td><asp:Label ID="passwordLB" runat="server" Text="Password:"></asp:Label></td>
        <td><asp:TextBox ID="passwordTXT" runat="server" TextMode="Password"></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="passwordRFV" runat="server" ControlToValidate="passwordTXT" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
        <td></td>
        <td><asp:Button ID="loginBT" runat="server" OnClick="loginBT_Click" Text="Login" Width="216px" /></td>
        <td><asp:Label ID="invalidLB" runat="server" Font-Bold="True" ForeColor="Red" Text="Invalid customer ID and/or password" Visible="False"></asp:Label></td>
        </tr>
        </table>
    <h1>Login to Reserve A Car</h1>
    </div>
        
    </form>
</body>
</html>
