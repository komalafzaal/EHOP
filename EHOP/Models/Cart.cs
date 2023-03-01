using EHOP.Models.Interfaces;
namespace EHOP.Models
{
    public class Cart : FullAuditModel
    {
        public int ProdId { get; set; }
        public int Quantity { get; set; }
    }
}