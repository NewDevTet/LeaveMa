using LeaveMa.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Business.Repository.Country
{
    public class CountryRepository : ICountryRepository
    {
        private readonly LeaveMaDbContext _context;

        public CountryRepository(LeaveMaDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Data.Entities.Country>> GetCountries()
        {
           return await _context.Countries.ToListAsync();
        }
    }
}
