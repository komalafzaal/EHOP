﻿using EHOP.Models.Interfaces;
using EHOP.Models; 

namespace EHOP.Models
{
    public partial class Buyer : FullAuditModel
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}