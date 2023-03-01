using EHOP.Models.Interfaces;

namespace EHOP.Models
{
    public class Product : FullAuditModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? imagename { get; set; }

        public int Price { get; set; }

        public string? Category { get; set; }

        public int Quantity { get; set; }
    }

}