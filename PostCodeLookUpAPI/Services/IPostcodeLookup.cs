using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeLookUpAPI.Models
{
    public interface  IPostcodeLookup
    {   
       Task<string[]> GetValidDeliveryOptions(string postcode);
    }
}
