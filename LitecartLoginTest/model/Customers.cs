using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitecartLoginTest
{
    public class Customers
    {

        private string email= "test" + DateTime.Now.ToString("yyMMddmmss") + "@test.ru";
           
        public string TaxId { get; set; } ="010101010101";
        public string Company { get; set; } = "TestCompany";
        public string FirstName { get; set; } = "TestName";
        public string LastName { get; set; } = "TestLastName";
        public string Address1 { get; set; } = "Test Address 1";
        public string Address2 { get; set; } = "Test Address 2";
        public string Postcode{ get; set; } = "22222";
        public string City { get; set; } = "TestCity";
        public string Country { get; set; } = "United States";
        public string Zone { get; set; } = "Florida";
        public string Email{ get { return email; } }
        public string Phone { get; set; } = "987654321";
        public string Password { get; set; } = "qwerty";

        public Customers()
        { 
          
        }
    }
}
