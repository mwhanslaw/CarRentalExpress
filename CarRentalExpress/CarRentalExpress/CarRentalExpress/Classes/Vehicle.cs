using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalExpress
{
    public class Vehicle
    {
        public string LicensePlate{get; private set;}
        public string Model{get; private set;} 
        public string Description{get; private set;}
        public string VehicleType{get; private set;}

        public Vehicle(string LicensePlate, string Model, string Description, string VehicleType)
        {
            this.LicensePlate = LicensePlate;
            this.Model = Model;
            this.Description = Description;
            this.VehicleType = VehicleType;


        }
    }
}