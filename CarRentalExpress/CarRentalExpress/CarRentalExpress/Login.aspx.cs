// Sofia Dalessandro
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Drawing;

namespace CarRentalExpress
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginBT.BackColor = Color.Gold;
        }

        protected void loginBT_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    string customerId = customerIdTXT.Text;
                    customerId = customerId.ToUpper();
                    OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1};", customerId, passwordTXT.Text));
                    conn.Open(); // Try to connect using given username/password - if can't connect, an exception is thrown
                    conn.Close();
                    CustomerDAO customerdao = new CustomerDAO(customerId, passwordTXT.Text);
                    Customer validCustomer = customerdao.AuthenticateCustomer();
                    Session.Add("login", validCustomer); // Save login information into session
                    Response.Redirect("~/Vehicle Rental Reservations.aspx");
                }
                catch (Exception)
                {
                    invalidLB.Visible = true;
                }
            }
        }
    }
}