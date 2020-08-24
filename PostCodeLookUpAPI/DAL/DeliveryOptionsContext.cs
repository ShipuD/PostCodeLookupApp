using Microsoft.EntityFrameworkCore;
using PostCodeLookUpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeLookUpAPI.DAL
{
    public class DeliveryOptionsContext: DbContext
    {

        public DeliveryOptionsContext (DbContextOptions<DeliveryOptionsContext> options)
            : base(options)
        { }

        public DbSet<DeliveryOptions> DeliveryOptions { get; set; }
        public DbSet<UserData> UserData { get; set; }
    }
}
