//Written by : Martyn Whanslaw
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

namespace CarRentalExpress
{
    public class CustomerDAO
    {
        public string CustomerId {get; set;}
        public string Password { get; set; }

        public CustomerDAO(string CustomerId, string Password) 
        {
            this.CustomerId = CustomerId;
            this.Password = Password;        
        }

        
        public Customer AuthenticateCustomer()
        {
            string firstName = string.Empty;
            string lastName = string.Empty;

            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", CustomerId, Password));
            OracleCommand cmd = new OracleCommand("SELECT first_name, last_name FROM customer WHERE customer_id = :custId", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue(":custId", CustomerId);           
            da.Fill(dt);

            if (dt.Rows.Count == 0)            
                return null;            
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    firstName = Convert.ToString(dr["first_name"]); 
                    lastName = Convert.ToString(dr["last_name"]);
                }
                return new Customer (CustomerId, Password, firstName, lastName);
                
            }
            
        }           
        


        //This method cancels the vehicle reservation in the database for the vehicle with the specified license plate.
        public void CancelVehicleReservation(string LicensePlate) 
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", CustomerId, Password));
            OracleCommand cmd = new OracleCommand("UPDATE rental_car SET customer_id = NULL WHERE license_plate = :License", conn);

            cmd.Parameters.AddWithValue(":License", LicensePlate);
            
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        
        }


    }
}