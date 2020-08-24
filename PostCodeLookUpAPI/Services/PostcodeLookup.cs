using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostCodeLookUpAPI.DAL;
using PostCodeLookUpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeLookUpAPI.Services
{
    public class PostcodeLookup : IPostcodeLookup
    {
        private readonly DeliveryOptionsContext _context;
        const string AllOthers = "All others";

        public PostcodeLookup(DeliveryOptionsContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Returns possible delivery option for postcode.
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        public async Task<string[]> GetValidDeliveryOptions(string postcode)
        {
            string[] deliveyOptions = new string[2];
            //Add user data like postcode
             await AddUserDataToDB(postcode);

            var delDict = await _context.DeliveryOptions.ToDictionaryAsync(r => r.Postcode, r => r.DeliveryOption);
            //Full  postcode match

            while (postcode.Length >= 2)
            {
                //Check if dictionary contains postcode
                if (delDict.ContainsKey(postcode))
                {
                    deliveyOptions[0] = delDict[postcode];
                    return deliveyOptions;
                }
                //reduce each character from postcode
                if (postcode.Length > 2)
                    postcode = postcode.Remove(postcode.Length - 1, 1);
                else
                    break;
            }
            //Last option if there is no mathc found.
            deliveyOptions[0] = delDict[AllOthers];
            return deliveyOptions;

        }
        /// <summary>
        /// Capture user entered postcode
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        public async Task AddUserDataToDB(string postcode)
        {
            UserData userData = new UserData { Postcode = postcode, EnteredDateTime = DateTime.Now, User = "ToBeSet" };
            await _context.UserData.AddAsync(userData);
            await _context.SaveChangesAsync();
        }
    }
}
