using CustomerManager_WPF_SQL.Data;
using CustomerManager_WPF_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager_WPF_SQL.Services
{
    internal interface IErrandService
    {
        bool CreateErrand(string errandtitle, string erranddescription, string errandstatus);
        IEnumerable<CustomerErrand> GetAllErrands();
    }

    internal class ErrandService : IErrandService
    {

        private readonly SqlContext _context = new();

        public bool CreateErrand(string errandtitle, string erranddescription, string errandstatus)
        {
            var errand = _context.CustomerErrands.Where(x => x.ErrandTitle == errandtitle).FirstOrDefault();
            if (errand != null)
            {
                _context.CustomerErrands.Add(new CustomerErrand
                {
                    ErrandTitle = errandtitle,
                    ErrandDescription = erranddescription,
                    ErrandStatus = errandstatus
                });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<CustomerErrand> GetAllErrands()
        {
            return _context.CustomerErrands;
        }
    }
}
