﻿using EHOP.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EHOP.Models
{

    public abstract class FullAuditModel : IIdentityModel, IAuditedModel, IActivatableModel
    {

        public int? Id { get; set; }
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public bool? IsActive { get; set; }

       
    }
    
}
