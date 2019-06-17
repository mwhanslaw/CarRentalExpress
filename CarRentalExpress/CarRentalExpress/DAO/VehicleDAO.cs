// Sofia Dalessandro
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

namespace CarRentalExpress
{
    public class VehicleDAO
    {
        public string CustomerID { get; set; }
        public string Password { get; set; }

        public VehicleDAO(string CustomerID, string Password)
        {
            this.CustomerID = CustomerID;
            this.Password = Password;
        }

        public List<Vehicle> FindVehicles(string Model, string VehicleType)
        {
            /*
                This method returns a List<Vehicle> representing the available (not reserved) 
                rental cars in the database that match the specifiedsearch criteria.
            */

            //  If the Model parameter is null or empty string, all available rental cars are returned in the list.
            if (String.IsNullOrEmpty(Model) && VehicleType == "All Types...")
            {
                    OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", CustomerID, Password));
                    OracleCommand cmd = new OracleCommand("SELECT DISTINCT model,type,description FROM vehicle INNER JOIN rental_car ON vehicle.model = rental_car.vehicle_model WHERE rental_car.customer_id IS NULL ORDER BY vehicle.model ASC", conn);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    List<Vehicle> vehicles = new List<Vehicle>();

                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        string model = Convert.ToString(dr["model"]);
                        string description = Convert.ToString(dr["description"]);
                        string vehicletype = Convert.ToString(dr["type"]);
                        vehicles.Add(new Vehicle(null, model, description, vehicletype));
                    }
                    return vehicles;
            }

            /*
                When the VehicleType parameter is not null or empty string and Model 
                parameter is null or empty string, the list of rental cars is filtered 
                to only return available rental cars of the specified vehicle type.
            */
            else if (String.IsNullOrEmpty(Model) && !String.IsNullOrEmpty(VehicleType))
            {
                OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", CustomerID, Password));
                OracleCommand cmd = new OracleCommand("SELECT DISTINCT model,type,description FROM vehicle INNER JOIN rental_car ON vehicle.model = rental_car.vehicle_model WHERE rental_car.customer_id IS NULL AND vehicle.type = :vehicletype  ORDER BY vehicle.model ASC", conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                List<Vehicle> vehicles = new List<Vehicle>();
                cmd.Parameters.AddWithValue(":vehicletype", VehicleType);

                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string model = Convert.ToString(dr["model"]);
                    string description = Convert.ToString(dr["description"]);
                    string vehicletype = Convert.ToString(dr["type"]);
                    vehicles.Add(new Vehicle(null, model, description, vehicletype));
                }
                return vehicles;
            }

            /*
                If the Model parameter is not null or empty string, the method 
                should return all available rental cars that contain the word or 
                partial word specified by the Model parameter.
            */
            else if (!String.IsNullOrEmpty(Model) && VehicleType == "All Types...")
            {
                OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", CustomerID, Password));
                OracleCommand cmd = new OracleCommand("SELECT DISTINCT model,type,description FROM vehicle INNER JOIN rental_car ON vehicle.model = rental_car.vehicle_model WHERE rental_car.customer_id IS NULL AND LOWER(vehicle.model) LIKE :model ORDER BY vehicle.model ASC", conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                List<Vehicle> vehicles = new List<Vehicle>();
                cmd.Parameters.AddWithValue(":model", '%' + Model.ToLower() + '%');

                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string model = Convert.ToString(dr["model"]);
                    string description = Convert.ToString(dr["description"]);
                    string vehicletype = Convert.ToString(dr["type"]);
                    vehicles.Add(new Vehicle(null, model, description, vehicletype));
                }
                return vehicles;
            }

            /*
                When the VehicleType and Model parameter is not null or empty string, 
                the list of rental cars is further filtered (in addition to any model filtering) 
                to only return available rental cars of the specified vehicle type.
            */ 
            else
            {
                OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", CustomerID, Password));
                OracleCommand cmd = new OracleCommand("SELECT DISTINCT model,type,description FROM vehicle INNER JOIN rental_car ON vehicle.model = rental_car.vehicle_model WHERE rental_car.customer_id IS NULL AND vehicle.type = :vehicletype AND LOWER(vehicle.model) LIKE :model ORDER BY vehicle.model ASC", conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                List<Vehicle> vehicles = new List<Vehicle>();
                cmd.Parameters.AddWithValue(":vehicletype", VehicleType);
                cmd.Parameters.AddWithValue(":model", '%' + Model.ToLower() + '%');
               
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string model = Convert.ToString(dr["model"]);
                    string description = Convert.ToString(dr["description"]);
                    string vehicletype = Convert.ToString(dr["type"]);
                    vehicles.Add(new Vehicle(null, model, description, vehicletype));
                }
                return vehicles;
            }
        }

        public List<string> GetVehicleTypes()
        {
            /*
                This method returns a List<string> representing all of the vehicle types 
                supported in the database. The vehicle types should be ordered alphabetically.
            */

            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", CustomerID, Password));
            OracleCommand cmd = new OracleCommand("SELECT * FROM VEHICLE_TYPE ORDER BY type ASC", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<string> types = new List<string>();
            
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                types.Add(Convert.ToString(dr["type"]));         
            }
            return types;
        }
    }
}