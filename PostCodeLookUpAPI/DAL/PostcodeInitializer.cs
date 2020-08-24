using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;
using System.Collections.Generic;
using PostCodeLookUpAPI.Models;

namespace PostCodeLookUpAPI.DAL
{
    public class PostcodeInitializer
    {
        public static void SeedDeliveryPostcodes(DeliveryOptionsContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.DeliveryOptions.Any())
            {
                var postcodeDelivery = new List<DeliveryOptions>
                {
                   new DeliveryOptions { Postcode = "TN9", DeliveryOption = "Delivery from Warehouse" },
                   new DeliveryOptions { Postcode = "TN9 1AP", DeliveryOption = "No Deliveries" },
                   new DeliveryOptions { Postcode = "TN8", DeliveryOption = "Delivery from Warehouse" },
                   new DeliveryOptions { Postcode = "TN11", DeliveryOption = "Delivery from Warehouse" },
                   new DeliveryOptions { Postcode = "TN1", DeliveryOption = "Van Delivery, Collect from Tunbridge Wells" },
                   new DeliveryOptions { Postcode = "TN2", DeliveryOption = "Van Delivery, Collect from Tunbridge Wells" },
                   new DeliveryOptions { Postcode = "TN10", DeliveryOption = "Van Delivery" },
                   new DeliveryOptions { Postcode = "TN13", DeliveryOption = "Delivery from Sevenoaks, Collect from Sevenoaks" },
                   new DeliveryOptions { Postcode = "TN14", DeliveryOption = "Delivery from Sevenoaks, Collect from Sevenoaks" },
                   new DeliveryOptions { Postcode = "TN15", DeliveryOption = "Collect from Sevenoaks" },
                   new DeliveryOptions { Postcode = "ME", DeliveryOption = "No Deliveries" },
                   new DeliveryOptions { Postcode = "ME10", DeliveryOption = "Collect from Kitchen" },
                   new DeliveryOptions { Postcode = "ME10 3", DeliveryOption = "Collect from Kitchen, Delivery from Sittingbourne" },
                   new DeliveryOptions { Postcode = "IV", DeliveryOption = "No Deliveries" },
                   new DeliveryOptions { Postcode = "All others", DeliveryOption = "Delivery by Courier" }

                };

                postcodeDelivery.ForEach(s => dbContext.DeliveryOptions.Add(s));
                dbContext.SaveChanges();
            }
        }
    }
}

