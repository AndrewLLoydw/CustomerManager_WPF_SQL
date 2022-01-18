using CustomerManager_WPF_SQL.Data;
using CustomerManager_WPF_SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager_WPF_SQL.Services
{
    public class CustomerServiceManager
    {
        private readonly SqlContext _context = new SqlContext();

        internal interface ICustomerService
        {
            bool CreateCustomer(string firstname, string lastname, string email, string phonenumber, string streetaddress, string postalnumber, string city, string country);
            IEnumerable<Customer> GetAllCustomers();

            Customer GetCustomer(string email);



        }

        internal class CustomerService : ICustomerService
        {
            private readonly SqlContext _context = new();

            public bool CreateCustomer(string firstname, string lastname, string email, string phonenumber, string streetaddress, string postalnumber, string city, string country)
            {
                var customer = _context.Customers.Where(x => x.Email == email && x.PhoneNumber == phonenumber).FirstOrDefault();
                if (customer == null)
                {
                    _context.Customers.Add(new Customer
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Email = email,
                        PhoneNumber = phonenumber,
                        Address = new Address
                        {
                            StreetName = streetaddress,
                            PostalCode = postalnumber,
                            City = city,
                            Country = country
                        }
                    });
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }

            public IEnumerable<Customer> GetAllCustomers()
            {
                return _context.Customers.Include(x => x.Address);
            }


            public Customer GetCustomer(string email)
            {
                var customer = _context.Customers.Where(x => x.Email == email).FirstOrDefault();


                return customer;
            }
        }
    }
}
