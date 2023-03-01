using EHOP.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using EHOP.Models;
using Microsoft.AspNetCore.Http;
using EHOP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Azure.Core;

namespace EHOP.Models.Repository
{
    public class ProductRepository : IProduct
    {
        public void addProduct(Product p, string ? cookieValue)
        {
            var db = new EhopContext();
            p.LastModifiedDate = p.CreatedDate = DateTime.Now;
            p.SellerId = Int32.Parse(cookieValue);

            db.Products.Add(p);
            db.SaveChanges();
        }

        public List<Product> GetWomenProducts()
        {
            List<Product> p = new List<Product>();

            var db = new EhopContext();

            p = db.Products.Where(p => p.Category == "Women" || p.Category == "women").ToList();

            return p;
        }

        public List<Product> GetMenProducts()
        {
            List<Product> p = new List<Product>();

            var db = new EhopContext();

            p = db.Products.Where(p => p.Category == "Men" || p.Category == "men").ToList();

            return p;
        }

        public List<Product> GetElectronicsProducts()
        {
            List<Product> p = new List<Product>();  

            var db = new EhopContext();

            p = db.Products.Where(p => p.Category == "Electronics" || p.Category == "electronics").ToList();

            return p;
        }
        public List<Product> GetBeautyProducts()
        {
            List<Product> p = new List<Product>();

            var db = new EhopContext();

            p = db.Products.Where(p => p.Category == "Beauty" || p.Category == "beauty").ToList();

            return p;
        }
        public List<Product> GetHomeandDecorProducts()
        {
            List<Product> p = new List<Product>();

            var db = new EhopContext();

            p = db.Products.Where(p => p.Category == "HomeandDecor" || p.Category == "homeanddecor").ToList();

            return p;
        }
        //public List<Products> GetSpecials()
        //{
        //    List<Products> p = new List<Products>();



        //    var db = new DbContextClass();

        //    p = db.Products.Where(p => p.productType == "Specials" || p.productType == "specials").ToList();

        //    return p;
        //}

        //public List<Products> GetPopular()
        //{
        //    List<Products> p = new List<Products>();

        //    var db = new DbContextClass();
        //    p = db.Products.Where(p => p.productType == "Popular" || p.productType == "popular").ToList();

        //    return p;
        //}


        //public bool Update(Products p1, String productupName)
        //{
        //    var db = new DbContextClass();
        //    Products? p2=new Products();
        //     p2 = db.Products.Where(p => p.productType == p1.productType && p.productName == p1.productName).FirstOrDefault();

        //    if (p2 != null)
        //    {
        //        if (productupName != null && p2.price != 0 )
        //        {
        //            p2.productName = productupName;
        //            p2.price = p1.price;
        //            p2.lastModifiedDate = DateTime.Now;
        //            p2.LastModifiedUserId = p1.LastModifiedUserId;
        //            db.SaveChanges();
        //            return true;
        //        }
        //    }


        //    return false;
        //}

        //public bool Delete(Products p1)
        //{
        //    var db = new DbContextClass();
        //    Products? p2 = new Products();
        //    Cart? p3 = new Cart();
        //    if (p1.productName != null)
        //    {

        //             p2 = db.Products.Where(p => p.productType == p1.productType && p.productName == p1.productName).FirstOrDefault();
        //             p3 = db.Cart.Where(p => p.productType == p1.productType && p.productName == p1.productName).FirstOrDefault();
        //        if (p2 != null)
        //        {
        //            p2.IsActive = false;
        //            if(p3!=null)
        //            {
        //                db.Remove(p3);
        //            }
        //            db.SaveChanges();
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //public List<Products> Search(Products p1)
        //{
        //    List<Products> p = new List<Products>();
        //    var db = new DbContextClass();
        //    p = db.Products.Where(p2 => p2.price == p1.price && p2.productType == p1.productType).ToList();

        //    return p;
        //}



    }
}
