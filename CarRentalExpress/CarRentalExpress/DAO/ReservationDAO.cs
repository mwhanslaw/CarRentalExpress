//Kamal Mohamud
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;
namespace CarRentalExpress
{
    public class ReservationDAO
    {
        private string CustomerID{get;set;} 
        private string password {get;set;}
        public ReservationDAO(string CustomerID, string password)
        {
            this.CustomerID = CustomerID;
            this.password = password;
        }

        public List<Vehicle> GetReservations()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", CustomerID, password));
            OracleCommand cmd = new OracleCommand("SELECT vehicle.type,vehicle.model,vehicle.description, rental_car.license_plate FROM vehicle INNER JOIN rental_car ON vehicle.model = rental_car.vehicle_model WHERE customer_id = :custId ORDER BY vehicle.model", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue(":custId", CustomerID);
            
            List<Vehicle> vehicles = new List<Vehicle>();

            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string licenseplate = Convert.ToString(dr["license_plate"]);
                    string model = Convert.ToString(dr["model"]);
                    string description = Convert.ToString(dr["description"]);
                    string vehicletype = Convert.ToString(dr["type"]);
                    vehicles.Add(new Vehicle(licenseplate, model, description, vehicletype));
                }
                return vehicles;
            }

        }
        public bool ReserveVehicle(string model)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", CustomerID, password));
            OracleCommand cmd = new OracleCommand("RESERVE_VEHICLE", conn);
            cmd.Parameters.AddWithValue("pmodel", model);
            cmd.Parameters.Add("psuccess", OracleType.Number).Direction = ParameterDirection.Output;

             cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            try
            {
                bool success;
                cmd.ExecuteNonQuery();
                success = Convert.ToBoolean(cmd.Parameters["psuccess"].Value);
                return success;
            }
             finally
            {
                conn.Close();
            }
        
        }

    }
}