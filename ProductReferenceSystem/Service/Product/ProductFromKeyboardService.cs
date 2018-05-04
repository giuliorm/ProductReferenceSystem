using ProductReferenceSystem.Database;
using ProductReferenceSystem.Model;
using P = ProductReferenceSystem.Model.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductReferenceSystem.Service.Product
{
    public class ProductFromKeyboardService : ProductService
    {
        /// <summary>
        /// Product is given in the following format:
        /// 
        /// productName, productStoreName, price
        /// 
        /// The values are divided by comma. The product has 3 values average.
        /// The input string should be given exactly in the specified format, 
        /// otherwise the product won't be read.
        /// </summary>
        /// <param name="productString"></param>
        public override HashSet<P> ReadProduct(String productString)
        {
            if (productString == null)
            {
                throw new Exception("The Product string is null. Product cannot be read");
            }
            String[] values = productString.Split(new char[] { ',' });
            if (values.Length != 3)
            {
                throw new Exception("The Product string is in the invalid format. The format " +
                    "should be the following:" +
                    "\n" +
                    "productName, productStoreName, productPrice" +
                    "\n\n");
            }

            String productName = values[0];
            String storeName = values[1];
            Decimal productPrice = -1;
            Decimal.TryParse(values[2], out productPrice);
            if (productPrice < 0)
            {
                throw new Exception("Cannot parse product price! The price should be a positive number.");
            }

            P product = new P()
            {
                Name = productName,
                StoreName = storeName,
                Price = productPrice
            };

            return new HashSet<P>() { product };
        }
    }
}
