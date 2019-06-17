<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle Rental Reservations.aspx.cs" Inherits="CarRentalExpress.DAO.Vehicle_Rental_Reservations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="VehicleRentalReservations.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class =" container">
    
        <asp:Label ID="lblCustName" runat="server" Text="Customer Name"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="lbtnReserveVehicle"  CssClass="myLinkButton" runat="server" OnClick="lbtnReserveVehicle_Click" ForeColor="#FFCC00">Reserve A Vehicle</asp:LinkButton>
        <hr />
        <br />
        <asp:Label ID="lblNoReservations" runat="server" Text="No Reservations Found." Visible="False"></asp:Label>
        <br />
        <asp:GridView ID="gvReservations"  CssClass="mygrdContent" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="False" Height="118px" OnRowCommand="gvReservations_RowCommand" Width="363px">
            <Columns>
                <asp:BoundField HeaderText="License Plate Number" Visible="False" DataField="LicensePlate" />
                <asp:BoundField HeaderText="Make" DataField="VehicleType" />
                <asp:BoundField HeaderText="Model" DataField="Model" />
                <asp:BoundField HeaderText="Description" DataField="Description" />
                <asp:ButtonField ButtonType="Button" CommandName="CancelReservation" HeaderText="Cancel" ShowHeader="True" Text="Cancel" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:ButtonField>
            </Columns>
            <HeaderStyle />
            <PagerStyle />
            <RowStyle />
        </asp:GridView>
        <hr />
        <br />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
        <br />
    
    </div>
    </form>
</body>
</html>
