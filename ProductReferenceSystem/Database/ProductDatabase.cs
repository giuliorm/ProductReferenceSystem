using ProductReferenceSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductReferenceSystem.Database
{
    public class ProductDatabase
    {
        public static int MAX_SIZE = 2000;

        private HashSet<Product> _products;
        private int _size;

        private static ProductDatabase _instance;

        public static ProductDatabase GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductDatabase();
            }
            return _instance;
        }

        private ProductDatabase()
        {
            this._size = 0;
            this._products = new HashSet<Product>();
        }

        public void AddProducts(ICollection<Product> values)
        {
            if (values == null)
            {
                throw new Exception("Cannot add nulls to database!");
            }
            if (this._products.Count == MAX_SIZE)
            {
                throw new Exception("Cannot add values to database: MAX_SIZE is reached.");
            }
            foreach (Product product in values)
            {
                if (this._products.Count == MAX_SIZE)
                {
                    break;
                }
                AddProduct(product); 
            }
            if (this._products.Count == MAX_SIZE)
            {
                Console.WriteLine(
                    String.Format("Cannot add all values from collection to product database"));
            }
        }
        /// <summary>
        /// Returns a boolean, indicating, whether the Product has been added to database or not.
        /// Database cannot contain nulls.
        /// </summary>
        /// <param name="value">A Product value to be added</param>
        /// <returns>False, if value is null or if the size equals to MAX_SIZE constraint or if 
        /// the value already has been added to database. Otherwise returns true.</returns>
        public Boolean AddProduct(Product value)
        {
            if (value == null) 
            {
                throw new Exception("Cannot add null to the database!");
            }
            if (this._products.Count == MAX_SIZE)
            {
                throw new Exception("Cannot add value to the database: the MAX_SIZE is reached!");
            }
            return this._products.Add(value);
        }

        /// <summary>
        /// Removes value from Products database.
        /// </summary>
        /// <param name="value">A value to be removed from database.</param>
        /// <returns>False, if value is null or if value has already been removed or not contained in the
        /// database.
        /// Otherwise returns true.</returns>
        public Boolean RemoveProduct(Product value)
        {
            if (value == null)
            {
                throw new Exception("Cannot remove null from the database!");
            }
            return this._products.Remove(value);
        }
    }
}
