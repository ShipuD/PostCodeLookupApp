using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PostCodeLookUpAPI.DAL;
using PostCodeLookUpAPI.Models;
using PostCodeLookUpAPI.Services;

namespace PostCodeLookUpAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostcodeLookupController : ControllerBase
    {
        private readonly DeliveryOptionsContext _context;
        private readonly IPostcodeLookup _iPostcodeLooup;

        public PostcodeLookupController(DeliveryOptionsContext context, IPostcodeLookup iPostcodeLookup)
        {
            _context = context;
            _iPostcodeLooup = iPostcodeLookup;
        }
      
        // Post: api/PostcodeLookup/{postcode}
        [HttpGet("{postcode}")]
        public async Task<string> Search(string postcode)
        {            
            string[] deliveryOptions = await _iPostcodeLooup.GetValidDeliveryOptions(postcode);
            var jsonString = JsonConvert.SerializeObject(deliveryOptions[0]);
            return jsonString;
        }        
    }
}
