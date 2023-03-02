using EHOP.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using EHOP.Models;
using Microsoft.AspNetCore.Http;
using EHOP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Azure.Core;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System;

namespace EHOP.Models.Repository
{
    public class SellerRepository : ISeller
    {
        EhopContext db = new EhopContext();

        public int getSellerId(string sellerEmail)
        {
            var seller = db.Sellers.FirstOrDefault(s => s.Email == sellerEmail);
            if (seller != null)
            {
                return (int)seller.Id;
            }
            else
            {
                return -1; // or any other value that indicates seller not found
            }
        }
    }
}
