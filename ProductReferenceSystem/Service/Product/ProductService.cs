using ProductReferenceSystem.Database;
using System;
using System.Collections.Generic;
using System.Text;
using P = ProductReferenceSystem.Model.Product;

namespace ProductReferenceSystem.Service.Product
{
    public abstract class ProductService 
    {
        public abstract HashSet<P> ReadProduct(String item);

        public static void AddProducts(HashSet<P> products)
        {
            ProductDatabase.GetInstance().AddProducts(products);
        }
    }
}
