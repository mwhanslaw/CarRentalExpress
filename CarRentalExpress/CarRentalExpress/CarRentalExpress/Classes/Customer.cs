// Sofia Dalessandro
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalExpress
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(string CustomerId, string Password, string FirstName, string LastName)
        {
            this.CustomerId = CustomerId;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}