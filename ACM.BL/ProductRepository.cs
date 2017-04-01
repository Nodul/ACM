using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class ProductRepository
    {
        public Product Retrieve(int productID)
        {
            Product product = new Product(productID);

            // Also temp hard coded
            if(productID == 2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription = "Assorted sizes";
                product.CurrentPrice = 15.95M;
            }

            return product;
        }
        public bool Save(Product product)
        {
            var success = true;

            if(product.HasChanges && product.IsValid)
            {
                if (product.IsNew)
                {
                    // Call an insert stored procedure
                }
                else
                {
                    // Call an Update Stored Procedure
                }
            }
            return success;
        }
    }
}
