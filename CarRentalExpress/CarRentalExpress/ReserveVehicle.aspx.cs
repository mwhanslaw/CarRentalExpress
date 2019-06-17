//Kamal Mohamud
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarRentalExpress
{
    public partial class ReserveVehicle : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer login = (Customer)Session["login"];
                lblName.Text = "Customer : " + login.LastName + ", " + login.FirstName;
                VehicleDAO vehicleDAO = new VehicleDAO(login.CustomerId,login.Password);
                ddlVehicleType.DataSource = vehicleDAO.GetVehicleTypes();
                ddlVehicleType.DataBind();
                lblNoResults.Visible = false;

            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Customer login = (Customer)Session["login"];
            if (String.IsNullOrEmpty(tBoxSearchVehicles.Text))
            {
              
                    
                    VehicleDAO vehicledao = new VehicleDAO(login.CustomerId, login.Password);
                    List<Vehicle> vehicles = vehicledao.FindVehicles(String.Empty, ddlVehicleType.Text);
                    if (vehicles.Count > 0)
                    {
                        GridViewVehicles.DataSource = vehicles;
                        GridViewVehicles.DataBind();
                        lblNoResults.Visible = false;
                    }
                    else
                        lblNoResults.Visible = true;
                    
            }
            else
            {
                    VehicleDAO vehicledao = new VehicleDAO(login.CustomerId, login.Password);
                    List<Vehicle> vehicles = vehicledao.FindVehicles(tBoxSearchVehicles.Text, ddlVehicleType.Text);
                    if (vehicles.Count > 0)
                    {
                        GridViewVehicles.DataSource = vehicles;
                        GridViewVehicles.DataBind();
                        lblNoResults.Visible = false;
                    }
                    else
                        lblNoResults.Visible = true;

                    GridViewVehicles.DataSource = vehicles;
                    GridViewVehicles.DataBind();
                
            }
        }

        protected void GridViewVehicles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Customer login = (Customer)Session["login"];
            if (e.CommandName == "Reserve")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row =  GridViewVehicles.Rows[index];
                ReservationDAO reservationdao = new ReservationDAO(login.CustomerId, login.Password);
                bool success = reservationdao.ReserveVehicle(row.Cells[0].Text);

                if (success == true)
                {
                    Response.Redirect("~/Vehicle Rental Reservations.aspx");
                }
                else
                {
                    lblNoResults.Visible = true;
                }
            }

        }

        protected void lBtnReservations_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vehicle Rental Reservations.aspx");
        }
    }
}