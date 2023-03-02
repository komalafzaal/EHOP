using Microsoft.AspNetCore.Mvc;

namespace EHOP.Models.Interfaces
{
    public interface ISeller 
    {
        public int getSellerId(string sellerEmail);

    }
}
