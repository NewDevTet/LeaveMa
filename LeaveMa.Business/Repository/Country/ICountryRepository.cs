using LeaveMa.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.Country
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Data.Entities.Country>> GetCountries();
    }
}
