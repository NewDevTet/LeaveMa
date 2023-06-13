using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMa.Data.Context
{
    public  class LeaveMaDbContext : DbContext
    {
        public LeaveMaDbContext(DbContextOptions<LeaveMaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


    }
}
