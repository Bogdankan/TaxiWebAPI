using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaxiMVC.Models.Driver;
using TaxiMVC.Models.Car;
using TaxiMVC.Models.Order;

namespace TaxiWebAPI.Data
{
    public class TaxiWebAPIContext : DbContext
    {
        public TaxiWebAPIContext (DbContextOptions<TaxiWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TaxiMVC.Models.Driver.Driver> Driver { get; set; } = default!;

        public DbSet<TaxiMVC.Models.Car.Car>? Car { get; set; }

        public DbSet<TaxiMVC.Models.Order.Order>? Order { get; set; }
    }
}
