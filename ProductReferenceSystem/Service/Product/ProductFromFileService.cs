using ProductReferenceSystem.Service.Product;
using System;
using System.Collections.Generic;
using System.Text;
using P = ProductReferenceSystem.Model.Product;

namespace ProductReferenceSystem.Service.Product
{
    public class ProductFromFileService : ProductService
    {
        public override HashSet<P> ReadProduct(String pathToFile)
        {
            return null;
        }
    }
}
