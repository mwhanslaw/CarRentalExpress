<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReserveVehicle.aspx.cs" Inherits="CarRentalExpress.ReserveVehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="ReserveVehicle.css"/>
    <title>Car Rental Express</title>

</head>
<body>
    <form id="form1" runat="server">
    <div class =" container">
    
        <asp:Label ID="lblName" runat="server" Text="Customer Name"></asp:Label>
    
        <br />
    
        <br />
        <asp:LinkButton ID="lBtnReservations"  CssClass="myLinkButton" runat="server" OnClick="lBtnReservations_Click" ForeColor="#FFCC00">Check Reservations</asp:LinkButton>
    
        <br />
        <hr />
    
    </div>
        <p>
            <asp:Label ID="lblVehicleType" runat="server" Text="Vehicle Type:"></asp:Label>
            <asp:DropDownList ID="ddlVehicleType" runat="server" AutoPostBack="True" Height="18px" style="margin-top: 5px" Width="137px" AppendDataBoundItems="True">
             <asp:ListItem Text="All Types..."></asp:ListItem>
            </asp:DropDownList>
        </p>
        <asp:Label ID="lblSearch" runat="server" Text="Search for Vehicles:"></asp:Label>
        <asp:TextBox ID="tBoxSearchVehicles" runat="server" Width="128px"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
        <asp:GridView ID="GridViewVehicles" CssClass="mygrdContent" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" Height="222px" Width="796px" AutoGenerateColumns="False" OnRowCommand="GridViewVehicles_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Model" DataField="Model" />
                <asp:BoundField HeaderText="Description" DataField="Description" />
                <asp:BoundField HeaderText="Type" DataField="VehicleType" />
                <asp:BoundField HeaderText="License Plate" Visible="False" DataField="LicensePlate" />
                <asp:ButtonField ButtonType="Button" CommandName="Reserve" HeaderText="Reserve" ShowHeader="True" Text="Reserve" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:ButtonField>
            </Columns>
            <HeaderStyle />
            <PagerStyle />
            <RowStyle />
        </asp:GridView>
        <br />
        <asp:Label ID="lblNoResults" runat="server" ForeColor="#CC0000" Text="No Results Found"></asp:Label>
    </form>
    <hr />
</body>
</html>
