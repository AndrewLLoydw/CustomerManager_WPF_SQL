using CustomerManager_WPF_SQL.Data;
using CustomerManager_WPF_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager_WPF_SQL.Services
{
    public class CustomerService
    {
        private readonly SqlContext _context = new SqlContext();

        public void CreateCustomer(string firstname, string lastname, string email, string phonenumber, int addressId)
        {
            var customer = _context.Customers.Where(x => x.Email == email).FirstOrDefault();
            if (customer == null)
            {
                _context.Customers.Add(new Customer { FirstName = firstname, LastName = lastname, Email = email, PhoneNumber = phonenumber, AddressId = addressId });
                _context.SaveChanges();
            }
        } 

        public void CreateAddress(string streetname, string postalcode, string city, string country)
        {
            var address = _context.Addresses.Where(x => x.StreetName == streetname && x.PostalCode == postalcode && x.City == city && x.Country == country).FirstOrDefault();
            if (address == null)
            {
                _context.Addresses.Add(new Address { StreetName = streetname, PostalCode = postalcode, City = city, Country = country });
                _context.SaveChanges();
            }
        }
    }
}
