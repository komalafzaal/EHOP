using Microsoft.AspNetCore.Mvc;

namespace EHOP.Models.Interfaces
{
    public interface IProduct 
    {
        public void addProduct(Product p, string c);
        public List<Product> GetWomenProducts();
        public List<Product> GetMenProducts();
        public List<Product> GetElectronicsProducts();
        public List<Product> GetBeautyProducts();
        public List<Product> GetHomeandDecorProducts();


        //public bool Update(Products p,String productupName);
        //public bool Delete(Products p1);

        //public List<Products> Search(Products p);
    }
}
