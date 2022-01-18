using CustomerManager_WPF_SQL.Data;
using CustomerManager_WPF_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager_WPF_SQL.Services
{

    internal interface IAddressService
    {
        bool CreateAddress(string streetaddress, string postalcode, string city, string country);
        IEnumerable<Address> GetAllAddresses();
    }

    internal class AddressService : IAddressService
    {

        private readonly SqlContext _context = new();

        public bool CreateAddress(string streetaddress, string postalcode, string city, string country)
        {
            var address = _context.Addresses.Where(x => x.StreetName == streetaddress && x.PostalCode == postalcode && x.City == city && x.Country == country).FirstOrDefault();
            if(address == null)
            {
                _context.Addresses.Add(new Address
                {
                    StreetName = streetaddress,
                    PostalCode = postalcode,
                    City = city,
                    Country = country
                });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return _context.Addresses;
        }
    }
}
