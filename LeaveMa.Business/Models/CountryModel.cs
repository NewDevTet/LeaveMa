using LeaveMa.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Entities
{
    public class CountryModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<HolidayModel> Holidays { get; set; }
        public ICollection<EmployeeModel> Employees { get; set; }

    }
}
