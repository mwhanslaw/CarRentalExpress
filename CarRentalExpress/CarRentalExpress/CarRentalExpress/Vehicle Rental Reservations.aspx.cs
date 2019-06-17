//Written by : Martyn Whanslaw
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarRentalExpress.DAO
{
    public partial class Vehicle_Rental_Reservations : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {               
                Customer CustLoginID = (Customer)Session["login"];

                if (null != CustLoginID)
                    lblCustName.Text = "Customer : " + CustLoginID.LastName + ", " + CustLoginID.FirstName;
                else
                    lblCustName.Text = "Customer Information not found.";  
                
                //get list of reservations

                ReservationDAO ReservationDAO = new ReservationDAO(CustLoginID.CustomerId, CustLoginID.Password);
                
                gvReservations.DataSource = ReservationDAO.GetReservations();
                gvReservations.Columns[0].Visible = true;
                gvReservations.DataBind();
                gvReservations.Columns[0].Visible = false;
                

                if (gvReservations.Rows.Count == 0)
                {
                    lblNoReservations.Visible = true;
                    gvReservations.Visible = false;

                }
                else
                {
                    lblNoReservations.Visible = false;
                    gvReservations.Visible = true;
                }
              }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        protected void gvReservations_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "CancelReservation") 
            {
                Customer CustLoginID = (Customer)Session["login"];
                CustomerDAO CustomerDAO = new CustomerDAO(CustLoginID.CustomerId, CustLoginID.Password);

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvReservations.Rows[index];
                CustomerDAO.CancelVehicleReservation(row.Cells[0].Text);  
                
                //re populate grid view here
                ReservationDAO ReservationDAO = new ReservationDAO(CustLoginID.CustomerId, CustLoginID.Password);
                
                gvReservations.DataSource = ReservationDAO.GetReservations();
                gvReservations.Columns[0].Visible = true;
                gvReservations.DataBind();
                gvReservations.Columns[0].Visible = false;
            }

            if (gvReservations.Rows.Count == 0)
            {
                lblNoReservations.Visible = true;
                gvReservations.Visible = false;

            }
            else
            {
                lblNoReservations.Visible = false;
                gvReservations.Visible = true;
            }

        }

        protected void lbtnReserveVehicle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReserveVehicle.aspx");
        }

    }
}