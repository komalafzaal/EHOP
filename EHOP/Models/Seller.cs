using EHOP.Models.Interfaces;

namespace EHOP.Models
{ 
    public class Seller : FullAuditModel
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        //public ICollection<Product> Products { get; set; }

    }

}